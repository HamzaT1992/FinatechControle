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
    public partial class Banque : UserControl
    {
        public RadTreeView radTreeView;
        public string id_user_control;
        public string NumOP;
        public string NumSerieCheque;
        public string Date;
        public string Beneficiaire;
        public string Reference;
        public string Montant;
        public string NumBoite;
        public Banque()
        {
            InitializeComponent();
        }

        private void Banque_Load(object sender, EventArgs e)
        {
            //,[NumOP]
            //,[NumSerieCheque]
            //,[Date]
            //,[Beneficiaire]
            //,[Reference]
            //,[Montant]
            //,[NumBoite]
            //,[NomDossier]
            TBNumOP.Text = NumOP;
            TBNumSerCk.Text = NumSerieCheque;
            TBDate.Text = Date;
            TBBeneficiaire.Text = Beneficiaire;
            TBReference.Text = Reference;
            TBMt.Text = NumBoite;
            TBNumBoite.Text = Montant;
        }

        private void validChanges_Click(object sender, EventArgs e)
        {
            var nomDoc = radTreeView.SelectedNode.Text;
            var NumOP = TBNumOP.Text;
            var NumSerieCheque = TBNumSerCk.Text;
            var Date = TBDate.Text;
            var Beneficiaire = TBBeneficiaire.Text;
            var Reference = TBReference.Text;
            var Montant = TBMt.Text;
            var NumBoite = TBNumBoite.Text == "" ? "0" : TBNumBoite.Text;

            if (NumOP == "" || NumSerieCheque == "" || Date == "" || Beneficiaire == "" || Reference == "" || Montant == "" || NumBoite == "")
            {
                MessageBox.Show("Veillez Remplir tous les champs");
                return;
            }

            // update vente set [Client]= ,[DateFacture]= ,[Numfacture]= ,[NumProjet]= ,[BU]= ,[Numboite]= where [NomDossier]=
            var req = $"UPDATE banque SET  [NumOP]='{NumOP}' ,[NumSerieCheque]='{NumSerieCheque}' ,[Date]='{Date}' ,[Beneficiaire]='{Beneficiaire}' ,[Reference]='{Reference}' ,[Montant]={Montant} ,[NumBoite]={NumBoite} ,[id_status]=6 ,[id_user_control]={id_user_control} WHERE [NomDossier]='{nomDoc}' " +
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
