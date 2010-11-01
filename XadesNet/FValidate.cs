using System;
using System.Windows.Forms;
using XadesNetLib.xmlDsig;

namespace XadesNet
{
    public partial class FValidate : Form
    {
        public FValidate()
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
            XmlDsig.Validate(txtFileToValidate.Text).Perform();
            MessageBox.Show("Signature is valid!");
        }
    }
}