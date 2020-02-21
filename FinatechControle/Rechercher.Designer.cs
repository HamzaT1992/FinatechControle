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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ddlProjet = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlChamps = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.tb_rechValue = new Telerik.WinControls.UI.RadTextBox();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProjet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlChamps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_rechValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
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
            this.ddlProjet.Location = new System.Drawing.Point(26, 48);
            this.ddlProjet.Name = "ddlProjet";
            this.ddlProjet.Size = new System.Drawing.Size(185, 20);
            this.ddlProjet.TabIndex = 0;
            this.ddlProjet.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlProjet_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(26, 18);
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
            this.ddlChamps.Location = new System.Drawing.Point(264, 48);
            this.ddlChamps.Name = "ddlChamps";
            this.ddlChamps.Size = new System.Drawing.Size(185, 20);
            this.ddlChamps.TabIndex = 0;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(264, 18);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(47, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Champs";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(763, 44);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(185, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Rechercher";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(507, 18);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(38, 18);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "Valeur";
            // 
            // tb_rechValue
            // 
            this.tb_rechValue.Location = new System.Drawing.Point(507, 48);
            this.tb_rechValue.Name = "tb_rechValue";
            this.tb_rechValue.Size = new System.Drawing.Size(185, 20);
            this.tb_rechValue.TabIndex = 3;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.tb_rechValue);
            this.radPanel1.Controls.Add(this.ddlProjet);
            this.radPanel1.Controls.Add(this.radButton1);
            this.radPanel1.Controls.Add(this.ddlChamps);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(999, 100);
            this.radPanel1.TabIndex = 4;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radGridView1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 100);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(999, 477);
            this.radPanel2.TabIndex = 5;
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.Size = new System.Drawing.Size(999, 477);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.DoubleClick += new System.EventHandler(this.radGridView1_DoubleClick);
            // 
            // Rechercher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(999, 577);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlProjet;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlChamps;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox tb_rechValue;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGridView radGridView1;
    }
}
