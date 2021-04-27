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
    
    public partial class Form1 : Form
    {
        List<string> a = new List<string>();
        int countturn = 0;
        bool turn = true;

        
        public Form1(string s1, string s2)
        {
            InitializeComponent();
            Ten(s1, s2);      
        }
        public void Ten(string s1, string s2)
        {
            label1.Text = s1 +" (X)";
            label2.Text = s2 + " (O)";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            countturn++;
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";             
            }
            else { b.Text = "O"; }
            a.Add(b.Name);
            turn = !turn;
            b.Enabled = false;
            Winner();          
           
        }

        // Duyet tat ca cac Controls trong Form, neu la button thi ep control ve button
        private void StopTick()
        {
            foreach(Control c in Controls)
            {
                if(c is Button)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }    
            }    
        }
        private void Winner()
        {
            bool iswinner = false;
            if (A1.Text == A2.Text && A2.Text == A3.Text && A1.Enabled == false)
            {
                iswinner = true;
            }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && B1.Enabled == false)
            {
                iswinner = true;
            }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && C1.Enabled == false)
            {
                iswinner = true;
            }
            else if (A1.Text == B2.Text && B2.Text == C3.Text && A1.Enabled == false)
            {
                iswinner = true;
            }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && A3.Enabled == false)
            {
                iswinner = true;
            }
            else if (A1.Text == B1.Text && B1.Text == C1.Text && A1.Enabled == false)
            {
                iswinner = true;
            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && A2.Enabled == false)
            {
                iswinner = true;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && A3.Enabled == false)
            {
                iswinner = true;
            }           
      
            if (iswinner)
            {
                StopTick();
                if (turn == true)
                {
                    MessageBox.Show(label2.Text+  " wins");
                    Olabel.Text = (Convert.ToInt32(Olabel.Text) + 1).ToString();                
                }
                else
                {
                    MessageBox.Show(label1.Text + " wins");
                    Xlabel.Text = (Convert.ToInt32(Xlabel.Text) + 1).ToString();
                }
                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        Button b = (Button)c;
                        b.Text = "";
                        b.Enabled = true;
                        countturn = 0;
                    }
                }
            }  
            else if(countturn == 9)
            {
                MessageBox.Show("Draw!!!");
                Dlabel.Text = (Convert.ToInt32(Dlabel.Text) + 1).ToString();
                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        Button b = (Button)c;
                        b.Text = "";
                        b.Enabled = true;
                        countturn = 0;
                    }
                }
            }
            
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
                foreach (Control c in Controls)
                {
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                    countturn = 0;
                    Xlabel.Text = "0";
                    Olabel.Text = "0";
                    Dlabel.Text = "0";
                }
                }
                    
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game của Huy", "Infor Game");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
               foreach(Control c in Controls)
                {
                    if(c is Button)
                    {
                        Button b = (Button)c;
                        if (a.Count != 0)
                        {
                            if (b.Name == a[a.Count - 1])
                            {
                                b.Text = "";
                                b.Enabled = true;
                                turn = !turn;
                                countturn--;
                                a.RemoveAt(a.Count - 1);
                                break;
                            }
                        }
                    }    
                }    
            }    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
