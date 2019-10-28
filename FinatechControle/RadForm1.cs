using FinatechControle.Properties;
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
        // id utilisateur de controle
        string id_user_control;
        public RadForm1(string id_user)
        {
            InitializeComponent();
            id_user_control = id_user;
            //var Boites = new RadTreeNode();
            //Boites.Text = "Boites";
            radTreeView2.SelectedNodeChanged += Node_Changed;
            //fournisseur1.radTreeView = radTreeView2;
            //splitPanel3
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string rqtNumBoites = "select distinct Numboite from DossiersIndexes where id_status=3";


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
                        doc.Tag = item["type"].ToString();
                        doc.Image = Resources.openfilefolder;
                        //switch (item["type"].ToString())
                        //{
                        //    case "Achat/FOURNISSEUR":
                        //        doc.Image = Resources.redFolder;
                        //        break;
                        //    case "Vente/Client":
                        //        doc.Image = Resources.blueFolder;
                        //        break;
                        //    default:
                        //        doc.Image = Resources.vioFolder;
                        //        break;
                        //}
                        
                        boite.Nodes.Add(doc);
                    }
                    //Boites.Nodes.Add(boite);
                    boite.Text = $"Boite {numBoite} ({Docs.Rows.Count})";
                    boite.Image = Resources.cardfilebox;
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
                string reqdocs = "select * from DossiersIndexes where id_status=3 and Numboite = " + numboite;

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
                try
                {
                    radPdfViewer2.LoadDocument(e.Node.Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Verifier le type de Document
                var type = e.Node.Tag.ToString();
                // Pour le type Achat/FOURNISSEUR
                if (type == "Achat/FOURNISSEUR")
                {
                    var row = getIndexs(e.Node.Text, "Achat").Rows[0];
                    var frniss = new Fournisseur()
                    {
                        radTreeView = radTreeView2,
                        id_user_control = id_user_control,
                        Fourniss = row["Fournisseur"].ToString(),
                        DateFacture = row["DateFacture"].ToString(),
                        Reference = row["Reference"].ToString(),
                        NumProjet = row["NumProjet"].ToString(),
                        NumBonCommande = row["NumBonCommande"].ToString(),
                        BU = row["BU"].ToString(),
                        NumBoite = row["NumBoite"].ToString()
                    };
                    foreach (Control item in splitPanel3.Controls)
                    {
                        item.Dispose();
                    }
                    splitPanel3.Controls.Add(frniss);
                    frniss.BringToFront();
                    frniss.Dock = DockStyle.Fill;
                }
                // Pour le type Vente/Client
                else if (type == "Vente/Client")
                {
                    var row = getIndexs(e.Node.Text, "Vente").Rows[0];
                    var client = new Client()
                    {
                        radTreeView = radTreeView2,
                        id_user_control = id_user_control,
                        Cl = row["Client"].ToString(),
                        DateFacture = row["DateFacture"].ToString(),
                        Numfacture = row["Numfacture"].ToString(),
                        NumProjet = row["NumProjet"].ToString(),
                        BU = row["BU"].ToString(),
                        NumBoite = row["Numboite"].ToString()
                    };
                    foreach (Control item in splitPanel3.Controls)
                    {
                        item.Dispose();
                    }
                    splitPanel3.Controls.Add(client);
                    client.BringToFront();
                    client.Dock = DockStyle.Fill;
                }
                // Pour le type BANQUES
                else if (type == "BANQUES")
                {
                    var row = getIndexs(e.Node.Text, "banque").Rows[0];
                    var banque = new Banque()
                    {
                        radTreeView = radTreeView2,
                        id_user_control = id_user_control,
                        NumOP = row["NumOP"].ToString(),
                        NumSerieCheque = row["NumSerieCheque"].ToString(),
                        Date = row["Date"].ToString(),
                        Beneficiaire = row["Beneficiaire"].ToString(),
                        Reference = row["Reference"].ToString(),
                        Montant = row["Montant"].ToString(),
                        NumBoite = row["NumBoite"].ToString()
                    };
                    foreach (Control item in splitPanel3.Controls)
                    {
                        item.Dispose();
                    }
                    splitPanel3.Controls.Add(banque);
                    banque.BringToFront();
                    banque.Dock = DockStyle.Fill;
                }
            }
        }    

        private DataTable getIndexs(string nomDoss, string table)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string reqdocs = $"select * from {table} where NomDossier = '{nomDoss}'";


                SqlDataAdapter da = new SqlDataAdapter(reqdocs, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void RadForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
