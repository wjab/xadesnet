namespace XadesNet
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSign = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSignCertificate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileToSign = new System.Windows.Forms.TextBox();
            this.btnBrowseFileToSign = new System.Windows.Forms.Button();
            this.btnBrowseOutputFile = new System.Windows.Forms.Button();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(392, 245);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 23);
            this.btnSign.TabIndex = 2;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnFirmar_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Signature Certificate";
            // 
            // cmbSignCertificate
            // 
            this.cmbSignCertificate.FormattingEnabled = true;
            this.cmbSignCertificate.Location = new System.Drawing.Point(20, 177);
            this.cmbSignCertificate.Name = "cmbSignCertificate";
            this.cmbSignCertificate.Size = new System.Drawing.Size(203, 21);
            this.cmbSignCertificate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File to Sign:";
            // 
            // txtFileToSign
            // 
            this.txtFileToSign.Location = new System.Drawing.Point(20, 48);
            this.txtFileToSign.Name = "txtFileToSign";
            this.txtFileToSign.Size = new System.Drawing.Size(407, 20);
            this.txtFileToSign.TabIndex = 6;
            // 
            // btnBrowseFileToSign
            // 
            this.btnBrowseFileToSign.Location = new System.Drawing.Point(433, 46);
            this.btnBrowseFileToSign.Name = "btnBrowseFileToSign";
            this.btnBrowseFileToSign.Size = new System.Drawing.Size(34, 23);
            this.btnBrowseFileToSign.TabIndex = 7;
            this.btnBrowseFileToSign.Text = "...";
            this.btnBrowseFileToSign.UseVisualStyleBackColor = true;
            this.btnBrowseFileToSign.Click += new System.EventHandler(this.btnBrowseFileToSign_Click);
            // 
            // btnBrowseOutputFile
            // 
            this.btnBrowseOutputFile.Location = new System.Drawing.Point(433, 101);
            this.btnBrowseOutputFile.Name = "btnBrowseOutputFile";
            this.btnBrowseOutputFile.Size = new System.Drawing.Size(34, 23);
            this.btnBrowseOutputFile.TabIndex = 10;
            this.btnBrowseOutputFile.Text = "...";
            this.btnBrowseOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFile.Click += new System.EventHandler(this.btnBrowseOutputFile_Click);
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(20, 103);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(407, 20);
            this.txtOutputFile.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output file:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 280);
            this.Controls.Add(this.btnBrowseOutputFile);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseFileToSign);
            this.Controls.Add(this.txtFileToSign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSignCertificate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSign);
            this.Name = "Form1";
            this.Text = "Firma XMLDSig";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSignCertificate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileToSign;
        private System.Windows.Forms.Button btnBrowseFileToSign;
        private System.Windows.Forms.Button btnBrowseOutputFile;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.Label label3;
    }
}

