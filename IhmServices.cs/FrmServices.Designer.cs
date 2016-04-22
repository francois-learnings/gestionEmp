namespace IhmServices.cs
{
    partial class FrmServices
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbService = new System.Windows.Forms.ListBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.lblCodeService = new System.Windows.Forms.Label();
            this.tbLibelle = new System.Windows.Forms.TextBox();
            this.lblLibelleService = new System.Windows.Forms.Label();
            this.btImporter = new System.Windows.Forms.Button();
            this.btExporter = new System.Windows.Forms.Button();
            this.btAjouter = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btQuitter = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.btValider = new System.Windows.Forms.Button();
            this.btSupprimer = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbService
            // 
            this.lbService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbService.FormattingEnabled = true;
            this.lbService.Location = new System.Drawing.Point(12, 12);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(551, 212);
            this.lbService.TabIndex = 0;
            this.lbService.SelectedValueChanged += new System.EventHandler(this.lbService_SelectedValueChanged);
            // 
            // tbCode
            // 
            this.tbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbCode.Location = new System.Drawing.Point(69, 285);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(100, 20);
            this.tbCode.TabIndex = 1;
            this.tbCode.Validating += new System.ComponentModel.CancelEventHandler(this.tbCode_Validating);
            // 
            // lblCodeService
            // 
            this.lblCodeService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCodeService.AutoSize = true;
            this.lblCodeService.Location = new System.Drawing.Point(25, 288);
            this.lblCodeService.Name = "lblCodeService";
            this.lblCodeService.Size = new System.Drawing.Size(38, 13);
            this.lblCodeService.TabIndex = 2;
            this.lblCodeService.Text = "Code :";
            // 
            // tbLibelle
            // 
            this.tbLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLibelle.Location = new System.Drawing.Point(298, 285);
            this.tbLibelle.Name = "tbLibelle";
            this.tbLibelle.Size = new System.Drawing.Size(258, 20);
            this.tbLibelle.TabIndex = 3;
            this.tbLibelle.ModifiedChanged += new System.EventHandler(this.tbLibelle_ModifiedChanged);
            this.tbLibelle.Validating += new System.ComponentModel.CancelEventHandler(this.tbLibelle_Validating);
            // 
            // lblLibelleService
            // 
            this.lblLibelleService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLibelleService.AutoSize = true;
            this.lblLibelleService.Location = new System.Drawing.Point(249, 288);
            this.lblLibelleService.Name = "lblLibelleService";
            this.lblLibelleService.Size = new System.Drawing.Size(43, 13);
            this.lblLibelleService.TabIndex = 4;
            this.lblLibelleService.Text = "Libellé :";
            // 
            // btImporter
            // 
            this.btImporter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btImporter.Image = global::IhmServices.cs.Properties.Resources.import;
            this.btImporter.Location = new System.Drawing.Point(6, 3);
            this.btImporter.Name = "btImporter";
            this.btImporter.Size = new System.Drawing.Size(50, 49);
            this.btImporter.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btImporter, "Importer");
            this.btImporter.UseVisualStyleBackColor = true;
            // 
            // btExporter
            // 
            this.btExporter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btExporter.Image = global::IhmServices.cs.Properties.Resources.export;
            this.btExporter.Location = new System.Drawing.Point(69, 3);
            this.btExporter.Name = "btExporter";
            this.btExporter.Size = new System.Drawing.Size(50, 49);
            this.btExporter.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btExporter, "Exporter");
            this.btExporter.UseVisualStyleBackColor = true;
            this.btExporter.Click += new System.EventHandler(this.btExporter_Click);
            // 
            // btAjouter
            // 
            this.btAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btAjouter.Image = global::IhmServices.cs.Properties.Resources.ajouter;
            this.btAjouter.Location = new System.Drawing.Point(132, 3);
            this.btAjouter.Name = "btAjouter";
            this.btAjouter.Size = new System.Drawing.Size(50, 49);
            this.btAjouter.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btAjouter, "Ajouter un service");
            this.btAjouter.UseVisualStyleBackColor = true;
            this.btAjouter.Click += new System.EventHandler(this.btAjouter_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.btQuitter, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btAnnuler, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btValider, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSupprimer, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btImporter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btAjouter, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btExporter, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(120, 328);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 55);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // btQuitter
            // 
            this.btQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btQuitter.Image = global::IhmServices.cs.Properties.Resources.quitter;
            this.btQuitter.Location = new System.Drawing.Point(386, 3);
            this.btQuitter.Name = "btQuitter";
            this.btQuitter.Size = new System.Drawing.Size(50, 49);
            this.btQuitter.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btQuitter, "Quitter");
            this.btQuitter.UseVisualStyleBackColor = true;
            this.btQuitter.Click += new System.EventHandler(this.btQuitter_Click);
            // 
            // btAnnuler
            // 
            this.btAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btAnnuler.Image = global::IhmServices.cs.Properties.Resources.annuler;
            this.btAnnuler.Location = new System.Drawing.Point(321, 3);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(50, 49);
            this.btAnnuler.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btAnnuler, "Annuler");
            this.btAnnuler.UseVisualStyleBackColor = true;
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
            // 
            // btValider
            // 
            this.btValider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btValider.Image = global::IhmServices.cs.Properties.Resources.valider;
            this.btValider.Location = new System.Drawing.Point(258, 3);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(50, 49);
            this.btValider.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btValider, "Valider");
            this.btValider.UseVisualStyleBackColor = true;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // btSupprimer
            // 
            this.btSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btSupprimer.Image = global::IhmServices.cs.Properties.Resources.supprimer;
            this.btSupprimer.Location = new System.Drawing.Point(195, 3);
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.Size = new System.Drawing.Size(50, 49);
            this.btSupprimer.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btSupprimer, "Supprimer un service");
            this.btSupprimer.UseVisualStyleBackColor = true;
            this.btSupprimer.Click += new System.EventHandler(this.btSupprimer_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // FrmServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 394);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblLibelleService);
            this.Controls.Add(this.tbLibelle);
            this.Controls.Add(this.lblCodeService);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.lbService);
            this.Name = "FrmServices";
            this.Text = "Services";
            this.Load += new System.EventHandler(this.IhmServices_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbService;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label lblCodeService;
        private System.Windows.Forms.TextBox tbLibelle;
        private System.Windows.Forms.Label lblLibelleService;
        private System.Windows.Forms.Button btImporter;
        private System.Windows.Forms.Button btExporter;
        private System.Windows.Forms.Button btAjouter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btQuitter;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btSupprimer;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

