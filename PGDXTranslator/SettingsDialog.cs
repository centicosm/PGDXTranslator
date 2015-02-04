using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGDXTranslator {
    public partial class SettingsDialogForm : Form {

        public SettingsDialogForm(String apiKey) {
            InitializeComponent();

            _GoogleAPIKeyTextBox.Text = apiKey;
        }

        private void SettingOkButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void SettingCancelButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
