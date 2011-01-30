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
            using (var fXmlDsigSign = new FXmlDsigSign())
            {
                fXmlDsigSign.ShowDialog();
            }
        }
        
        private void btnValidate_Click(object sender, EventArgs e)
        {
            using (var fXmlDsigVerify = new FXmlDsigVerify())
            {
                fXmlDsigVerify.ShowDialog();
            }
        }

        private void btnXAdESSign_Click(object sender, EventArgs e)
        {
            using (var fXadesSign = new FXadesSign())
            {
                fXadesSign.ShowDialog();
            }
        }

        private void btnXAdESVerify_Click(object sender, EventArgs e)
        {
            using (var fXadesVerify = new FXadesVerify())
            {
                fXadesVerify.ShowDialog();
            }
        }
    }
}