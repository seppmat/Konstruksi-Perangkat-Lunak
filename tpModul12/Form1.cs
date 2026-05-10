using System;
using System.Windows.Forms;

namespace tpModul12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int angka = Convert.ToInt32(textBox1.Text);

            Helper helper = new Helper();

            label1.Text = helper.CariTandaBilangan(angka);
        }
    }
}
