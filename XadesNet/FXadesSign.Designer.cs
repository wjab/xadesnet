namespace XadesNet
{
    partial class FXadesSign
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
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.chkAddProperty = new System.Windows.Forms.CheckBox();
            this.txtPropertyValue = new System.Windows.Forms.TextBox();
            this.lblWithValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNodeToSign = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSign
            // 
            this.btnSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSign.Location = new System.Drawing.Point(436, 360);
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
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Signature Certificate";
            // 
            // cmbSignCertificate
            // 
            this.cmbSignCertificate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSignCertificate.FormattingEnabled = true;
            this.cmbSignCertificate.Location = new System.Drawing.Point(21, 51);
            this.cmbSignCertificate.Name = "cmbSignCertificate";
            this.cmbSignCertificate.Size = new System.Drawing.Size(203, 21);
            this.cmbSignCertificate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File to Sign:";
            // 
            // txtFileToSign
            // 
            this.txtFileToSign.Location = new System.Drawing.Point(26, 52);
            this.txtFileToSign.Name = "txtFileToSign";
            this.txtFileToSign.Size = new System.Drawing.Size(407, 20);
            this.txtFileToSign.TabIndex = 6;
            // 
            // btnBrowseFileToSign
            // 
            this.btnBrowseFileToSign.Location = new System.Drawing.Point(439, 50);
            this.btnBrowseFileToSign.Name = "btnBrowseFileToSign";
            this.btnBrowseFileToSign.Size = new System.Drawing.Size(34, 23);
            this.btnBrowseFileToSign.TabIndex = 7;
            this.btnBrowseFileToSign.Text = "...";
            this.btnBrowseFileToSign.UseVisualStyleBackColor = true;
            this.btnBrowseFileToSign.Click += new System.EventHandler(this.btnBrowseFileToSign_Click);
            // 
            // btnBrowseOutputFile
            // 
            this.btnBrowseOutputFile.Location = new System.Drawing.Point(439, 103);
            this.btnBrowseOutputFile.Name = "btnBrowseOutputFile";
            this.btnBrowseOutputFile.Size = new System.Drawing.Size(34, 23);
            this.btnBrowseOutputFile.TabIndex = 10;
            this.btnBrowseOutputFile.Text = "...";
            this.btnBrowseOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFile.Click += new System.EventHandler(this.btnBrowseOutputFile_Click);
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(26, 105);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(407, 20);
            this.txtOutputFile.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output file:";
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Enabled = false;
            this.txtPropertyName.Location = new System.Drawing.Point(124, 89);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(129, 20);
            this.txtPropertyName.TabIndex = 14;
            // 
            // chkAddProperty
            // 
            this.chkAddProperty.AutoSize = true;
            this.chkAddProperty.Location = new System.Drawing.Point(21, 89);
            this.chkAddProperty.Name = "chkAddProperty";
            this.chkAddProperty.Size = new System.Drawing.Size(87, 17);
            this.chkAddProperty.TabIndex = 15;
            this.chkAddProperty.Text = "Add Property";
            this.chkAddProperty.UseVisualStyleBackColor = true;
            this.chkAddProperty.CheckedChanged += new System.EventHandler(this.chkAddProperty_CheckedChanged);
            // 
            // txtPropertyValue
            // 
            this.txtPropertyValue.Enabled = false;
            this.txtPropertyValue.Location = new System.Drawing.Point(336, 90);
            this.txtPropertyValue.Name = "txtPropertyValue";
            this.txtPropertyValue.Size = new System.Drawing.Size(129, 20);
            this.txtPropertyValue.TabIndex = 16;
            // 
            // lblWithValue
            // 
            this.lblWithValue.AutoSize = true;
            this.lblWithValue.Enabled = false;
            this.lblWithValue.Location = new System.Drawing.Point(266, 93);
            this.lblWithValue.Name = "lblWithValue";
            this.lblWithValue.Size = new System.Drawing.Size(59, 13);
            this.lblWithValue.TabIndex = 17;
            this.lblWithValue.Text = "With Value";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNodeToSign);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFileToSign);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBrowseFileToSign);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOutputFile);
            this.groupBox1.Controls.Add(this.btnBrowseOutputFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 204);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Signature";
            // 
            // txtNodeToSign
            // 
            this.txtNodeToSign.Location = new System.Drawing.Point(26, 161);
            this.txtNodeToSign.Name = "txtNodeToSign";
            this.txtNodeToSign.Size = new System.Drawing.Size(407, 20);
            this.txtNodeToSign.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Node To Sign (Id of node to Sign):";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblWithValue);
            this.groupBox2.Controls.Add(this.cmbSignCertificate);
            this.groupBox2.Controls.Add(this.txtPropertyValue);
            this.groupBox2.Controls.Add(this.chkAddProperty);
            this.groupBox2.Controls.Add(this.txtPropertyName);
            this.groupBox2.Location = new System.Drawing.Point(12, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 129);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // FXadesSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 395);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSign);
            this.Name = "FXadesSign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XAdES Signature";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.CheckBox chkAddProperty;
        private System.Windows.Forms.TextBox txtPropertyValue;
        private System.Windows.Forms.Label lblWithValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNodeToSign;
    }
}

