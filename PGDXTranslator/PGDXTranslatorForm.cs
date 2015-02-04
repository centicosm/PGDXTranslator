using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGDXTranslator {
    public partial class PGDXTranslatorForm : Form
    {

        private String _APIKey;
        private Language[] _SupportedLanguages;

        private class Item {
            public string Name;
            public int Value;
            public Item(string name, int value) {
                Name = name; Value = value;
            }
            public override string ToString() {
                // Generates the text shown in the combo box
                return Name;
            }
        }
    

    public PGDXTranslatorForm() {
            InitializeComponent();
            _APIKey = "";
        }


        // When the main translator form first appears, check to see if the API key is known
        private void PGDXTranslatorForm_Shown(object sender, System.EventArgs e) {
            
            // try to read the API key from file
            try {
                using (StreamReader sr = new StreamReader("./apikey.txt")) {
                    String line = sr.ReadToEnd();
                    line.TrimEnd();
                    if (line.Length > 0) {
                        _APIKey = line;
                    }

                    // if it is empty show a dialog to enter it
                    else {
                        MessageBox.Show("PGDXTranslator needs a Google Translate capable API key to operate.");
                        Show_SettingsDialog();
                    }
                }
            }

            // if the API key file does not exist, show a dialog to enter the key
            catch (Exception ex) {
                MessageBox.Show("PGDXTranslator needs a Google Translate capable API key to operate.");
                Show_SettingsDialog();
            }

            if (_APIKey.Length != 0) {
                Request_AvailableLanguages();
            }
            
        }


        private void Show_SettingsDialog() {
           SettingsDialogForm settings = new SettingsDialogForm(_APIKey);
           if (settings.ShowDialog(this) == DialogResult.OK) {
               _APIKey = settings._GoogleAPIKeyTextBox.Text;

               // save the API key entered by the user to a file for future reference
               if (_APIKey.Length > 0) {
                   System.IO.File.WriteAllText("./apikey.txt", _APIKey + "\r\n");
                   MessageBox.Show(_APIKey);
               }
           }
        }

        private void SettingsButton_Click(object sender, EventArgs e) {
            Show_SettingsDialog();
        }


        private void Populate_SourceLanguages() {
            int cnt = 0;
            _InputLanguageComboBox.Items.Clear();

            foreach (Language l in _SupportedLanguages) {
                String lang = l.LanguageName + " (" + l.LanguageCode + ")";
                _InputLanguageComboBox.Items.Add(new Item(lang, cnt++));
            }
        }


        // Select the file to translate
        private void InputFileSelectionButton_Click(object sender, EventArgs e) {

            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            inputFileDialog.RestoreDirectory = true;

            if (inputFileDialog.ShowDialog() == DialogResult.OK) {
                _InputFileTextBox.Text = inputFileDialog.FileName;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {

            // Save default settings
            Close();
        }


        private void OutputPathSelectionButton_Click(object sender, EventArgs e) {

            FolderBrowserDialog outputFolderDialog = new FolderBrowserDialog();
            outputFolderDialog.SelectedPath = Directory.GetCurrentDirectory();

            if (outputFolderDialog.ShowDialog() == DialogResult.OK) {
                _OutputPathTextBox.Text = outputFolderDialog.SelectedPath;
            }
        }



        // Query the translate api for the list of languages available
        private void Request_AvailableLanguages() {
            String requestUrl = "https://www.googleapis.com/language/translate/v2/languages?key=" + _APIKey + "&target=en";
            TranslateAPIResponse resp = Make_HTTPRequest(requestUrl);
            if (resp != null) {
             //   // This request does not return the name of the language so we will use the NET localization to grab that
                MessageBox.Show("Num Languages: " + resp.DataSets.Languages.Length.ToString());
                _SupportedLanguages = resp.DataSets.Languages;
                Populate_SourceLanguages();
            }
        }


        private  TranslateAPIResponse Make_HTTPRequest(string requestUrl) {
            try {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                    if (response.StatusCode != HttpStatusCode.OK) {
                        throw new Exception(String.Format("Could not connect to Google API (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                    }
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(TranslateAPIResponse));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    TranslateAPIResponse jsonResponse = objResponse as TranslateAPIResponse;
                    return jsonResponse;
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                return null;
            }
        }


    }
}
