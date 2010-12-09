using System;
using System.Windows.Forms;

namespace XadesNet
{
    public partial class FStart : Form
    {
        public FStart()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            new FXmlDsigSign().ShowDialog();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            new FXmlDsigVerify().ShowDialog();
        }

        private void btnXAdESSign_Click(object sender, EventArgs e)
        {
            new FXadesSign().ShowDialog();
        }

        private void btnXAdESVerify_Click(object sender, EventArgs e)
        {
            new FXadesVerify().ShowDialog();
        }
    }
}