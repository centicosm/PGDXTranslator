namespace PGDXTranslator {
    partial class SettingsDialogForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this._GoogleAPIKeyTextBox = new System.Windows.Forms.TextBox();
            this._GoogleAPIKeyLabel = new System.Windows.Forms.Label();
            this._SettingOkButton = new System.Windows.Forms.Button();
            this._SettingsCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _GoogleAPIKeyTextBox
            // 
            this._GoogleAPIKeyTextBox.Location = new System.Drawing.Point(12, 44);
            this._GoogleAPIKeyTextBox.Name = "_GoogleAPIKeyTextBox";
            this._GoogleAPIKeyTextBox.Size = new System.Drawing.Size(413, 20);
            this._GoogleAPIKeyTextBox.TabIndex = 0;
            // 
            // _GoogleAPIKeyLabel
            // 
            this._GoogleAPIKeyLabel.AutoSize = true;
            this._GoogleAPIKeyLabel.Location = new System.Drawing.Point(13, 25);
            this._GoogleAPIKeyLabel.Name = "_GoogleAPIKeyLabel";
            this._GoogleAPIKeyLabel.Size = new System.Drawing.Size(85, 13);
            this._GoogleAPIKeyLabel.TabIndex = 1;
            this._GoogleAPIKeyLabel.Text = "Google API Key:";
            // 
            // _SettingOkButton
            // 
            this._SettingOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._SettingOkButton.Location = new System.Drawing.Point(113, 106);
            this._SettingOkButton.Name = "_SettingOkButton";
            this._SettingOkButton.Size = new System.Drawing.Size(75, 23);
            this._SettingOkButton.TabIndex = 2;
            this._SettingOkButton.Text = "Ok";
            this._SettingOkButton.UseVisualStyleBackColor = true;
            this._SettingOkButton.Click += new System.EventHandler(this.SettingOkButton_Click);
            // 
            // _SettingsCancelButton
            // 
            this._SettingsCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._SettingsCancelButton.Location = new System.Drawing.Point(256, 106);
            this._SettingsCancelButton.Name = "_SettingsCancelButton";
            this._SettingsCancelButton.Size = new System.Drawing.Size(75, 23);
            this._SettingsCancelButton.TabIndex = 3;
            this._SettingsCancelButton.Text = "Cancel";
            this._SettingsCancelButton.UseVisualStyleBackColor = true;
            // 
            // SettingsDialogForm
            // 
            this.AcceptButton = this._SettingOkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._SettingsCancelButton;
            this.ClientSize = new System.Drawing.Size(437, 156);
            this.Controls.Add(this._SettingsCancelButton);
            this.Controls.Add(this._SettingOkButton);
            this.Controls.Add(this._GoogleAPIKeyLabel);
            this.Controls.Add(this._GoogleAPIKeyTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 194);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(453, 194);
            this.Name = "SettingsDialogForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PGDXTranslator Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _GoogleAPIKeyLabel;
        private System.Windows.Forms.Button _SettingOkButton;
        private System.Windows.Forms.Button _SettingsCancelButton;
        public System.Windows.Forms.TextBox _GoogleAPIKeyTextBox;
    }
}