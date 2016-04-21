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
        #region attributs
        bool isDrawing = false;
        Point start = new Point();
        int penSize = 2;
        Color color;

        int color_red = 0;
        int color_green = 0;
        int color_blue = 0;

        int cpt_red = 0;
        int cpt_green = 0;
        int cpt_blue= 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
            //Abonnement à la main pour le mouse wheel dans les textbox
            this.textBox2.MouseWheel += TextBox2_MouseWheel;
            this.textBox3.MouseWheel += TextBox3_MouseWheel;
            this.textBox4.MouseWheel += TextBox4_MouseWheel;
            this.color = coloring();
        }

        #region Color Settings
        private Color coloring()
        {
            return Color.FromArgb(color_red, color_green, color_blue);
        }

        /// <summary>
        /// set the red color percentage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox2_MouseWheel(object sender, MouseEventArgs e)
        {
            int wheel = e.Delta/120;
            if (cpt_red + wheel >= 0 && cpt_red + wheel <= 100)
            {
                cpt_red += wheel;
            }
            textBox2.Text = cpt_red.ToString() + "%";

            if (cpt_red > 0)
            {
                color_red = 255 * cpt_red / 100;
                color = coloring(); 
            }
        }

        /// <summary>
        /// set the green color percentage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox3_MouseWheel(object sender, MouseEventArgs e)
        {
            int wheel = e.Delta / 120;
            if (cpt_green + wheel >= 0 && cpt_green + wheel <= 100)
            {
                cpt_green += wheel;
            }
            textBox3.Text = cpt_green.ToString() + "%";

            if (cpt_green > 0)
            {
                color_green = 255 * cpt_green / 100;
                color = coloring();
            }
        }

        /// <summary>
        /// set the blue color percentage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox4_MouseWheel(object sender, MouseEventArgs e)
        {
            int wheel = e.Delta / 120;
            if (cpt_blue + wheel >= 0 && cpt_blue + wheel <= 100)
            {
                cpt_blue += wheel;
            }
            textBox4.Text = cpt_blue.ToString() + "%";

            if (cpt_blue > 0)
            {
                color_blue = 255 * cpt_blue / 100;
                color = coloring();
            }
        }
        #endregion

        /// <summary>
        ///Gestion evenements frappes clavier 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyData);
            if (e.Alt && e.KeyCode == Keys.P)
            {
                //MessageBox.Show("Plus epais !!!!!!");
                penSize += 2;
            }
            if (e.Alt && e.KeyCode == Keys.M)
            {
                //MessageBox.Show("Moins epais !!!!!!");
                penSize -= 2;
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.F1)
            {
                color_red = 255;
                color_green = 0;
                color_blue = 0;
                color = coloring();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.F2)
            {
                color_red = 0;
                color_green = 255;
                color_blue = 0;
                color = coloring();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.F3)
            {
                color_red = 0;
                color_green = 0;
                color_blue = 255;
                color = coloring();
            }
        }

        #region draw w/ mouse

        /// <summary>
        /// Deal w/ the movement of the mouse and trigger the drawing and the change of start_coordinate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                DrawLine(start, e.Location);
                start = e.Location;
            }
        }

        /// <summary>
        /// Actually draw the line
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void DrawLine(Point start, Point end)
        {
            Graphics g;
            Pen crayon;
            g = Graphics.FromHwnd(this.Handle);
            crayon = new Pen(color, penSize);

            g.DrawLine(crayon, start, end);
        }

        /// <summary>
        /// set the start point coordinates from the line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            start.X = e.X;
            start.Y = e.Y; 
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }
        #endregion

        #region Focus textboxes
        /*
        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            this.textBox2.Focus();
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            this.textBox3.Focus();
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            this.textBox4.Focus();
        }
        */
        //Factorisation
        private void textBox_X_MouseHover(object sender, EventArgs e)
        {
            ((TextBox)sender).Focus();
        }
        #endregion

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Graphics g;
            g = Graphics.FromHwnd(this.Handle);
            g.Clear(this.BackColor);
        }
    }
}
