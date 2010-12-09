using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using XadesNetLib.XmlDsig;
using XadesNetLib.Certificates;
using XadesNetLib.XmlDsig.Common;

namespace XadesNet
{
    public partial class FXmlDsigSign : Form
    {
        public FXmlDsigSign()
        {
            InitializeComponent();
        }

        private void btnFirmar_Click(object sender, EventArgs e)
        {
            var outputPath = txtOutputFile.Text;
            var selectedCertificate = GetSelectedCertificate();
            var selectedFormat = GetSelectedSignatureFormat();
            var inputPath = txtFileToSign.Text;
            var xpathToNodeToSign = txtNodeToSign.Text ?? "";
            if (!"".Equals(xpathToNodeToSign))
            {
                if (!xpathToNodeToSign.StartsWith("#")) xpathToNodeToSign = "#" + xpathToNodeToSign;
            }

            var howToSign =
                XmlDsigHelper.Sign(inputPath).Using(selectedCertificate).UsingFormat(selectedFormat)
                    .IncludingCertificateInSignature().IncludeTimestamp(chkIncludeTimestamp.Checked)
                    .NodeToSign(xpathToNodeToSign);
            if (chkAddProperty.Checked)
            {
                howToSign.WithProperty(txtPropertyName.Text, txtPropertyValue.Text, "http://xades.codeplex.com/#properties");
            }
            howToSign.SignToFile(outputPath);
            XmlDsigHelper.Verify(outputPath).Perform();

            MessageBox.Show(@"Signature created and verified successfully :)");
        }

        private XmlDsigSignatureFormat GetSelectedSignatureFormat()
        {
            return (XmlDsigSignatureFormat)cmbSignatureFormat.SelectedItem;
        }

        private X509Certificate2 GetSelectedCertificate()
        {
            return (X509Certificate2)cmbSignCertificate.SelectedItem;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var certificates = CertificatesHelper.GetCertificatesFrom(CertificateStore.My);
            cmbSignCertificate.DisplayMember = "Subject";
            cmbSignCertificate.DataSource = certificates;
            var formats = new List<XmlDsigSignatureFormat>
                              {
                                  XmlDsigSignatureFormat.Detached,
                                  XmlDsigSignatureFormat.Enveloped,
                                  XmlDsigSignatureFormat.Enveloping
                              };
            cmbSignatureFormat.DataSource = formats;
        }

        private void btnBrowseFileToSign_Click(object sender, EventArgs e)
        {
            openDialog.ShowDialog();
            txtFileToSign.Text = openDialog.FileName;
        }
        private void btnBrowseOutputFile_Click(object sender, EventArgs e)
        {
            saveDialog.ShowDialog();
            txtOutputFile.Text = saveDialog.FileName;
        }

        private void chkAddProperty_CheckedChanged(object sender, EventArgs e)
        {
            lblWithValue.Enabled = chkAddProperty.Checked;
            txtPropertyName.Enabled = chkAddProperty.Checked;
            txtPropertyValue.Enabled = chkAddProperty.Checked;
        }
    }
}