using GestionEmployes.BLL;
using GestionEmployes.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IhmServices.cs
{
    public partial class FrmServices : Form
    {
        private ModesEcran modeEnCours;

        public ModesEcran ModeEnCours
        {
            get { return modeEnCours; }
            set
            {
                modeEnCours = value;
                //C'est le bon moment pour mettre a jour l'activation/desactivation des controles
                this.lbService.Enabled = (((ModesEcran)this.lbService.Tag) & modeEnCours) == modeEnCours;
                this.tbCode.Enabled = (((ModesEcran)this.tbCode.Tag) & modeEnCours) == modeEnCours;
                this.tbLibelle.Enabled = (((ModesEcran)this.tbLibelle.Tag) & modeEnCours) == modeEnCours;
                this.btExporter.Enabled = (((ModesEcran)this.btExporter.Tag) & modeEnCours) == modeEnCours;
                this.btImporter.Enabled = (((ModesEcran)this.btImporter.Tag) & modeEnCours) == modeEnCours;
                this.btAjouter.Enabled = (((ModesEcran)this.btAjouter.Tag) & modeEnCours) == modeEnCours;
                this.btSupprimer.Enabled = (((ModesEcran)this.btSupprimer.Tag) & modeEnCours) == modeEnCours;
                this.btValider.Enabled = (((ModesEcran)this.btValider.Tag) & modeEnCours) == modeEnCours;
                this.btAnnuler.Enabled = (((ModesEcran)this.btAnnuler.Tag) & modeEnCours) == modeEnCours;
                this.btQuitter.Enabled = (((ModesEcran)this.btQuitter.Tag) & modeEnCours) == modeEnCours;

                switch (modeEnCours)
                {
                    case ModesEcran.Vide:
                        break;
                    case ModesEcran.Consultation:
                        break;
                    case ModesEcran.Ajout:
                        this.tbCode.Text = string.Empty;
                        this.tbLibelle.Text = string.Empty;
                        this.tbCode.Focus();
                        break;
                    case ModesEcran.Modification:
                        break;
                    default:
                        break;
                }

            }
        }

        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        public FrmServices()
        {
            InitializeComponent();

            this.lbService.Tag = ModesEcran.Consultation;
            this.tbCode.Tag = ModesEcran.Ajout;
            this.tbLibelle.Tag = ModesEcran.Consultation | ModesEcran.Ajout | ModesEcran.Modification;
            this.btExporter.Tag = ModesEcran.Consultation;
            this.btImporter.Tag = ModesEcran.Vide | ModesEcran.Consultation;
            this.btAjouter.Tag = ModesEcran.Consultation | ModesEcran.Ajout| ModesEcran.Vide;
            this.btSupprimer.Tag = ModesEcran.Consultation;
            this.btValider.Tag = ModesEcran.Ajout | ModesEcran.Modification;
            this.btAnnuler.Tag = ModesEcran.Ajout | ModesEcran.Modification;
            this.btQuitter.Tag = ModesEcran.Vide | ModesEcran.Consultation;
        }

        /// <summary>
        /// Actions bouton "Ajouter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAjouter_Click(object sender, EventArgs e)
        {
            this.ModeEnCours = ModesEcran.Ajout;
        }

        /// <summary>
        /// Actions au chargement de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IhmServices_Load(object sender, EventArgs e)
        {
            this.lbService.DataSource = MgrService.getInstance().Serviceslist;
            this.ModeEnCours = ModesEcran.Consultation;

            Service serviceSelectionne = (Service)this.lbService.SelectedItem;
            this.tbCode.Text = serviceSelectionne.Code;
            this.tbLibelle.Text = serviceSelectionne.Libelle;
        }

        /// <summary>
        /// Actions bouton "Annuler"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAnnuler_Click(object sender, EventArgs e)
        {
            switch (this.ModeEnCours)
            {
                case ModesEcran.Vide:
                    break;
                case ModesEcran.Consultation:
                    break;
                case ModesEcran.Ajout:
                    this.errorProvider.SetError(tbCode, string.Empty);
                    this.errorProvider.SetError(tbLibelle, string.Empty);
                    if (MgrService.getInstance().Serviceslist.Count == 0)
                    {
                        this.ModeEnCours = ModesEcran.Vide;
                    }
                    else
                    {
                        this.ModeEnCours = ModesEcran.Consultation;
                        ReloadListe();
                    }
                    break;
                case ModesEcran.Modification:
                    break;
                default:
                    break;
            }
        }

        private void btQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSupprimer_Click(object sender, EventArgs e)
        {
            switch (this.ModeEnCours)
            {
                case ModesEcran.Vide:
                    break;
                case ModesEcran.Consultation:
                    //Delete the service here
                    MgrService.getInstance().SupprimerService((Service)this.lbService.SelectedItem);
                    this.ClearTB();
                    this.ReloadListe();
                    if (MgrService.getInstance().Serviceslist.Count == 0)
                    {
                        this.ModeEnCours = ModesEcran.Vide;
                    }
                    else
                    {
                        this.ModeEnCours = ModesEcran.Consultation;
                    }
                    break;
                case ModesEcran.Ajout:
                    break;
                case ModesEcran.Modification:
                    break;
                default:
                    break;
            }
        }

        private void lbService_SelectedIndexChanged(object sender, EventArgs e)
        {

            Service selecectedItem = (Service)this.lbService.SelectedItem;
            if (selecectedItem != null)
            {
                this.tbCode.Text = selecectedItem.Code;
                this.tbLibelle.Text = selecectedItem.Libelle;

            }        }


        private void btValider_Click(object sender, EventArgs e)
        {
                this.errorProvider.SetError(tbCode, string.Empty);
                this.errorProvider.SetError(tbLibelle, string.Empty);
            try
            {
                MgrService.getInstance().AjouterService(tbCode.Text, tbLibelle.Text);
                ClearTB();
                ReloadListe();

            }
            catch (ApplicationException ae)
            {
                if (ae.TargetSite.Name == "verifCode")
                {
                    this.errorProvider.SetError(tbCode, ae.Message);

                }
                if (ae.TargetSite.Name == "verifLibelle")
                {
                    this.errorProvider.SetError(tbLibelle, ae.Message);
                }

            }
        }

        #region utilitaires
        private void ReloadListe()
        {
            this.lbService.DataSource = null;
            this.lbService.DataSource = MgrService.getInstance().Serviceslist;
        }

        private void ClearTB()
        {
            this.tbCode.Text = string.Empty;
            this.tbLibelle.Text = string.Empty;
        }
        #endregion
    }
}
