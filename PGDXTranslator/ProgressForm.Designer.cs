namespace PGDXTranslator {
    partial class ProgressForm {
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
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.CancelProgressButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLabel.Location = new System.Drawing.Point(105, 39);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(115, 26);
            this.ProgressLabel.TabIndex = 0;
            this.ProgressLabel.Text = "Working.";
            // 
            // CancelProgressButton
            // 
            this.CancelProgressButton.Location = new System.Drawing.Point(145, 92);
            this.CancelProgressButton.Name = "CancelProgressButton";
            this.CancelProgressButton.Size = new System.Drawing.Size(75, 23);
            this.CancelProgressButton.TabIndex = 1;
            this.CancelProgressButton.Text = "Cancel";
            this.CancelProgressButton.UseVisualStyleBackColor = true;
            this.CancelProgressButton.Click += new System.EventHandler(this.CancelProgressButton_Click);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 127);
            this.ControlBox = false;
            this.Controls.Add(this.CancelProgressButton);
            this.Controls.Add(this.ProgressLabel);
            this.MaximizeBox = false;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Button CancelProgressButton;
    }
}