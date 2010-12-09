namespace XadesNet
{
    partial class FStart
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
            this.btnXMLDSIGSign = new System.Windows.Forms.Button();
            this.btnXMLDSIGVerify = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXAdESSign = new System.Windows.Forms.Button();
            this.btnXAdESVerify = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXMLDSIGSign
            // 
            this.btnXMLDSIGSign.Location = new System.Drawing.Point(21, 30);
            this.btnXMLDSIGSign.Name = "btnXMLDSIGSign";
            this.btnXMLDSIGSign.Size = new System.Drawing.Size(152, 38);
            this.btnXMLDSIGSign.TabIndex = 0;
            this.btnXMLDSIGSign.Text = "Sign";
            this.btnXMLDSIGSign.UseVisualStyleBackColor = true;
            this.btnXMLDSIGSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnXMLDSIGVerify
            // 
            this.btnXMLDSIGVerify.Location = new System.Drawing.Point(21, 74);
            this.btnXMLDSIGVerify.Name = "btnXMLDSIGVerify";
            this.btnXMLDSIGVerify.Size = new System.Drawing.Size(152, 40);
            this.btnXMLDSIGVerify.TabIndex = 1;
            this.btnXMLDSIGVerify.Text = "Verify";
            this.btnXMLDSIGVerify.UseVisualStyleBackColor = true;
            this.btnXMLDSIGVerify.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXMLDSIGSign);
            this.groupBox1.Controls.Add(this.btnXMLDSIGVerify);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 132);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XMLDSIG";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXAdESSign);
            this.groupBox2.Controls.Add(this.btnXAdESVerify);
            this.groupBox2.Location = new System.Drawing.Point(211, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 132);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XAdES";
            // 
            // btnXAdESSign
            // 
            this.btnXAdESSign.Location = new System.Drawing.Point(21, 30);
            this.btnXAdESSign.Name = "btnXAdESSign";
            this.btnXAdESSign.Size = new System.Drawing.Size(152, 38);
            this.btnXAdESSign.TabIndex = 0;
            this.btnXAdESSign.Text = "Sign";
            this.btnXAdESSign.UseVisualStyleBackColor = true;
            this.btnXAdESSign.Click += new System.EventHandler(this.btnXAdESSign_Click);
            // 
            // btnXAdESVerify
            // 
            this.btnXAdESVerify.Location = new System.Drawing.Point(21, 74);
            this.btnXAdESVerify.Name = "btnXAdESVerify";
            this.btnXAdESVerify.Size = new System.Drawing.Size(152, 40);
            this.btnXAdESVerify.TabIndex = 1;
            this.btnXAdESVerify.Text = "Verify";
            this.btnXAdESVerify.UseVisualStyleBackColor = true;
            this.btnXAdESVerify.Click += new System.EventHandler(this.btnXAdESVerify_Click);
            // 
            // FStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 151);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FStart";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXMLDSIGSign;
        private System.Windows.Forms.Button btnXMLDSIGVerify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXAdESSign;
        private System.Windows.Forms.Button btnXAdESVerify;
    }
}