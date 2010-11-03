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
            XmlDsigHelper.Verify(txtFileToValidate.Text).Perform();
            MessageBox.Show(@"Signature verified!");
        }
    }
}