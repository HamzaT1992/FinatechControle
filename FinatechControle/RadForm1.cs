using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace FinatechControle
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        string id_user_control;
        public RadForm1(string id_user)
        {
            InitializeComponent();
            id_user_control = id_user;
            //var Boites = new RadTreeNode();
            //Boites.Text = "Boites";
            radTreeView2.SelectedNodeChanged += Node_Changed;
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string rqtNumBoites = "select distinct Numboite from DossiersIndexes where  id_status=3 and type='Achat/FOURNISSEUR'";


                SqlDataAdapter da = new SqlDataAdapter(rqtNumBoites, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {

                    RadTreeNode boite = new RadTreeNode();
                    var numBoite = row["Numboite"].ToString();
                    
                    boite.Value = numBoite;
                    var Docs = getDocs(numBoite);
                    foreach (DataRow item in Docs.Rows)
                    {
                        RadTreeNode doc = new RadTreeNode();
                        var doss = item["NomDossier"].ToString();
                        //var pdf = doss.Split('\\')[1];
                        var path = item["CheminPDF"].ToString();
                        doc.Text = doss;
                        doc.Value = path;
                        boite.Nodes.Add(doc);
                    }
                    //Boites.Nodes.Add(boite);
                    boite.Text = $"Boite {numBoite} ({Docs.Rows.Count})";
                    radTreeView2.Nodes.Add(boite);
                }

            }
        }

        private DataTable getDocs(string numboite)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string reqdocs = "select * from DossiersIndexes where id_status=3 and type='Achat/FOURNISSEUR' and Numboite = " + numboite;


                SqlDataAdapter da = new SqlDataAdapter(reqdocs, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
                
            }
        }

        private void Node_Changed(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                radPdfViewer2.LoadDocument(e.Node.Value.ToString());
                var row = getIndexs(e.Node.Text).Rows[0];
                TBFournisseur.Text = row["Fournisseur"].ToString();
                TBDateFacture.Text = row["DateFacture"].ToString();
                TBReference.Text = row["Reference"].ToString();
                TBNumProjet.Text = row["NumProjet"].ToString();
                TBNumBonCom.Text = row["NumBonCommande"].ToString();
                TBbu.Text = row["BU"].ToString();
                TBNumBoite.Text = row["NumBoite"].ToString();
            }
        }

        private DataTable getIndexs(string nomDoss)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string reqdocs = "select * from Achat where NomDossier = '" + nomDoss+"'";


                SqlDataAdapter da = new SqlDataAdapter(reqdocs, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void validChanges_Click(object sender, EventArgs e)
        {
            var nomDoc = radTreeView2.SelectedNode.Text;
            var Fournisseur = TBFournisseur.Text;
            var Date = TBDateFacture.Text;
            var Reference = TBReference.Text;
            var NumProjet = TBNumProjet.Text;
            var NumBonCom = TBNumBonCom.Text;
            var BU = TBbu.Text;
            var NumBoite = TBNumBoite.Text;

            var req = $"update Achat set [Fournisseur]='{Fournisseur}' ,[DateFacture]='{Date}' ,[Reference]='{Reference}' ,[NumProjet]={NumProjet} ,[NumBonCommande]={NumBonCom} ,[BU]='{BU}' ,[NumBoite]={NumBoite},id_status=6,id_user_control='{id_user_control}' where [NomDossier]='{nomDoc}' " +
                $"UPDATE FinaTech_Test.dbo.DossiersIndexes SET id_status=6 where NomDossier='{nomDoc}'";
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                var cmd = new SqlCommand(req, cnn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Opération effectué!!");
            }
            var docControle = radTreeView2.SelectedNode;
            var parent = docControle.Parent;
            if (radTreeView2.SelectedNode.NextNode != null)
            {
                radTreeView2.SelectedNode = docControle.NextNode;
            }
            else
            {                
                radTreeView2.SelectedNode = parent;
            }
            parent.Nodes.Remove(docControle);
            if (radTreeView2.SelectedNode == parent)
            {
                radTreeView2.Nodes.Remove(parent);
            }
        }

        private void RadForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
