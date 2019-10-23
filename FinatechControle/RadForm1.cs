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

namespace FinatechControle
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
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
                string rqtNumBoites = "select distinct Numboite from DossiersIndexes where Type='Achat/FOURNISSEUR'";


                SqlDataAdapter da = new SqlDataAdapter(rqtNumBoites, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    RadTreeNode boite = new RadTreeNode();
                    var numBoite = row["Numboite"].ToString();
                    boite.Text = "Boite " + numBoite;
                    boite.Value = numBoite;
                    foreach (DataRow item in getDocs(numBoite).Rows)
                    {
                        RadTreeNode doc = new RadTreeNode();
                        var doss = item["NomDossier"].ToString();
                        var xmlpath = item["CheminPDF"].ToString();
                        //var pdf = doss.Split('\\')[1];
                        var path = Path.GetDirectoryName(xmlpath) + "\\" + doss;
                        doc.Text = doss;
                        doc.Value = path;
                        boite.Nodes.Add(doc);
                    }
                    //Boites.Nodes.Add(boite);
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
                string reqdocs = "select * from DossiersIndexes where Numboite = "+numboite;


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
    }
}
