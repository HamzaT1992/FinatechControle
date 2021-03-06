﻿namespace FinatechControle
{
    partial class Banque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Banque));
            this.fournisseurLabel = new Telerik.WinControls.UI.RadLabel();
            this.validChanges = new Telerik.WinControls.UI.RadButton();
            this.TBNumOP = new Telerik.WinControls.UI.RadTextBox();
            this.dateFactureLabel = new Telerik.WinControls.UI.RadLabel();
            this.referenceLabel = new Telerik.WinControls.UI.RadLabel();
            this.NumProjetLabel = new Telerik.WinControls.UI.RadLabel();
            this.TBNumBoite = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.TBMt = new Telerik.WinControls.UI.RadTextBox();
            this.NumBoiteLabel = new Telerik.WinControls.UI.RadLabel();
            this.TBBeneficiaire = new Telerik.WinControls.UI.RadTextBox();
            this.TBDate = new Telerik.WinControls.UI.RadTextBox();
            this.TBReference = new Telerik.WinControls.UI.RadTextBox();
            this.title = new Telerik.WinControls.UI.RadLabel();
            this.TBNumSerCk = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fournisseurLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validChanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFactureLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.referenceLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumProjetLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumBoite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoiteLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBBeneficiaire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumSerCk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // fournisseurLabel
            // 
            this.fournisseurLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fournisseurLabel.AutoSize = false;
            this.fournisseurLabel.Location = new System.Drawing.Point(33, 76);
            this.fournisseurLabel.Name = "fournisseurLabel";
            this.fournisseurLabel.Size = new System.Drawing.Size(184, 18);
            this.fournisseurLabel.TabIndex = 36;
            this.fournisseurLabel.Text = "Num Opération";
            // 
            // validChanges
            // 
            this.validChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validChanges.Location = new System.Drawing.Point(33, 553);
            this.validChanges.Name = "validChanges";
            this.validChanges.Size = new System.Drawing.Size(215, 24);
            this.validChanges.TabIndex = 49;
            this.validChanges.Text = "Valider";
            this.validChanges.Click += new System.EventHandler(this.ValidChanges_Click);
            // 
            // TBNumOP
            // 
            this.TBNumOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBNumOP.AutoSize = false;
            this.TBNumOP.Location = new System.Drawing.Point(33, 96);
            this.TBNumOP.Name = "TBNumOP";
            this.TBNumOP.Size = new System.Drawing.Size(215, 20);
            this.TBNumOP.TabIndex = 35;
            this.TBNumOP.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // dateFactureLabel
            // 
            this.dateFactureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFactureLabel.AutoSize = false;
            this.dateFactureLabel.Location = new System.Drawing.Point(33, 202);
            this.dateFactureLabel.Name = "dateFactureLabel";
            this.dateFactureLabel.Size = new System.Drawing.Size(159, 18);
            this.dateFactureLabel.TabIndex = 37;
            this.dateFactureLabel.Text = "Date";
            // 
            // referenceLabel
            // 
            this.referenceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.referenceLabel.AutoSize = false;
            this.referenceLabel.Location = new System.Drawing.Point(33, 330);
            this.referenceLabel.Name = "referenceLabel";
            this.referenceLabel.Size = new System.Drawing.Size(146, 18);
            this.referenceLabel.TabIndex = 38;
            this.referenceLabel.Text = "Référence";
            // 
            // NumProjetLabel
            // 
            this.NumProjetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumProjetLabel.AutoSize = false;
            this.NumProjetLabel.Location = new System.Drawing.Point(33, 265);
            this.NumProjetLabel.Name = "NumProjetLabel";
            this.NumProjetLabel.Size = new System.Drawing.Size(167, 18);
            this.NumProjetLabel.TabIndex = 39;
            this.NumProjetLabel.Text = "Bénèficiaire";
            // 
            // TBNumBoite
            // 
            this.TBNumBoite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBNumBoite.AutoSize = false;
            this.TBNumBoite.Location = new System.Drawing.Point(33, 476);
            this.TBNumBoite.Name = "TBNumBoite";
            this.TBNumBoite.Size = new System.Drawing.Size(215, 20);
            this.TBNumBoite.TabIndex = 48;
            this.TBNumBoite.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Location = new System.Drawing.Point(33, 390);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(49, 18);
            this.radLabel1.TabIndex = 40;
            this.radLabel1.Text = "Montant";
            // 
            // TBMt
            // 
            this.TBMt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBMt.AutoSize = false;
            this.TBMt.Location = new System.Drawing.Point(33, 411);
            this.TBMt.Name = "TBMt";
            this.TBMt.Size = new System.Drawing.Size(215, 20);
            this.TBMt.TabIndex = 47;
            // 
            // NumBoiteLabel
            // 
            this.NumBoiteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumBoiteLabel.AutoSize = false;
            this.NumBoiteLabel.Location = new System.Drawing.Point(33, 456);
            this.NumBoiteLabel.Name = "NumBoiteLabel";
            this.NumBoiteLabel.Size = new System.Drawing.Size(138, 18);
            this.NumBoiteLabel.TabIndex = 42;
            this.NumBoiteLabel.Text = "N° Boite";
            // 
            // TBBeneficiaire
            // 
            this.TBBeneficiaire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBeneficiaire.AutoSize = false;
            this.TBBeneficiaire.Location = new System.Drawing.Point(33, 285);
            this.TBBeneficiaire.Name = "TBBeneficiaire";
            this.TBBeneficiaire.Size = new System.Drawing.Size(215, 20);
            this.TBBeneficiaire.TabIndex = 45;
            // 
            // TBDate
            // 
            this.TBDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDate.AutoSize = false;
            this.TBDate.Location = new System.Drawing.Point(33, 222);
            this.TBDate.Name = "TBDate";
            this.TBDate.Size = new System.Drawing.Size(215, 20);
            this.TBDate.TabIndex = 43;
            this.TBDate.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            // 
            // TBReference
            // 
            this.TBReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBReference.AutoSize = false;
            this.TBReference.Location = new System.Drawing.Point(33, 350);
            this.TBReference.Name = "TBReference";
            this.TBReference.Size = new System.Drawing.Size(215, 20);
            this.TBReference.TabIndex = 44;
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(100, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(80, 24);
            this.title.TabIndex = 34;
            this.title.Text = "BANQUES";
            // 
            // TBNumSerCk
            // 
            this.TBNumSerCk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBNumSerCk.AutoSize = false;
            this.TBNumSerCk.Location = new System.Drawing.Point(33, 161);
            this.TBNumSerCk.Name = "TBNumSerCk";
            this.TBNumSerCk.Size = new System.Drawing.Size(215, 20);
            this.TBNumSerCk.TabIndex = 35;
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(33, 141);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(206, 18);
            this.radLabel2.TabIndex = 36;
            this.radLabel2.Text = "Num Série Chèque";
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
            // Banque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.fournisseurLabel);
            this.Controls.Add(this.TBNumSerCk);
            this.Controls.Add(this.validChanges);
            this.Controls.Add(this.TBNumOP);
            this.Controls.Add(this.dateFactureLabel);
            this.Controls.Add(this.referenceLabel);
            this.Controls.Add(this.NumProjetLabel);
            this.Controls.Add(this.TBNumBoite);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.TBMt);
            this.Controls.Add(this.NumBoiteLabel);
            this.Controls.Add(this.TBBeneficiaire);
            this.Controls.Add(this.TBDate);
            this.Controls.Add(this.TBReference);
            this.Controls.Add(this.title);
            this.Name = "Banque";
            this.Size = new System.Drawing.Size(280, 622);
            this.Load += new System.EventHandler(this.Banque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fournisseurLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validChanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFactureLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.referenceLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumProjetLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumBoite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoiteLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBBeneficiaire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBNumSerCk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel fournisseurLabel;
        private Telerik.WinControls.UI.RadButton validChanges;
        private Telerik.WinControls.UI.RadTextBox TBNumOP;
        private Telerik.WinControls.UI.RadLabel dateFactureLabel;
        private Telerik.WinControls.UI.RadLabel referenceLabel;
        private Telerik.WinControls.UI.RadLabel NumProjetLabel;
        private Telerik.WinControls.UI.RadTextBox TBNumBoite;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox TBMt;
        private Telerik.WinControls.UI.RadLabel NumBoiteLabel;
        private Telerik.WinControls.UI.RadTextBox TBBeneficiaire;
        private Telerik.WinControls.UI.RadTextBox TBDate;
        private Telerik.WinControls.UI.RadTextBox TBReference;
        private Telerik.WinControls.UI.RadLabel title;
        private Telerik.WinControls.UI.RadTextBox TBNumSerCk;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
