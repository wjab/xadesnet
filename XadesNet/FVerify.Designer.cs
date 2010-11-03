namespace XadesNet
{
    partial class FVerify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowseFileToValidate = new System.Windows.Forms.Button();
            this.txtFileToValidate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnBrowseFileToValidate
            // 
            this.btnBrowseFileToValidate.Location = new System.Drawing.Point(428, 33);
            this.btnBrowseFileToValidate.Name = "btnBrowseFileToValidate";
            this.btnBrowseFileToValidate.Size = new System.Drawing.Size(34, 23);
            this.btnBrowseFileToValidate.TabIndex = 10;
            this.btnBrowseFileToValidate.Text = "...";
            this.btnBrowseFileToValidate.UseVisualStyleBackColor = true;
            this.btnBrowseFileToValidate.Click += new System.EventHandler(this.btnBrowseFileToValidate_Click);
            // 
            // txtFileToValidate
            // 
            this.txtFileToValidate.Location = new System.Drawing.Point(15, 35);
            this.txtFileToValidate.Name = "txtFileToValidate";
            this.txtFileToValidate.Size = new System.Drawing.Size(407, 20);
            this.txtFileToValidate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Signature to Verify:";
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(391, 71);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 11;
            this.btnValidate.Text = "Verify";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // FValidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 106);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnBrowseFileToValidate);
            this.Controls.Add(this.txtFileToValidate);
            this.Controls.Add(this.label2);
            this.Name = "FValidate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FValidate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFileToValidate;
        private System.Windows.Forms.TextBox txtFileToValidate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.OpenFileDialog openDialog;
    }
}