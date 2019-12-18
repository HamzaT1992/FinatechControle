using FinatechControle.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        RadTreeNode CurrentNode = new RadTreeNode();

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
            openxml.Click += Openxml_Click;
            rescan.Click += Rescan_Click;
            nodeCopyName.Click += NodeCopyName_Click;
            // Chareger les boites et les dossiers
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string rqtNumBoites = "select distinct NumBoite from DossiersIndexeV where id_status in (3,6) order by NumBoite";


                SqlDataAdapter da = new SqlDataAdapter(rqtNumBoites, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                

                foreach (DataRow row in dt.Rows)
                {
                    
                    RadTreeNode boite = new RadTreeNode();
                    var numBoite = row["Numboite"].ToString();
                    
                    boite.Value = numBoite;
                    var Docs = getDocs(numBoite);
                    var alldocsCount = Docs.Rows.Count;
                    int Fl_oks = 0;
                    foreach (DataRow item in Docs.Rows)
                    {
                        RadTreeNode doc = new RadTreeNode();
                        var user_index = item["user_index"].ToString();
                        var doss = item["NomDossier"].ToString();
                        //var pdf = doss.Split('\\')[1];
                        var path = item["Chemin"].ToString();

                        var statusDoc = (int)item["id_status"];
                        var image = "folder_closed";
                        if (statusDoc == 6)
                        {
                            Fl_oks++;
                            image = "folder_ok";
                        }
                        doc.Text = $"({user_index}) {doss}";
                        doc.Value = path;
                        doc.Tag = new NodeData {
                            type = item["type"].ToString(),
                            NomDoc = doss,
                            xmlPath = Path.GetDirectoryName(path) + ".xml",
                            status = statusDoc
                        };
                        doc.Image = statusDoc == 3 ? Resources.folder_closed : Resources.folder_ok;
                        doc.ToolTipText = doss;
                        doc.ContextMenu = radContextMenu1;
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
                    Bitmap img = Resources.boite2;

                    if (Fl_oks > 0 && Fl_oks < alldocsCount)
                    {
                        img = Resources.boite_edit;
                    }
                    else if (Fl_oks == alldocsCount)
                    {
                        img = Resources.boite_ok;
                    }
                    boite.Image = img;
                    radTreeView2.Nodes.Add(boite);
                }

            }
        }

        private void NodeCopyName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(((NodeData)CurrentNode.Tag).NomDoc);
        }

        private void Rescan_Click(object sender, EventArgs e)
        {

            Process.Start("explorer.exe", Path.GetDirectoryName(CurrentNode.Value.ToString()));

        }

        private void Openxml_Click(object sender, EventArgs e)
        {
            var data = (NodeData)CurrentNode.Tag;
            Process.Start("iexplore", data.xmlPath);
        }

        // Obtenir tous les documents d'une boite
        private DataTable getDocs(string numboite)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                //var boite = numboite == "" ? "Numboite is null" : "Numboite = '" + numboite + "'";
                //string reqdocs = "select * from DossiersIndexeV where id_status in (3,6) and " + boite;
                string reqdocs = "select * from DossiersIndexeV where id_status in (3,6) and convert(int,NumBoite) = "+numboite;

                SqlDataAdapter da = new SqlDataAdapter(reqdocs, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;           
            }
        }
        // sélectionner un dossier
        private void Node_Changed(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                try
                {
                    radPdfViewer2.LoadDocument(e.Node.Value.ToString());
                    var CrData = (NodeData)CurrentNode.Tag;
                    if (CrData != null)
                    {
                        if (CrData.image == "folder" && CrData.status == 3)
                        {
                            CurrentNode.Image = Resources.folder_closed;
                            ((NodeData)CurrentNode.Tag).image = "folder_closed";
                        }
                        else if (CrData.image == "folder" && CrData.status == 6)
                        {
                            CurrentNode.Image = Resources.folder_ok;
                            ((NodeData)CurrentNode.Tag).image = "folder_ok";
                        }
                    }
                    CurrentNode = e.Node;
                    CurrentNode.Image = Resources.folder;
                    ((NodeData)CurrentNode.Tag).image = "folder";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                var nodedata = (NodeData)e.Node.Tag;
                // Verifier le type de Document
                var type = nodedata.type;
                //  le nom du document
                var NomDoc = nodedata.NomDoc;
                // Pour le type Achat/FOURNISSEUR

                if (type == "Achat/FOURNISSEUR")
                {
                    var row = getIndexs(NomDoc, "Achat").Rows[0];
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var frniss = new Fourniss()
                    {
                        controle = this,
                        NomDoc = NomDoc.Replace("'", "''"),
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
                    var row = getIndexs(NomDoc, "Vente").Rows[0];
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var client = new Cl()
                    {
                        controle = this,
                        NomDoc = NomDoc.Replace("'", "''"),
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
                    var row = getIndexs(NomDoc, "banque").Rows[0];
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var banque = new Banque()
                    {
                        controle = this,
                        NomDoc = NomDoc.Replace("'", "''"),
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
                    var row = getIndexs(NomDoc, "Caisse").Rows[0];
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var caisse = new Caisse()
                    {
                        controle = this,
                        NomDoc = NomDoc.Replace("'", "''"),
                        id_user_control = id_user_control,
                        DatePiece = row["DatePiece"].ToString(),
                        NumProjet = row["NumProjet"].ToString(),
                        BU = row["BU"].ToString(),
                        NumBoite = row["NumBoite"].ToString(),
                        Salarie = row["salarie"].ToString(),
                        NumDImatricul = row["NumDImatricul"].ToString(),
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
                string reqdocs = $"select * from {table} where NomDossier = @nomdoc";

                SqlDataAdapter da = new SqlDataAdapter(reqdocs, cnn);
                da.SelectCommand.Parameters.AddWithValue("@nomdoc", nomDoss);
                
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        public void UpdateTreeView()
        {
            CurrentNode.Image = Resources.folder_ok;
            ((NodeData)CurrentNode.Tag).image = "folder_ok";
            ((NodeData)CurrentNode.Tag).status = 6;
            var docControle = CurrentNode;
            var parent = docControle.Parent;

            radTreeView2.SelectedNode = docControle.NextNode??CurrentNode;
            var allnodes = parent.Nodes.Count;
            var nodeok = 0;
            foreach (var item in parent.Nodes)
            {
                if (((NodeData)item.Tag).status == 6)
                {
                    nodeok++;
                }
            }
            if (nodeok > 0 && nodeok < allnodes)
            {
                parent.Image = Resources.boite_edit;
            }
            else if (nodeok == allnodes)
            {
                parent.Image = Resources.boite_ok;
                parent.Collapse();
            }
        }

        private void RadForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void CalcTauxErr(string type, string user_index)
        {
            var req = $"SELECT  "
                    + $"ROUND(cast(count(DISTINCT nom_document) * 100 as FLOAT) / cast((select Count(*) FROM DossiersIndexeV WHERE user_index = '{user_index}' and Type = '{type}') as FLOAT),2)"
                    + $" FROM Modifications"
                    + $" WHERE user_index = '{user_index}'"
                    + $" and type_projet = '{type}'";
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                var tauxType = new SqlCommand(req, cnn).ExecuteScalar().ToString();
                TxLabel.Text = $"{tauxType}%";
            }
        }

    }
}
