namespace PGDXTranslator {
    partial class PGDXTranslatorForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PGDXTranslatorForm));
            this._InputFileTextBox = new System.Windows.Forms.TextBox();
            this._InputFileSelectionLabal = new System.Windows.Forms.Label();
            this._InputFileSelectionButton = new System.Windows.Forms.Button();
            this._OutputPathTextBox = new System.Windows.Forms.TextBox();
            this._OutputPathLabel = new System.Windows.Forms.Label();
            this._OutputPathSelectionButton = new System.Windows.Forms.Button();
            this._InputLanguageComboBox = new System.Windows.Forms.ComboBox();
            this._InputLanguageLabel = new System.Windows.Forms.Label();
            this._TranslateButton = new System.Windows.Forms.Button();
            this._SettingsButton = new System.Windows.Forms.Button();
            this._InputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._ExitButton = new System.Windows.Forms.Button();
            this._BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // _InputFileTextBox
            // 
            this._InputFileTextBox.Location = new System.Drawing.Point(35, 67);
            this._InputFileTextBox.Name = "_InputFileTextBox";
            this._InputFileTextBox.Size = new System.Drawing.Size(346, 20);
            this._InputFileTextBox.TabIndex = 0;
            // 
            // _InputFileSelectionLabal
            // 
            this._InputFileSelectionLabal.AutoSize = true;
            this._InputFileSelectionLabal.Location = new System.Drawing.Point(35, 48);
            this._InputFileSelectionLabal.Name = "_InputFileSelectionLabal";
            this._InputFileSelectionLabal.Size = new System.Drawing.Size(53, 13);
            this._InputFileSelectionLabal.TabIndex = 1;
            this._InputFileSelectionLabal.Text = "Input File:";
            // 
            // _InputFileSelectionButton
            // 
            this._InputFileSelectionButton.Location = new System.Drawing.Point(387, 64);
            this._InputFileSelectionButton.Name = "_InputFileSelectionButton";
            this._InputFileSelectionButton.Size = new System.Drawing.Size(75, 23);
            this._InputFileSelectionButton.TabIndex = 2;
            this._InputFileSelectionButton.Text = "Browse";
            this._InputFileSelectionButton.UseVisualStyleBackColor = true;
            this._InputFileSelectionButton.Click += new System.EventHandler(this.InputFileSelectionButton_Click);
            // 
            // _OutputPathTextBox
            // 
            this._OutputPathTextBox.Location = new System.Drawing.Point(38, 132);
            this._OutputPathTextBox.Name = "_OutputPathTextBox";
            this._OutputPathTextBox.Size = new System.Drawing.Size(343, 20);
            this._OutputPathTextBox.TabIndex = 3;
            // 
            // _OutputPathLabel
            // 
            this._OutputPathLabel.AutoSize = true;
            this._OutputPathLabel.Location = new System.Drawing.Point(35, 116);
            this._OutputPathLabel.Name = "_OutputPathLabel";
            this._OutputPathLabel.Size = new System.Drawing.Size(67, 13);
            this._OutputPathLabel.TabIndex = 4;
            this._OutputPathLabel.Text = "Output Path:";
            // 
            // _OutputPathSelectionButton
            // 
            this._OutputPathSelectionButton.Location = new System.Drawing.Point(387, 129);
            this._OutputPathSelectionButton.Name = "_OutputPathSelectionButton";
            this._OutputPathSelectionButton.Size = new System.Drawing.Size(75, 23);
            this._OutputPathSelectionButton.TabIndex = 5;
            this._OutputPathSelectionButton.Text = "Browse";
            this._OutputPathSelectionButton.UseVisualStyleBackColor = true;
            this._OutputPathSelectionButton.Click += new System.EventHandler(this.OutputPathSelectionButton_Click);
            // 
            // _InputLanguageComboBox
            // 
            this._InputLanguageComboBox.FormattingEnabled = true;
            this._InputLanguageComboBox.Location = new System.Drawing.Point(526, 65);
            this._InputLanguageComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this._InputLanguageComboBox.Name = "_InputLanguageComboBox";
            this._InputLanguageComboBox.Size = new System.Drawing.Size(203, 21);
            this._InputLanguageComboBox.TabIndex = 6;
            this._InputLanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.InputLanguageComboBox_SelectedIndexChanged);
            // 
            // _InputLanguageLabel
            // 
            this._InputLanguageLabel.AutoSize = true;
            this._InputLanguageLabel.Location = new System.Drawing.Point(526, 47);
            this._InputLanguageLabel.Name = "_InputLanguageLabel";
            this._InputLanguageLabel.Size = new System.Drawing.Size(85, 13);
            this._InputLanguageLabel.TabIndex = 7;
            this._InputLanguageLabel.Text = "Input Language:";
            // 
            // _TranslateButton
            // 
            this._TranslateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._TranslateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TranslateButton.Location = new System.Drawing.Point(356, 740);
            this._TranslateButton.Name = "_TranslateButton";
            this._TranslateButton.Size = new System.Drawing.Size(106, 46);
            this._TranslateButton.TabIndex = 8;
            this._TranslateButton.Text = "Translate";
            this._TranslateButton.UseVisualStyleBackColor = true;
            this._TranslateButton.Click += new System.EventHandler(this.TranslateButton_Click);
            // 
            // _SettingsButton
            // 
            this._SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("_SettingsButton.Image")));
            this._SettingsButton.Location = new System.Drawing.Point(237, 820);
            this._SettingsButton.Margin = new System.Windows.Forms.Padding(3, 40, 3, 20);
            this._SettingsButton.Name = "_SettingsButton";
            this._SettingsButton.Size = new System.Drawing.Size(75, 46);
            this._SettingsButton.TabIndex = 9;
            this._SettingsButton.UseVisualStyleBackColor = true;
            this._SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // _ExitButton
            // 
            this._ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ExitButton.Location = new System.Drawing.Point(493, 820);
            this._ExitButton.Margin = new System.Windows.Forms.Padding(3, 40, 3, 20);
            this._ExitButton.Name = "_ExitButton";
            this._ExitButton.Size = new System.Drawing.Size(75, 46);
            this._ExitButton.TabIndex = 10;
            this._ExitButton.Text = "Exit";
            this._ExitButton.UseVisualStyleBackColor = true;
            this._ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // _BackgroundWorker
            // 
            this._BackgroundWorker.WorkerReportsProgress = true;
            this._BackgroundWorker.WorkerSupportsCancellation = true;
            this._BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this._BackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this._BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // PGDXTranslatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(808, 878);
            this.Controls.Add(this._ExitButton);
            this.Controls.Add(this._SettingsButton);
            this.Controls.Add(this._TranslateButton);
            this.Controls.Add(this._InputLanguageLabel);
            this.Controls.Add(this._InputLanguageComboBox);
            this.Controls.Add(this._OutputPathSelectionButton);
            this.Controls.Add(this._OutputPathLabel);
            this.Controls.Add(this._OutputPathTextBox);
            this.Controls.Add(this._InputFileSelectionButton);
            this.Controls.Add(this._InputFileSelectionLabal);
            this.Controls.Add(this._InputFileTextBox);
            this.Name = "PGDXTranslatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGDXTranslator";
            this.Shown += new System.EventHandler(this.PGDXTranslatorForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _InputFileTextBox;
        private System.Windows.Forms.Label _InputFileSelectionLabal;
        private System.Windows.Forms.Button _InputFileSelectionButton;
        private System.Windows.Forms.TextBox _OutputPathTextBox;
        private System.Windows.Forms.Label _OutputPathLabel;
        private System.Windows.Forms.Button _OutputPathSelectionButton;
        private System.Windows.Forms.ComboBox _InputLanguageComboBox;
        private System.Windows.Forms.Label _InputLanguageLabel;
        private System.Windows.Forms.Button _TranslateButton;
        private System.Windows.Forms.Button _SettingsButton;
        private System.Windows.Forms.OpenFileDialog _InputFileDialog;
        private System.Windows.Forms.Button _ExitButton;
        private System.ComponentModel.BackgroundWorker _BackgroundWorker;
    }
}

