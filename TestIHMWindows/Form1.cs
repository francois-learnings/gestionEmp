using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestIHMWindows
{
    public partial class MaFenetre : Form
    {
        public MaFenetre()
        {
            InitializeComponent();

        }

        private void btValider_Click(object sender, EventArgs e)
        {
            Console.WriteLine("J'ai cliquer sur le boutton");
            MessageBox.Show("Coucou !");
            DialogResult dr = MessageBox.Show("Ca va faire tout noir !",
                                                "Titre de ma boite",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Exclamation);
            Console.WriteLine(dr);
            if (dr==DialogResult.Yes)
            {
                MessageBox.Show("On continue ?!");
                this.lblReponseALaQuestion.Text = "Oui";
            }
            else if (dr==DialogResult.No)
            {
                MessageBox.Show("ok on arrète !");
                this.lblReponseALaQuestion.Text = "Non";
            }
        }

        private void MaFenetre_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Voulez-vous vraiment fermer le formulaire ?",
                            "Question",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if (dr==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            //la grosse blague:
            //e.Cancel = true;
        }
    }
}
