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
    public partial class Controle : Telerik.WinControls.UI.RadForm
    {
        // id utilisateur de controle
        string id_user_control;
        RadTreeNode CurrentNode;
        public Controle(string id_user, string userControl)
        {
            InitializeComponent();
            id_user_control = id_user;
            //var Boites = new RadTreeNode();
            //Boites.Text = "Boites";
            radTreeView2.SelectedNodeChanged += Node_Changed;
            radLabel3.Text = userControl;
            //fournisseur1.radTreeView = radTreeView2;
            //splitPanel3
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            // Chareger les boites et les dossiers
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string rqtNumBoites = "select distinct Numboite from DossiersIndexeV where id_status=3 order by Numboite";


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
                        var path = item["Chemin"].ToString();
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
        // Obtenir tous les documents d'une boite
        private DataTable getDocs(string numboite)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                var boite = numboite == "" ? "Numboite is null" : "Numboite = '" + numboite + "'";
                string reqdocs = "select * from DossiersIndexeV where id_status=3 and " + boite;

                SqlDataAdapter da = new SqlDataAdapter(reqdocs, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;           
            }
        }
        // selectioner un dossier
        private void Node_Changed(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                try
                {
                    radPdfViewer2.LoadDocument(e.Node.Value.ToString());
                    CurrentNode = e.Node;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Verifier le type de Document
                var type = e.Node.Tag.ToString();
                
                //  le nom du document
                var NomDoc = radTreeView2.SelectedNode.Text.Replace("'", "''");
                // Pour le type Achat/FOURNISSEUR

                if (type == "Achat/FOURNISSEUR")
                {
                    var row = getIndexs(e.Node.Text, "Achat").Rows[0];
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var frniss = new Fourniss()
                    {
                        controle = this,
                        NomDoc = NomDoc,
                        id_user_control = id_user_control,
                        Fournisseur = row["Fournisseur"].ToString(),
                        DateFacture = row["DateFacture"].ToString(),
                        Reference = row["Reference"].ToString(),
                        NumProjet = row["NumProjet"].ToString(),
                        NumBonCommande = row["NumBonCommande"].ToString(),
                        BU = row["BU"].ToString(),
                        NumBoite = row["NumBoite"].ToString()
                    };
                    foreach (Control item in splitPanel3.Controls)
                    {
                        if (item.GetType() == typeof(RadPanel))
                            continue;
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
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var client = new Cl()
                    {
                        controle = this,
                        NomDoc = NomDoc,
                        id_user_control = id_user_control,
                        Client = row["Client"].ToString(),
                        DateFacture = row["DateFacture"].ToString(),
                        Numfacture = row["Numfacture"].ToString(),
                        NumProjet = row["NumProjet"].ToString(),
                        BU = row["BU"].ToString(),
                        NumBoite = row["Numboite"].ToString()
                    };
                    foreach (Control item in splitPanel3.Controls)
                    {
                        if (item.GetType() == typeof(RadPanel))
                            continue;
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
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var banque = new Banque()
                    {
                        controle = this,
                        NomDoc = NomDoc,
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
                        if (item.GetType() == typeof(RadPanel))
                            continue;
                        item.Dispose();
                    }
                    splitPanel3.Controls.Add(banque);
                    banque.BringToFront();
                    banque.Dock = DockStyle.Fill;
                }
                // Pour le type CAISSE
                else if (type == "CAISSES")
                {
                    var row = getIndexs(e.Node.Text, "Caisse").Rows[0];
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var caisse = new Caisse()
                    {
                        controle = this,
                        NomDoc = NomDoc,
                        id_user_control = id_user_control,
                        DatePiece = row["DatePiece"].ToString(),
                        NumProjet = row["NumProjet"].ToString(),
                        BU = row["BU"].ToString(),
                        NumBoite = row["NumBoite"].ToString(),
                        Salarie = row["salarie"].ToString(),
                        NumImmatricule = row["NumDImatricul"].ToString(),
                        Reference = row["reference"].ToString(),
                    };
                    foreach (Control item in splitPanel3.Controls)
                    {
                        if (item.GetType() == typeof(RadPanel))
                            continue;
                        item.Dispose();
                    }
                    splitPanel3.Controls.Add(caisse);
                    caisse.BringToFront();
                    caisse.Dock = DockStyle.Fill;
                }
            }
        }    
        // obtenir les indexes d'un document
        private DataTable getIndexs(string nomDoss, string table)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string reqdocs = $"select * from {table} where NomDossier = '{nomDoss.Replace("'","''")}'";

                SqlDataAdapter da = new SqlDataAdapter(reqdocs, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        public void DelDocFromTreeView()
        {
            var docControle = CurrentNode;
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

        private void CalcTauxErr(string type, string user_index)
        {
            var req = $"SELECT  "
                    + $"count(nom_document) * 100 / (select Count(*) FROM DossiersIndexeV WHERE user_index = '{user_index}' and Type = '{type}') "
                    + $" FROM Modifications"
                    + $" WHERE user_index = '{user_index}'"
                    + $" and type_projet = '{type}'";
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                int tauxType = (int)new SqlCommand(req, cnn).ExecuteScalar();
                TxLabel.Text = $"{tauxType} %";
            }
        }
    }
}
