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
    public partial class Client : UserControl
    {
        public RadTreeView radTreeView;
        public string id_user_control;
        public string Cl;
        public string DateFacture;
        public string Numfacture;
        public string NumProjet;
        public string BU;
        public string NumBoite;
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            TBClient.Text = Cl;
            TBDateFacture.Text = DateFacture;
            TBNFacture.Text = Numfacture;
            TBNumProjet.Text = NumProjet;
            TBbu.Text = BU;
            TBNumBoite.Text = NumBoite;
        }

        private void validChanges_Click(object sender, EventArgs e)
        {
            var nomDoc = radTreeView.SelectedNode.Text.Replace("'", "''"); ;
            var Client = TBClient.Text;
            var DateFacture = TBDateFacture.Text;
            var Numfacture = TBNFacture.Text;
            var NumProjet = TBNumProjet.Text;
            var BU = TBbu.Text;
            var NumBoite = TBNumBoite.Text == "" ? "0" : TBNumBoite.Text;

            if (Client == "" || DateFacture == "" || Numfacture == "" || NumProjet == "" || BU == "" || NumBoite == "")
            {
                MessageBox.Show("Veillez Remplir tous les champs");
                return;
            }

            // update vente set [Client]= ,[DateFacture]= ,[Numfacture]= ,[NumProjet]= ,[BU]= ,[Numboite]= where [NomDossier]=
            var req = $"UPDATE vente SET [Client]='{Client}' ,[DateFacture]='{DateFacture}' ,[Numfacture]='{Numfacture}' ,[NumProjet]='{NumProjet}' ,[BU]='{BU}' ,[NumBoite]='{NumBoite}',id_status=6,id_user_control='{id_user_control}' WHERE [NomDossier]='{nomDoc}' " +
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
