using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArdoiseMagique.cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Abonnement à la main pour le mouse wheel dans les textbox
            this.textBox1.MouseWheel += TextBox1_MouseWheel;
        }

        private void TextBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("code: " +e.KeyCode);
            Console.WriteLine("value: " +e.KeyValue);

            if (e.Alt && e.KeyCode == Keys.P)
            {
                MessageBox.Show("Plus epais !!!!!!");
            }
            if (e.Alt && e.KeyCode == Keys.M)
            {
                MessageBox.Show("Moins epais !!!!!!");
                
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            Graphics g;
            Pen crayon;
            if (e.Button == MouseButtons.Left)
            {
                g = Graphics.FromHwnd(this.Handle);
                crayon = new Pen(Color.Black);

                g.DrawEllipse(crayon, e.X, e.Y, 1, 1);
            }
            */

            bool enCours=false;
            Point start=new Point();
            Point end = new Point();

            if (e.Button == MouseButtons.Left)
            {
                enCours = true;
                start.X=e.X;
                start.Y = e.Y; 
            }
            if (e.Button == MouseButtons.Left)
            {
                end.X=e.X;
                end.Y = e.Y;
            }
            if (enCours)
            {
                Graphics g;
                Pen crayon;
                g = Graphics.FromHwnd(this.Handle);
                crayon = new Pen(Color.Black);

                g.DrawLine(crayon, start, end);
            }

        }
    }
}
