namespace FinatechControle
{
    partial class AffecterBoites
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
            this.components = new System.ComponentModel.Container();
            this.dd_agent = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.bt_affect = new Telerik.WinControls.UI.RadButton();
            this.tBUtilisateursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.administration_ANCFCCDataSet = new FinatechControle.Administration_ANCFCCDataSet();
            this.tB_UtilisateursTableAdapter = new FinatechControle.Administration_ANCFCCDataSetTableAdapters.TB_UtilisateursTableAdapter();
            this.bt_cancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dd_agent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_affect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBUtilisateursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.administration_ANCFCCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dd_agent
            // 
            this.dd_agent.DataSource = this.tBUtilisateursBindingSource;
            this.dd_agent.DisplayMember = "login";
            this.dd_agent.Location = new System.Drawing.Point(120, 37);
            this.dd_agent.Name = "dd_agent";
            this.dd_agent.Size = new System.Drawing.Size(146, 20);
            this.dd_agent.TabIndex = 0;
            this.dd_agent.ValueMember = "id_user";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(56, 37);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(36, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Agent";
            // 
            // bt_affect
            // 
            this.bt_affect.Location = new System.Drawing.Point(167, 86);
            this.bt_affect.Name = "bt_affect";
            this.bt_affect.Size = new System.Drawing.Size(130, 24);
            this.bt_affect.TabIndex = 2;
            this.bt_affect.Text = "Affecter";
            this.bt_affect.Click += new System.EventHandler(this.bt_affect_Click);
            // 
            // tBUtilisateursBindingSource
            // 
            this.tBUtilisateursBindingSource.DataMember = "TB_Utilisateurs";
            this.tBUtilisateursBindingSource.DataSource = this.administration_ANCFCCDataSet;
            // 
            // administration_ANCFCCDataSet
            // 
            this.administration_ANCFCCDataSet.DataSetName = "Administration_ANCFCCDataSet";
            this.administration_ANCFCCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tB_UtilisateursTableAdapter
            // 
            this.tB_UtilisateursTableAdapter.ClearBeforeFill = true;
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(12, 86);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(130, 24);
            this.bt_cancel.TabIndex = 2;
            this.bt_cancel.Text = "Annuler";
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // AffecterBoites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 143);
            this.ControlBox = false;
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_affect);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.dd_agent);
            this.Name = "AffecterBoites";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affecter les Boites";
            this.Load += new System.EventHandler(this.AffecterBoites_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dd_agent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_affect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBUtilisateursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.administration_ANCFCCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList dd_agent;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton bt_affect;
        private Administration_ANCFCCDataSet administration_ANCFCCDataSet;
        private System.Windows.Forms.BindingSource tBUtilisateursBindingSource;
        private Administration_ANCFCCDataSetTableAdapters.TB_UtilisateursTableAdapter tB_UtilisateursTableAdapter;
        private Telerik.WinControls.UI.RadButton bt_cancel;
    }
}
