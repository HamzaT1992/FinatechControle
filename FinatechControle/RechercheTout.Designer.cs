namespace FinatechControle
{
    partial class RechercheTout
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.bt_rech = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.bt_search = new Telerik.WinControls.UI.RadButton();
            this.dd_proj = new Telerik.WinControls.UI.RadDropDownList();
            this.dd_champs = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tb_rechValue = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.bt_rech.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dd_proj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dd_champs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_rechValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_rech
            // 
            this.bt_rech.Controls.Add(this.tb_rechValue);
            this.bt_rech.Controls.Add(this.radLabel3);
            this.bt_rech.Controls.Add(this.radLabel2);
            this.bt_rech.Controls.Add(this.radLabel1);
            this.bt_rech.Controls.Add(this.dd_champs);
            this.bt_rech.Controls.Add(this.dd_proj);
            this.bt_rech.Controls.Add(this.bt_search);
            this.bt_rech.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_rech.Location = new System.Drawing.Point(0, 0);
            this.bt_rech.Name = "bt_rech";
            this.bt_rech.Size = new System.Drawing.Size(947, 73);
            this.bt_rech.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 479);
            this.panel2.TabIndex = 1;
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowSearchRow = true;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(947, 479);
            this.radGridView1.TabIndex = 0;
            // 
            // bt_search
            // 
            this.bt_search.Location = new System.Drawing.Point(770, 23);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(110, 24);
            this.bt_search.TabIndex = 0;
            this.bt_search.Text = "Rechercher";
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // dd_proj
            // 
            this.dd_proj.Location = new System.Drawing.Point(120, 27);
            this.dd_proj.Name = "dd_proj";
            this.dd_proj.Size = new System.Drawing.Size(140, 20);
            this.dd_proj.TabIndex = 1;
            this.dd_proj.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.dd_proj_SelectedIndexChanged);
            // 
            // dd_champs
            // 
            this.dd_champs.Location = new System.Drawing.Point(352, 27);
            this.dd_champs.Name = "dd_champs";
            this.dd_champs.Size = new System.Drawing.Size(144, 20);
            this.dd_champs.TabIndex = 2;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(67, 27);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(36, 18);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "Projet";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(299, 27);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(47, 18);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "Champs";
            // 
            // tb_rechValue
            // 
            this.tb_rechValue.Location = new System.Drawing.Point(580, 27);
            this.tb_rechValue.Name = "tb_rechValue";
            this.tb_rechValue.Size = new System.Drawing.Size(151, 20);
            this.tb_rechValue.TabIndex = 5;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(527, 27);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(38, 18);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Valeur";
            // 
            // RechercheTout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 552);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bt_rech);
            this.Name = "RechercheTout";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RechercheTout";
            this.Load += new System.EventHandler(this.RechercheTout_Load);
            this.bt_rech.ResumeLayout(false);
            this.bt_rech.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dd_proj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dd_champs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_rechValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bt_rech;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList dd_champs;
        private Telerik.WinControls.UI.RadDropDownList dd_proj;
        private Telerik.WinControls.UI.RadButton bt_search;
        private Telerik.WinControls.UI.RadTextBox tb_rechValue;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
