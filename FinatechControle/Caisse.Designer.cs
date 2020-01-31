namespace FinatechControle
{
    partial class Caisse
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caisse));
            this.clientLabel = new Telerik.WinControls.UI.RadLabel();
            this.validChanges = new Telerik.WinControls.UI.RadButton();
            this.TBDatePiece = new Telerik.WinControls.UI.RadTextBox();
            this.dateFactureLabel = new Telerik.WinControls.UI.RadLabel();
            this.referenceLabel = new Telerik.WinControls.UI.RadLabel();
            this.TBNumBoite = new Telerik.WinControls.UI.RadTextBox();
            this.NumBoiteLabel = new Telerik.WinControls.UI.RadLabel();
            this.TBBU = new Telerik.WinControls.UI.RadTextBox();
            this.TBNProjet = new Telerik.WinControls.UI.RadTextBox();
            this.title = new Telerik.WinControls.UI.RadLabel();
            this.TBNumImm = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.TBSalarie = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.TBReference = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clientLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validChanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBDatePiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFactureLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.referenceLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumBoite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoiteLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBBU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNProjet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumImm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBSalarie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // clientLabel
            // 
            this.clientLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientLabel.AutoSize = false;
            this.clientLabel.Location = new System.Drawing.Point(33, 158);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(164, 18);
            this.clientLabel.TabIndex = 52;
            this.clientLabel.Text = "Date Piece";
            // 
            // validChanges
            // 
            this.validChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validChanges.Enabled = false;
            this.validChanges.Location = new System.Drawing.Point(33, 563);
            this.validChanges.Name = "validChanges";
            this.validChanges.Size = new System.Drawing.Size(215, 24);
            this.validChanges.TabIndex = 63;
            this.validChanges.Text = "Valider";
            this.validChanges.Click += new System.EventHandler(this.ValidChanges_Click);
            // 
            // TBDatePiece
            // 
            this.TBDatePiece.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDatePiece.AutoSize = false;
            this.TBDatePiece.Location = new System.Drawing.Point(33, 178);
            this.TBDatePiece.Name = "TBDatePiece";
            this.TBDatePiece.Size = new System.Drawing.Size(215, 20);
            this.TBDatePiece.TabIndex = 51;
            this.TBDatePiece.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // dateFactureLabel
            // 
            this.dateFactureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFactureLabel.AutoSize = false;
            this.dateFactureLabel.Location = new System.Drawing.Point(33, 354);
            this.dateFactureLabel.Name = "dateFactureLabel";
            this.dateFactureLabel.Size = new System.Drawing.Size(169, 18);
            this.dateFactureLabel.TabIndex = 53;
            this.dateFactureLabel.Text = "BU";
            // 
            // referenceLabel
            // 
            this.referenceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.referenceLabel.AutoSize = false;
            this.referenceLabel.Location = new System.Drawing.Point(33, 421);
            this.referenceLabel.Name = "referenceLabel";
            this.referenceLabel.Size = new System.Drawing.Size(180, 18);
            this.referenceLabel.TabIndex = 54;
            this.referenceLabel.Text = "N° Projet";
            // 
            // TBNumBoite
            // 
            this.TBNumBoite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBNumBoite.AutoSize = false;
            this.TBNumBoite.Location = new System.Drawing.Point(33, 506);
            this.TBNumBoite.Name = "TBNumBoite";
            this.TBNumBoite.Size = new System.Drawing.Size(215, 20);
            this.TBNumBoite.TabIndex = 62;
            this.TBNumBoite.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // NumBoiteLabel
            // 
            this.NumBoiteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumBoiteLabel.AutoSize = false;
            this.NumBoiteLabel.Location = new System.Drawing.Point(33, 486);
            this.NumBoiteLabel.Name = "NumBoiteLabel";
            this.NumBoiteLabel.Size = new System.Drawing.Size(148, 18);
            this.NumBoiteLabel.TabIndex = 57;
            this.NumBoiteLabel.Text = "N° Boite";
            // 
            // TBBU
            // 
            this.TBBU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBU.AutoSize = false;
            this.TBBU.Location = new System.Drawing.Point(33, 374);
            this.TBBU.Name = "TBBU";
            this.TBBU.Size = new System.Drawing.Size(215, 20);
            this.TBBU.TabIndex = 58;
            this.TBBU.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // TBNProjet
            // 
            this.TBNProjet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBNProjet.AutoSize = false;
            this.TBNProjet.Location = new System.Drawing.Point(33, 441);
            this.TBNProjet.Name = "TBNProjet";
            this.TBNProjet.Size = new System.Drawing.Size(215, 20);
            this.TBNProjet.TabIndex = 59;
            this.TBNProjet.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(114, 35);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(52, 24);
            this.title.TabIndex = 50;
            this.title.Text = "Caisse";
            // 
            // TBNumImm
            // 
            this.TBNumImm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBNumImm.AutoSize = false;
            this.TBNumImm.Location = new System.Drawing.Point(33, 106);
            this.TBNumImm.Name = "TBNumImm";
            this.TBNumImm.Size = new System.Drawing.Size(215, 20);
            this.TBNumImm.TabIndex = 51;
            this.TBNumImm.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(33, 86);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(222, 18);
            this.radLabel1.TabIndex = 52;
            this.radLabel1.Text = "N° D\'Immatricule";
            // 
            // TBSalarie
            // 
            this.TBSalarie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBSalarie.AutoSize = false;
            this.TBSalarie.Location = new System.Drawing.Point(33, 243);
            this.TBSalarie.Name = "TBSalarie";
            this.TBSalarie.Size = new System.Drawing.Size(215, 20);
            this.TBSalarie.TabIndex = 51;
            this.TBSalarie.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(33, 223);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(207, 18);
            this.radLabel2.TabIndex = 52;
            this.radLabel2.Text = "Salarié";
            // 
            // TBReference
            // 
            this.TBReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBReference.AutoSize = false;
            this.TBReference.Location = new System.Drawing.Point(33, 309);
            this.TBReference.Name = "TBReference";
            this.TBReference.Size = new System.Drawing.Size(215, 20);
            this.TBReference.TabIndex = 58;
            this.TBReference.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.AutoSize = false;
            this.radLabel3.Location = new System.Drawing.Point(33, 289);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(169, 18);
            this.radLabel3.TabIndex = 53;
            this.radLabel3.Text = "Référence";
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider2.Icon")));
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // Caisse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.TBNumImm);
            this.Controls.Add(this.TBSalarie);
            this.Controls.Add(this.validChanges);
            this.Controls.Add(this.TBDatePiece);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.dateFactureLabel);
            this.Controls.Add(this.referenceLabel);
            this.Controls.Add(this.TBNumBoite);
            this.Controls.Add(this.TBReference);
            this.Controls.Add(this.NumBoiteLabel);
            this.Controls.Add(this.TBBU);
            this.Controls.Add(this.TBNProjet);
            this.Controls.Add(this.title);
            this.Name = "Caisse";
            this.Size = new System.Drawing.Size(280, 622);
            this.Load += new System.EventHandler(this.Caisse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validChanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBDatePiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFactureLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.referenceLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumBoite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoiteLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBBU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNProjet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumImm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBSalarie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel clientLabel;
        private Telerik.WinControls.UI.RadButton validChanges;
        private Telerik.WinControls.UI.RadTextBox TBDatePiece;
        private Telerik.WinControls.UI.RadLabel dateFactureLabel;
        private Telerik.WinControls.UI.RadLabel referenceLabel;
        private Telerik.WinControls.UI.RadTextBox TBNumBoite;
        private Telerik.WinControls.UI.RadLabel NumBoiteLabel;
        private Telerik.WinControls.UI.RadTextBox TBBU;
        private Telerik.WinControls.UI.RadTextBox TBNProjet;
        private Telerik.WinControls.UI.RadLabel title;
        private Telerik.WinControls.UI.RadTextBox TBNumImm;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox TBSalarie;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox TBReference;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
