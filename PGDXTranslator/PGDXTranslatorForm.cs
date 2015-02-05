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
    public partial class PGDXTranslatorForm : Form {

        private Boolean _ValidConfiguration = false;
        private String _APIKey;

        private Language[] _SupportedLanguages;
        private String _SelectedLangCode;
        private CheckBox[] _DestinationCheckbox = null;
        private List<String> _TranslationDestinationList;
        

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
            _SelectedLangCode = "en";
            _TranslationDestinationList = new List<String>();
            Center_Buttons();
        }


        // When the main translator form first appears, load the config file and check for an API key
        private void PGDXTranslatorForm_Shown(object sender, System.EventArgs e) {
            
            Load_Settings();
            if (_APIKey.Length != 0) {
                Request_AvailableLanguages(_SelectedLangCode);
            }
        }


        private void Show_SettingsDialog() {
           SettingsDialogForm settings = new SettingsDialogForm(_APIKey);
           if (settings.ShowDialog(this) == DialogResult.OK) {
               _APIKey = settings._GoogleAPIKeyTextBox.Text;

               // save the API key entered by the user to a file for future reference
               if (_APIKey.Length > 0) {
                   Save_Settings();
                   Request_AvailableLanguages(_SelectedLangCode);
               }
           }
        }


        private void SettingsButton_Click(object sender, EventArgs e) {
            Show_SettingsDialog();
            Center_Buttons();
        }


        // Populate the source language combobox with the contents of the _SupportedLanguages array (generated from a translate api query)
        private void Populate_SourceLanguages(String selectedLangCode) {
            int cnt = 0;
            int selectedIndex = 0;
            _InputLanguageComboBox.Items.Clear();

            foreach (Language l in _SupportedLanguages) {
                if (selectedLangCode == l.LanguageCode) {
                    selectedIndex = cnt;
                }
                String lang = l.LanguageName + " (" + l.LanguageCode + ")";
                _InputLanguageComboBox.Items.Add(new Item(lang, cnt++));
            }
            _InputLanguageComboBox.SelectedIndex = selectedIndex;
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
            Save_Settings();

            Close();
        }


        // save the api key, source, and destination languages for next time
        private void Save_Settings() {

            if (_SelectedLangCode == "") {
                _SelectedLangCode = "en";
            }

            String destLangs = "";
            foreach (String s in _TranslationDestinationList) {
                destLangs += (s + ",");
            }

            System.IO.File.WriteAllText("./pgdxtranslator.cfg", (_APIKey + "\r\n" + _SelectedLangCode + "\r\n" + destLangs + "\r\n"));
        }


        // Load the api key and the last used settings from the config file
        private void Load_Settings() {
            _APIKey = "";
            _SelectedLangCode = "";
            _TranslationDestinationList.Clear();
            
            
            try {
                using (StreamReader sr = new StreamReader("./pgdxtranslator.cfg")) {

                    // try to read the API key from file
                    String line = sr.ReadLine();
                    line.TrimEnd();
                    if (line.Length > 0) {
                        _APIKey = line;
                    }

                    // if it is empty show a dialog to enter it
                    else {
                        MessageBox.Show("PGDXTranslator needs a Google Translate capable API key to operate.");
                        Show_SettingsDialog();
                        return;
                    }

                    // load saved source language
                    line = sr.ReadLine();
                    line.TrimEnd();
                    _SelectedLangCode = line;

                    // load the destination languages
                    line = sr.ReadLine();
                    line.TrimEnd();
                    String []langs = line.Split(',');
                    foreach (String s in langs) {
                        if (s.Length > 0) {
                            _TranslationDestinationList.Add(s);
                        }
                    }              
                }
            }

            // if the config file does not exist pop up the settings dialog so the user can enter a key
            catch (Exception ex) {
                MessageBox.Show("PGDXTranslator needs a Google Translate capable API key to operate.");
                Show_SettingsDialog();
            }
        }



        private void OutputPathSelectionButton_Click(object sender, EventArgs e) {

            FolderBrowserDialog outputFolderDialog = new FolderBrowserDialog();
            outputFolderDialog.SelectedPath = Directory.GetCurrentDirectory();

            if (outputFolderDialog.ShowDialog() == DialogResult.OK) {
                _OutputPathTextBox.Text = outputFolderDialog.SelectedPath;
            }
        }



        // Query the translate api for the list of languages available reported in language targetLang
        private void Request_AvailableLanguages(String targetLang) {
            String requestUrl = "https://www.googleapis.com/language/translate/v2/languages?key=" + _APIKey + "&target=" + targetLang;
            TranslateAPIResponse resp = Make_HTTPRequest(requestUrl);

            // clear out the check-boxes used to select the languages to translate into
            if (_DestinationCheckbox != null) {
                for (int i = 0; i < _DestinationCheckbox.Length; i++) {
                    this.Controls.Remove(_DestinationCheckbox[i]);
                }
            }
            
            // if we got a valid response populate the combo-boxes and check-boxes with the available languages in the target language
            if (resp != null) {
                _DestinationCheckbox = new CheckBox[resp.DataSets.Languages.Length];
                _SupportedLanguages = resp.DataSets.Languages;
                Populate_SourceLanguages(targetLang);
                Create_DestinationLangCheckBoxes();
            }
        }




        // make a request to the translate api
        private  TranslateAPIResponse Make_HTTPRequest(string requestUrl) {
            try {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                    if (response.StatusCode != HttpStatusCode.OK) {
                        throw new Exception(String.Format("Could not connect to Google API (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                    }
                    _ValidConfiguration = true;
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(TranslateAPIResponse));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    TranslateAPIResponse jsonResponse = objResponse as TranslateAPIResponse;
                    return jsonResponse;
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message + " - Check your API key.");
                _ValidConfiguration = false;
                return null;
            }
        }


        // translate all languages to the selected input language
        private void InputLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int index = _InputLanguageComboBox.SelectedIndex;
            if (_SelectedLangCode == _SupportedLanguages[index].LanguageCode) return;
            _SelectedLangCode = _SupportedLanguages[index].LanguageCode;


            if ((index >= 0) && (index < _SupportedLanguages.Length)) {
                Request_AvailableLanguages(_SupportedLanguages[index].LanguageCode);
            }
        }


        // create all the translation destination checkboxes in the language selected by the user
        private void Create_DestinationLangCheckBoxes() {

            // figure out the horizontal spacing of the check-boxes
            int maxStringSize = -1;
            Graphics g = this.CreateGraphics();
            Font checkBoxFont = new Font("Microsoft Sans Serif", 8.25f);

            for (int i = 0; i < _SupportedLanguages.Length; i++) {
                SizeF stringSize = g.MeasureString(_SupportedLanguages[i].LanguageName + " (" + _SupportedLanguages[i].LanguageCode + ")", checkBoxFont);
                int curSize = (int)(stringSize.Width + 1);
                if (curSize > maxStringSize) {
                    maxStringSize = curSize;
                }
            }
            g.Dispose();


            // now create the check-boxes
            for (int i = 0; i < _SupportedLanguages.Length; i++) {
                _DestinationCheckbox[i] = new CheckBox();

                String destLangCode = _SupportedLanguages[i].LanguageCode;
                _DestinationCheckbox[i].Tag = destLangCode;
                _DestinationCheckbox[i].Text = _SupportedLanguages[i].LanguageName + " (" + destLangCode + ")";
                _DestinationCheckbox[i].AutoSize = true;

                int x = 10 + ((i % 7) * (maxStringSize + 20));
                int y = 180 + ((i / 7) * 40);
                _DestinationCheckbox[i].Location = new Point(x, y);

                // Disable translation to the source language
                if (destLangCode == _SelectedLangCode) {
                    _DestinationCheckbox[i].Enabled = false;
                }

                // if it is already marked as a language to translate make sure the check-box is checked
                if (_TranslationDestinationList.Contains(destLangCode)) {
                    _DestinationCheckbox[i].Checked = true;
                }

                _DestinationCheckbox[i].CheckedChanged += new System.EventHandler(this.Handle_DestCheckboxChanged);

                this.Controls.Add(_DestinationCheckbox[i]);
            }

            Center_Buttons();
        }


        // Recenter the translate, settings, and exit buttons after a potential window size change
        private void Center_Buttons() {
            _TranslateButton.Left = (this.ClientSize.Width - _TranslateButton.Width) / 2;

            int bottomButtonWidth = _SettingsButton.Width + _ExitButton.Width + 50;
            _SettingsButton.Left = (this.ClientSize.Width - bottomButtonWidth) / 2;
            _ExitButton.Left = (this.ClientSize.Width / 2)  + 25;
        }


        private void Handle_DestCheckboxChanged(object sender, EventArgs e) {
            CheckBox cb = sender as CheckBox;
            String langCode = cb.Tag as String;

            // Add the language code to the list of languages to translate to if the checkbox was checked
            if (cb.Checked) {
                if (!_TranslationDestinationList.Contains(langCode)) {
                    _TranslationDestinationList.Add(langCode);
                }
            }

            // otherwise remove the destination language from our list
            else {
                _TranslationDestinationList.Remove(langCode);
            }
        }



    }
}
