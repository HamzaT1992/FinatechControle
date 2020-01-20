namespace FinatechControle
{
    partial class Rechercher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem9 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem10 = new Telerik.WinControls.UI.RadListDataItem();
            this.ddlProjet = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlChamps = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.tb_rechValue = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProjet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlChamps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_rechValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlProjet
            // 
            this.ddlProjet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            radListDataItem1.Text = "Achat";
            radListDataItem2.Text = "Banque";
            radListDataItem3.Text = "Caisse";
            radListDataItem4.Text = "Import";
            radListDataItem5.Text = "Vente";
            this.ddlProjet.Items.Add(radListDataItem1);
            this.ddlProjet.Items.Add(radListDataItem2);
            this.ddlProjet.Items.Add(radListDataItem3);
            this.ddlProjet.Items.Add(radListDataItem4);
            this.ddlProjet.Items.Add(radListDataItem5);
            this.ddlProjet.Location = new System.Drawing.Point(40, 43);
            this.ddlProjet.Name = "ddlProjet";
            this.ddlProjet.Size = new System.Drawing.Size(185, 20);
            this.ddlProjet.TabIndex = 0;
            this.ddlProjet.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlProjet_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(40, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(36, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Projet";
            // 
            // ddlChamps
            // 
            this.ddlChamps.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            radListDataItem6.Text = "Achat";
            radListDataItem7.Text = "Banque";
            radListDataItem8.Text = "Caisse";
            radListDataItem9.Text = "Import";
            radListDataItem10.Text = "Vente";
            this.ddlChamps.Items.Add(radListDataItem6);
            this.ddlChamps.Items.Add(radListDataItem7);
            this.ddlChamps.Items.Add(radListDataItem8);
            this.ddlChamps.Items.Add(radListDataItem9);
            this.ddlChamps.Items.Add(radListDataItem10);
            this.ddlChamps.Location = new System.Drawing.Point(40, 105);
            this.ddlChamps.Name = "ddlChamps";
            this.ddlChamps.Size = new System.Drawing.Size(185, 20);
            this.ddlChamps.TabIndex = 0;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(40, 75);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(47, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Champs";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(40, 208);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(185, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Rechercher";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(40, 137);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(38, 18);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "Valeur";
            // 
            // tb_rechValue
            // 
            this.tb_rechValue.Location = new System.Drawing.Point(40, 167);
            this.tb_rechValue.Name = "tb_rechValue";
            this.tb_rechValue.Size = new System.Drawing.Size(185, 20);
            this.tb_rechValue.TabIndex = 3;
            // 
            // Rechercher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 255);
            this.Controls.Add(this.tb_rechValue);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ddlChamps);
            this.Controls.Add(this.ddlProjet);
            this.Name = "Rechercher";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechercher";
            ((System.ComponentModel.ISupportInitialize)(this.ddlProjet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlChamps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_rechValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlProjet;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlChamps;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox tb_rechValue;
    }
}
