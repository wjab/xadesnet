using System;
using System.Windows.Forms;
using XadesNetLib.XmlDsig;

namespace XadesNet
{
    public partial class FVerify : Form
    {
        public FVerify()
        {
            InitializeComponent();
        }

        private void btnBrowseFileToValidate_Click(object sender, EventArgs e)
        {
            openDialog.ShowDialog();
            txtFileToValidate.Text = openDialog.FileName;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            var results = XmlDsigHelper.Verify(txtFileToValidate.Text).PerformAndGetResults();
            txtOriginalXml.Text = results.OriginalDocument.OuterXml;
            txtTimestamp.Text = results.Timestamp;
            txtCertificate.Text = results.SigningCertificate.Subject;
            MessageBox.Show(@"Signature verified!");
        }
    }
}