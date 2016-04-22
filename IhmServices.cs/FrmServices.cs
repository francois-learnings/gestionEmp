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
        #region Gestion de l'etat du formulaire
        private ModesEcran modeEnCours;

        public ModesEcran ModeEnCours
        {
            get { return modeEnCours; }
            set
            {
                //Si mode = consultation, on verifie s'il y a des services.
                //sinon, on bascule automatiquement en mode Vide
                /* TODO
                if (this.ModeEnCours==ModesEcran.Consultation &&
                    MgrService.getInstance().Serviceslist.Count == 0)
                {
                    this.ModeEnCours = ModesEcran.Vide;
                }
                else
                {
                    modeEnCours = value;
                }
                Console.WriteLine(ModeEnCours);
                Console.WriteLine(MgrService.getInstance().Serviceslist.Any());
                */

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

                //TODO factoriser des truc la dedans ou l'enlever
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
        #endregion

        #region Chargement
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
        /// Actions au chargement de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IhmServices_Load(object sender, EventArgs e)
        {
            ReloadListe();
            this.ModeEnCours = ModesEcran.Consultation;

            /* //Code redondant avec les lb_selected value(index)_change()
            Service serviceSelectionne = (Service)this.lbService.SelectedItem;
            this.tbCode.Text = serviceSelectionne.Code;
            this.tbLibelle.Text = serviceSelectionne.Libelle;
            */
        }

        #endregion

        #region Verification des saisies
        private void tbCode_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider.SetError(tbCode, string.Empty);
            try
            {
                MgrService.getInstance().VerifierCode(this.tbCode.Text);

            }
            catch (ApplicationException ae)
            {
                this.errorProvider.SetError(tbCode, ae.Message);
            }
        }

        private void tbLibelle_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider.SetError(tbLibelle, string.Empty);
            try
            {
                MgrService.getInstance().VerifierLibelle(tbLibelle.Text);

            }
            catch (ApplicationException ae)
            {
                this.errorProvider.SetError(tbLibelle, ae.Message);
            }
        }
        #endregion

        #region Gestion des actions
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
        /// Actions bouton Valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btValider_Click(object sender, EventArgs e)
        {
            switch (ModeEnCours)
            {
                case ModesEcran.Vide:
                    break;
                case ModesEcran.Consultation:
                    break;
                case ModesEcran.Ajout:
                    this.ValidateChildren();
                    if (this.errorProvider.GetError(tbCode) != string.Empty)
                    {
                            this.errorProvider.SetError(tbCode, this.errorProvider.GetError(tbCode));
                    }
                    else if (this.errorProvider.GetError(tbLibelle) != string.Empty)
                    {
                            this.errorProvider.SetError(tbLibelle, this.errorProvider.GetError(tbLibelle));
                    }
                    else
                    {
                        Service nouveauService = null;
                        try
                        {
                            MgrService.getInstance().AjouterService(tbCode.Text, tbLibelle.Text);
                            nouveauService = MgrService.getInstance().ObtenirService(tbCode.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearTB();
                        ReloadListe();
                        this.lbService.SelectedItem = nouveauService;
                        this.tbLibelle.Modified = false;
                        this.ModeEnCours = ModesEcran.Consultation;
                    }
                    break;
                case ModesEcran.Modification:
                    this.ValidateChildren(ValidationConstraints.Enabled);
                    if (this.errorProvider.GetError(tbLibelle) != string.Empty)
                    {
                        //MessageBox.Show(this.errorProvider.GetError(tbLibelle), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else {
                        try
                        {
                            MgrService.getInstance().ModifierService((Service)this.lbService.SelectedItem,
                                                                        this.tbLibelle.Text);
                        
                        }
                        catch (ApplicationException ae)
                        {
                            //TODO handle error more cleanly
                            Console.WriteLine(ae.Message); ;
                        }
                        ClearTB();
                        ReloadListe();
                        this.tbLibelle.Modified = false;
                        this.ModeEnCours = ModesEcran.Consultation;
                    }
                    break;
                default:
                    break;
            }
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
                    /* //Code deplacer dans la methode reloadListe()
                    this.errorProvider.SetError(tbCode, string.Empty);
                    this.errorProvider.SetError(tbLibelle, string.Empty);
                    */
                    if (MgrService.getInstance().Serviceslist.Count == 0)
                    {
                        this.ModeEnCours = ModesEcran.Vide;
                    }
                    else
                    {
                        ReloadListe();
                        this.tbLibelle.Modified = false;
                        this.ModeEnCours = ModesEcran.Consultation;
                    }
                    break;
                case ModesEcran.Modification:
                    // code factorisé dans reloadListe => apparition icone erreur brièvement
                    //this.errorProvider.SetError(tbCode, string.Empty);
                    //this.errorProvider.SetError(tbLibelle, string.Empty);
                    ReloadListe();
                    this.tbLibelle.Modified = false;
                    this.ModeEnCours = ModesEcran.Consultation;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Actions bouton "Quitter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Action bouton "Supprimer"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSupprimer_Click(object sender, EventArgs e)
        {
            switch (this.ModeEnCours)
            {
                case ModesEcran.Vide:
                    break;
                case ModesEcran.Consultation:
                    try
                    {
                        MgrService.getInstance().SupprimerService((Service)this.lbService.SelectedItem);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.ClearTB();
                    this.ReloadListe();
                    this.modeEnCours = ModesEcran.Consultation;
                    //TODO - factoriser dans le setter de modeEnCours
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

        private void lbService_SelectedValueChanged(object sender, EventArgs e)
        {
            Service selecectedItem = (Service)this.lbService.SelectedItem;
            if (selecectedItem != null)
            {
                this.tbCode.Text = selecectedItem.Code;
                this.tbLibelle.Text = selecectedItem.Libelle;
            }
            else
            {
                this.tbCode.Text = String.Empty;
                this.tbLibelle.Text = String.Empty;
            }

        }

        private void tbLibelle_ModifiedChanged(object sender, EventArgs e)
        {
            switch (ModeEnCours)
            {
                case ModesEcran.Vide:
                    break;
                case ModesEcran.Consultation:

                    this.ModeEnCours = ModesEcran.Modification;
                    break;
                case ModesEcran.Ajout:
                    break;
                case ModesEcran.Modification:
                    break;
                default:
                    break;
            }
        }

        private void btExporter_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string pathToWrite = null;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                pathToWrite = fbd.SelectedPath;
                //Console.WriteLine(path);
            }

            if (pathToWrite != string.Empty)
            {
                pathToWrite += "\\Export.ext";
                Console.WriteLine(pathToWrite);
                String[] valuesToWrite = new string[MgrService.getInstance().Serviceslist.Count];
                //Console.WriteLine( MgrService.getInstance().Serviceslist[0]);

                for (int i = 1; i < MgrService.getInstance().Serviceslist.Count; i++)
                {
                    valuesToWrite[i] = MgrService.getInstance().Serviceslist[i].ToString();
                }

                foreach (string line in valuesToWrite)
                {
                    Console.WriteLine(line);
                }
                System.IO.File.WriteAllLines(pathToWrite, valuesToWrite);
            }
            
        }
        #endregion

        #region utilitaires
        private void ReloadListe()
        {
            this.errorProvider.SetError(tbCode, string.Empty);
            this.errorProvider.SetError(tbLibelle, string.Empty);
            MgrService.getInstance().Trier(CritereService.Code);
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
