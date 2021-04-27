using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cara
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Form1 f = new Form1(textBox1.Text, textBox2.Text);
                f.Show();               
                this.Hide();               
            }
        } 
        
    }
}
