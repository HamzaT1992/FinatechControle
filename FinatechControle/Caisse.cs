using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Configuration;
using System.Data.SqlClient;

namespace FinatechControle
{
    public partial class Caisse : UserControl
    {
        public RadTreeView radTreeView;
        public string id_user_control;
        public string NumImmatricule;
        public string DatePiece;
        public string Salarie;
        public string Reference;
        public string BU;
        public string NumProjet;
        public string NumBoite;


        public Caisse()
        {
            InitializeComponent();
        }

        private void Caisse_Load(object sender, EventArgs e)
        {
            TBDatePiece.Text = DatePiece;
            TBBU.Text = BU;
            TBNProjet.Text = NumProjet;
            TBNumBoite.Text = NumBoite;
            TBNumImm.Text = NumImmatricule;
            TBSalarie.Text = Salarie;
            TBReference.Text = Reference;
        }

        private void validChanges_Click(object sender, EventArgs e)
        {
            var nomDoc = radTreeView.SelectedNode.Text.Replace("'", "''"); ;
            var Date = TBDatePiece.Text;
            var NumProjet = TBNProjet.Text;
            var BU = TBBU.Text;
            var NumBoite = TBNumBoite.Text == "" ? "0" : TBNumBoite.Text;
            var Ref = TBReference.Text;
            var Imm = TBNumImm.Text;
            var salary = TBSalarie.Text;
            if (Date == "" || NumProjet == "" || BU == "" || Ref == "" || NumBoite == "" || Imm == "" || salary == "")
            {
                MessageBox.Show("Veillez Remplir tous les champs");
                return;
            }
            var req = $"update Caisse set [DatePiece]='{Date}' ,[NumProjet]='{NumProjet}' ,[BU]='{BU}' ,[NumBoite]='{NumBoite}',reference='{Ref}',NumDImatricul='{Imm}',salarie='{salary}',id_status=6,id_user_control={id_user_control} WHERE [NomDossier]='{nomDoc}' " +
                $"UPDATE FinaTech_Test.dbo.DossiersIndexes SET id_status=6 WHERE NomDossier='{nomDoc}'";
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                var cmd = new SqlCommand(req, cnn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Opération effectué!!");
            }
            var docControle = radTreeView.SelectedNode;
            var parent = docControle.Parent;
            if (radTreeView.SelectedNode.NextNode != null)
            {
                radTreeView.SelectedNode = docControle.NextNode;
            }
            else
            {
                radTreeView.SelectedNode = parent;
            }
            parent.Nodes.Remove(docControle);
            if (radTreeView.SelectedNode == parent)
            {
                radTreeView.Nodes.Remove(parent);
            }
        }
    }
}
