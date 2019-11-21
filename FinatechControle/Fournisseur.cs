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
    public partial class Fournisseur : UserControl
    {
        public RadTreeView radTreeView;
        public string id_user_control;
        public string Fourniss;
        public string DateFacture;
        public string Reference;
        public string NumProjet;
        public string NumBonCommande;
        public string BU;
        public string NumBoite;
        public Fournisseur()
        {
            InitializeComponent();
        }

        private void validChanges_Click(object sender, EventArgs e)
        {
            var nomDoc = radTreeView.SelectedNode.Text.Replace("'", "''"); ;
            var Fournisseur = TBFournisseur.Text;
            var Date = TBDateFacture.Text;
            var Reference = TBReference.Text;
            var NumProjet = TBNumProjet.Text;
            var NumBonCom = TBNumBonCom.Text;
            var BU = TBbu.Text;
            var NumBoite = TBNumBoite.Text == "" ? "0" : TBNumBoite.Text;
            if (Fournisseur == "" || Date == "" || Reference == "" || NumProjet == "" || NumBonCom == "" || BU == "" || NumBoite == "")
            {
                MessageBox.Show("Veillez Remplir tous les champs");
                return;
            }

            var req = $"update Achat set [Fournisseur]='{Fournisseur}' ,[DateFacture]='{Date}' ,[Reference]='{Reference}' ,[NumProjet]='{NumProjet}' ,[NumBonCommande]='{NumBonCom}' ,[BU]='{BU}' ,[NumBoite]='{NumBoite}',id_status=6,id_user_control={id_user_control} WHERE [NomDossier]='{nomDoc}' " +
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

        private void Fournisseur_Load(object sender, EventArgs e)
        {
            TBFournisseur.Text = Fourniss;
            TBDateFacture.Text = DateFacture;
            TBReference.Text = Reference;
            TBNumProjet.Text = NumProjet;
            TBNumBonCom.Text = NumBonCommande;
            TBbu.Text = BU;
            TBNumBoite.Text = NumBoite;
        }

        private void validChanges_Click_1(object sender, EventArgs e)
        {
            var nomDoc = radTreeView.SelectedNode.Text.Replace("'", "''");
            var Fourniss = TBFournisseur.Text;
            var DateFact = TBDateFacture.Text;
            var Ref = TBReference.Text;
            var numProj = TBNumProjet.Text;
            var numBonCom = TBNumBonCom.Text;
            var Reference = TBReference.Text;
            var bu = TBbu.Text;
            var NumBoite = TBNumBoite.Text == "" ? "0" : TBNumBoite.Text;

            if (Fourniss == "" || DateFact == "" || Ref == "" || numBonCom == "" || Reference == "" || numProj == "" || bu == "" || NumBoite == "")
            {
                MessageBox.Show("Veillez Remplir tous les champs");
                return;
            }
            // update vente set [Client]= ,[DateFacture]= ,[Numfacture]= ,[NumProjet]= ,[BU]= ,[Numboite]= where [NomDossier]=
            var req = $"UPDATE achat SET  [Fournisseur]='{Fourniss}' ,[DateFacture]='{DateFact}' ,[Reference]='{Ref}' ,[NumBonCommande]='{numBonCom}' ,[Reference]='{Reference}' [NumProjet]={numProj},[BU]={bu} ,[NumBoite]='{NumBoite}' ,[id_status]=6 ,[id_user_control]={id_user_control} WHERE [NomDossier]='{nomDoc}' " +
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
