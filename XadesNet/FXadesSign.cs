using System;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using XadesNetLib.XAdES;
using XadesNetLib.Certificates;

namespace XadesNet
{
    public partial class FXadesSign : Form
    {
        public FXadesSign()
        {
            InitializeComponent();
        }

        private void btnFirmar_Click(object sender, EventArgs e)
        {
            var outputPath = txtOutputFile.Text;
            var selectedCertificate = GetSelectedCertificate();
            var inputPath = txtFileToSign.Text;

            var howToSign =
                XadesHelper.Sign(inputPath).Using(selectedCertificate).
                    IncludingCertificateInSignature();
            if (chkAddProperty.Checked)
            {
                howToSign.WithProperty(txtPropertyName.Text, txtPropertyValue.Text, "http://xades.codeplex.com/#properties");
            }
            howToSign.SignToFile(outputPath);
            XadesHelper.Verify(outputPath).Perform();

            MessageBox.Show(@"Signature created and verified successfully :)");
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