namespace FinatechControle
{
    partial class Login
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.roundRectShapeTitle = new Telerik.WinControls.RoundRectShape(this.components);
            this.roundRectShapeForm = new Telerik.WinControls.RoundRectShape(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.loginTBox = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.passTBox = new Telerik.WinControls.UI.RadTextBox();
            this.cnxButton = new Telerik.WinControls.UI.RadButton();
            this.cancelButton = new Telerik.WinControls.UI.RadButton();
            this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cnxButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTitleBar1.Location = new System.Drawing.Point(1, 1);
            this.radTitleBar1.Name = "radTitleBar1";
            // 
            // 
            // 
            this.radTitleBar1.RootElement.ApplyShapeToControl = true;
            this.radTitleBar1.RootElement.Shape = this.roundRectShapeTitle;
            this.radTitleBar1.Size = new System.Drawing.Size(351, 23);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Connexion";
            // 
            // roundRectShapeTitle
            // 
            this.roundRectShapeTitle.BottomLeftRounded = false;
            this.roundRectShapeTitle.BottomRightRounded = false;
            this.roundRectShapeTitle.IsRightToLeft = false;
            // 
            // roundRectShapeForm
            // 
            this.roundRectShapeForm.IsRightToLeft = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(41, 51);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(40, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Login :";
            // 
            // loginTBox
            // 
            this.loginTBox.Location = new System.Drawing.Point(134, 51);
            this.loginTBox.Name = "loginTBox";
            this.loginTBox.Size = new System.Drawing.Size(177, 20);
            this.loginTBox.TabIndex = 1;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(41, 95);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(33, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Pass :";
            // 
            // passTBox
            // 
            this.passTBox.Location = new System.Drawing.Point(134, 95);
            this.passTBox.Name = "passTBox";
            this.passTBox.PasswordChar = '*';
            this.passTBox.Size = new System.Drawing.Size(177, 20);
            this.passTBox.TabIndex = 2;
            // 
            // cnxButton
            // 
            this.cnxButton.Location = new System.Drawing.Point(201, 198);
            this.cnxButton.Name = "cnxButton";
            this.cnxButton.Size = new System.Drawing.Size(110, 24);
            this.cnxButton.TabIndex = 4;
            this.cnxButton.Text = "Connexion";
            this.cnxButton.Click += new System.EventHandler(this.cnxButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(41, 198);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 24);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // radDropDownList1
            // 
            radListDataItem1.Text = "Indexations";
            radListDataItem2.Text = "Rejets";
            this.radDropDownList1.Items.Add(radListDataItem1);
            this.radDropDownList1.Items.Add(radListDataItem2);
            this.radDropDownList1.Location = new System.Drawing.Point(134, 140);
            this.radDropDownList1.Name = "radDropDownList1";
            this.radDropDownList1.Size = new System.Drawing.Size(177, 20);
            this.radDropDownList1.TabIndex = 3;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(41, 140);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(62, 18);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "Opération :";
            // 
            // Login
            // 
            this.AcceptButton = this.cnxButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(353, 250);
            this.Controls.Add(this.radDropDownList1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.cnxButton);
            this.Controls.Add(this.passTBox);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.loginTBox);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radTitleBar1);
            this.Name = "Login";
            this.Shape = this.roundRectShapeForm;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.Load += new System.EventHandler(this.ShapedForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cnxButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.RoundRectShape roundRectShapeForm;
        private Telerik.WinControls.RoundRectShape roundRectShapeTitle;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox loginTBox;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox passTBox;
        private Telerik.WinControls.UI.RadButton cnxButton;
        private Telerik.WinControls.UI.RadButton cancelButton;
        private Telerik.WinControls.UI.RadDropDownList radDropDownList1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
