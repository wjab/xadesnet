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
            new FSign().ShowDialog();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            new FVerify().ShowDialog();
        }
    }
}