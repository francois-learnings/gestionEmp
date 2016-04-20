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
        bool isDrawing = false;
        Point start = new Point();
        int penSize = 2;

        //TODO
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

        /// <summary>
        ///Gestion evenements frappes clavier 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
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
            crayon = new Pen(Color.Black, penSize);

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
    }
}
