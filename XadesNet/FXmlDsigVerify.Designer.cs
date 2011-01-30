namespace XadesNet
{
    partial class FXmlDsigVerify
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
            this.txtOriginalXml = new System.Windows.Forms.TextBox();
            this.txtCertificate = new System.Windows.Forms.TextBox();
            this.txtTimestamp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBrowseFileToValidate
            // 
            this.btnBrowseFileToValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txtFileToValidate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Signature to Verify:";
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(387, 62);
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
            // txtOriginalXml
            // 
            this.txtOriginalXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOriginalXml.Location = new System.Drawing.Point(15, 118);
            this.txtOriginalXml.Multiline = true;
            this.txtOriginalXml.Name = "txtOriginalXml";
            this.txtOriginalXml.Size = new System.Drawing.Size(447, 186);
            this.txtOriginalXml.TabIndex = 12;
            // 
            // txtCertificate
            // 
            this.txtCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertificate.Location = new System.Drawing.Point(108, 310);
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Size = new System.Drawing.Size(354, 20);
            this.txtCertificate.TabIndex = 13;
            // 
            // txtTimestamp
            // 
            this.txtTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimestamp.Location = new System.Drawing.Point(108, 336);
            this.txtTimestamp.Name = "txtTimestamp";
            this.txtTimestamp.Size = new System.Drawing.Size(354, 20);
            this.txtTimestamp.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Original Xml:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Certificate Name:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Timestamp:";
            // 
            // FXmlDsigVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 382);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimestamp);
            this.Controls.Add(this.txtCertificate);
            this.Controls.Add(this.txtOriginalXml);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnBrowseFileToValidate);
            this.Controls.Add(this.txtFileToValidate);
            this.Controls.Add(this.label2);
            this.Name = "FXmlDsigVerify";
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
        private System.Windows.Forms.TextBox txtOriginalXml;
        private System.Windows.Forms.TextBox txtCertificate;
        private System.Windows.Forms.TextBox txtTimestamp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}