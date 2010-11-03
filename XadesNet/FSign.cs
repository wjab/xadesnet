using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using XadesNetLib.XmlDsig;
using XadesNetLib.certificates;

namespace XadesNet
{
    public partial class FSign : Form
    {
        public FSign()
        {
            InitializeComponent();
        }

        private void btnFirmar_Click(object sender, EventArgs e)
        {
            var outputPath = txtOutputFile.Text;
            var selectedCertificate = (X509Certificate2)cmbSignCertificate.SelectedItem;
            var selectedFormat = (XmlDsigSignatureFormat)cmbSignatureFormat.SelectedItem;
            var inputPath = txtFileToSign.Text;

            XmlDsigHelper.Sign(inputPath).Using(selectedCertificate).UsingFormat(selectedFormat).
                IncludingCertificateInSignature().SignToFile(outputPath);
            XmlDsigHelper.Verify(outputPath).Perform();
            MessageBox.Show(@"Signature created and verified successfully :)");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var certificates = Certificates.GetCertificatesFrom(CertificateStore.My);
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
    }
}