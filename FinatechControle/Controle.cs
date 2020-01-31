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
using System.Xml.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace FinatechControle
{
    public partial class Controle : RadForm
    {
        // id utilisateur de controle
        string id_user_control;
        string status;
        string operation;

        public bool boiteOpen = false;
        public RadTreeView radTree;
        public RadTreeNode CurrentBoite = new RadTreeNode();
        public RadTreeNode CurrentDoc = new RadTreeNode();

        public Controle(string id_user, string userControl, string operation)
        {
            InitializeComponent();
            radTree = radTreeView2;
            id_user_control = id_user;
            //var Boites = new RadTreeNode();
            //Boites.Text = "Boites";
            radTreeView2.SelectedNodeChanged += Node_Changed;
            radLabel3.Text = userControl;
            //fournisseur1.radTreeView = radTreeView2;
            //splitPanel3
            this.operation = operation;
            status = operation == "Indexations" ? "in (3,4)" : " = 12";
            CalculeProdControl();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            //Menu Application
            rechercheBoite.Click += SearchInBoite_Click;
            // menu Boites
            openBoite.Click += OpenBoite_Click;
            //toInstance.Click += ToInstance_Click;
            closeBoite.Click += CloseBoite_Click;
            //searchInBoite.Click += SearchInBoite_Click;
            toInstance.Enabled = closeBoite.Enabled = false;
            // menu Documents
            openxml.Click += Openxml_Click;
            rescan.Click += Rescan_Click;
            nodeCopyName.Click += NodeCopyName_Click;
            //delete.Click += Delete_Click;
            // Chareger les boites et les dossiers
            LoadBoites();
            var c = radTreeView2.Nodes.Count;
            // Calcule du total prod
            CalculeProdControl();
        }

        public void LoadBoites()
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string affect = operation == "Indexations" ? $"AND user_affect = {id_user_control}" : "";

                string rqtNumBoites = $"SELECT DISTINCT NumBoite,rtrim(login) userAffect FROM boite b join Administration_ANCFCC.dbo.TB_Utilisateurs u on b.user_affect=u.id_user --WHERE id_status {status} {affect} ORDER BY NumBoite";

                SqlDataAdapter da = new SqlDataAdapter(rqtNumBoites, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                try
                {
                    // TreeNode adds changes here
                    foreach (DataRow row in dt.Rows)
                    {

                        RadTreeNode boite = new RadTreeNode();
                        boite.ContextMenu = boiteContextMenu;
                        var userAffect = row["userAffect"].ToString();
                        var numBoite = row["Numboite"].ToString();

                        boite.Value = numBoite;
                        var Docs = getDocs(numBoite);


                        //Boites.Nodes.Add(boite);
                        boite.Text = $"Boite {numBoite} [{userAffect}] ({Docs.Rows.Count})";
                        boite.Tag = Docs.Rows.Count;
                        Bitmap img = Resources.boite2;
                        var bStatus = GetBoiteStatus(Docs);
                        if (bStatus == 4)
                        {
                            img = Resources.boite_edit;
                        }
                        else if (bStatus == 6)
                        {
                            img = Resources.boite_ok;
                        }
                        boite.Image = img;
                        radTreeView2.Nodes.Add(boite);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SearchInBoite_Click(object sender, EventArgs e)
        {
            new Rechercher(this).ShowDialog();
        }

        private void CloseBoite_Click(object sender, EventArgs e)
        {
            CurrentBoite.Nodes.Clear();
            openBoite.Enabled = true;
            closeBoite.Enabled = boiteOpen = false;
            //if (CurrentBoite != radTreeView2.SelectedNode)
            //{
            //    MessageBox.Show($"Veuillez cloturer la boite {CurrentBoite.Value.ToString()}");
            //}
            //else
            //{
            //    DialogResult result = MessageBox.Show($"Vous êtes sur de cloturer la boite","Verrification",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.Yes)
            //    {
            //        var conStr = ConfigurationManager.ConnectionStrings["StrCon"].ToString();
            //        using (var con = new SqlConnection(conStr))
            //        {
            //            con.Open();

            //            var docs = getDocs(CurrentBoite.Value.ToString());
            //            var bStatus = GetBoiteStatus(docs);
            //            if (bStatus == 4)
            //            {
            //                MessageBox.Show($"Merci de valider tous les document avant de cloturer la boite", "Verrification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                return;
            //            }
            //            else
            //            {
            //                var req = $"update boite set id_status = 6 where numboite = {CurrentBoite.Value}";
            //                new SqlCommand(req, con).ExecuteNonQuery();
            //                CurrentBoite.Remove();
            //                openBoite.Enabled = true;
            //                toInstance.Enabled = closeBoite.Enabled = boiteOpen = false;
            //            }
            //        }
            //    }
               //}
        }

        //private void ToInstance_Click(object sender, EventArgs e)
        //{
        //    if (CurrentBoite != radTreeView2.SelectedNode)
        //    {
        //        MessageBox.Show($"Veuillez cloturer la boite {CurrentBoite.Value.ToString()}");
        //    }
        //    else
        //    {
        //        CurrentBoite.Nodes.Clear();
        //        var conStr = ConfigurationManager.ConnectionStrings["StrCon"].ToString();
        //        using (var con = new SqlConnection(conStr))
        //        {
        //            con.Open();

        //            var docs = getDocs(CurrentBoite.Value.ToString());
        //            var bStatus = GetBoiteStatus(docs);

        //            var req = $"update boite set id_status = 4 where numboite = {CurrentBoite.Value}";
        //            new SqlCommand(req, con).ExecuteNonQuery();
        //            openBoite.Enabled = true;
        //            toInstance.Enabled = closeBoite.Enabled = boiteOpen = false;
        //        }
        //    }
        //}

        private void OpenBoite_Click(object sender, EventArgs e)
        {
            
            if (radTreeView2.SelectedNode.Level == 0)
            {
                CurrentBoite = radTreeView2.SelectedNode;
                openBoite.Enabled = false;
                closeBoite.Enabled = boiteOpen = true;

                var Docs = getDocs(CurrentBoite.Value.ToString());

                foreach (DataRow item in Docs.Rows)
                {
                    RadTreeNode doc = new RadTreeNode();
                    var user_index = item["user_index"].ToString();
                    var doss = item["NomDossier"].ToString();
                    //var pdf = doss.Split('\\')[1];
                    var path = item["Chemin"].ToString();

                    var statusDoc = (int)item["id_status"];
                    var image = "folder_closed";
                    doc.Image = Resources.folder_closed;
                    if (statusDoc == 6)
                    {
                        image = "folder_ok";
                        doc.Image = Resources.folder_ok;
                    }
                    else if (statusDoc == 18)
                    {
                        image = "folder_error";
                        doc.Image = Resources.folder_error;
                    }
                    else if(statusDoc == 19)
                    {
                        image = "blueFolder";
                        doc.Image = Resources.blueFolder;
                    }
                    doc.Name = doss;
                    doc.Text = $"({user_index}) {doss}";
                    doc.Value = path;
                    doc.Tag = new NodeData
                    {
                        type = item["type"].ToString(),
                        NomDoc = doss,
                        xmlPath = Path.GetDirectoryName(path) + ".xml",
                        status = statusDoc,
                        image = image
                    };

                    doc.ToolTipText = doss;
                    doc.ContextMenu = docContextMenu;

                    CurrentBoite.Nodes.Add(doc);
                }
                CurrentBoite.Expand();
            }

        }

        public void CalculeProdControl()
        {
            //<html><strong>Login : </strong></html>
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                string rqt  =  $"SELECT COUNT(*) FROM DossiersIndexeV " +
                                        $"WHERE id_status in(6,11) " +
                                        $"AND id_user_control = {id_user_control} " +
                                        $"AND CONVERT(date,date_control,101) = '{date}'";

                var count = new SqlCommand(rqt, cnn).ExecuteScalar().ToString();
                lb_prod.Text = $"<html><strong>Prod {date} : {count}</strong></html>";
            }
        }

        private void NodeCopyName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(((NodeData)CurrentDoc.Tag).NomDoc);
        }

        private void Rescan_Click(object sender, EventArgs e)
        {

            Process.Start("explorer.exe", Path.GetDirectoryName(CurrentDoc.Value.ToString()));
        }

        private void Openxml_Click(object sender, EventArgs e)
        {
            var data = (NodeData)CurrentDoc.Tag;
            //Process.Start("notepadplus", data.xmlPath);
            var SourcePath = "";
            var xmlDoc = XElement.Load(data.xmlPath);

            var el = xmlDoc.Element("Documents");
            if (el != null)
            {
                SourcePath = el.Element("Document").Element("Images").Element("Image").Attribute("SourcePath").Value;
            }
            else
            {
                SourcePath = xmlDoc.Element("Images").Element("Image").Attribute("SourcePath").Value;
            }
            MessageBox.Show(SourcePath);
        }

        //private void Delete_Click(object sender, EventArgs e)
        //{
        //    var data = (NodeData)CurrentDoc.Tag;
        //    data.status = 18;
        //    CurrentDoc.Image = Resources.folder_error;
        //    var table = GetDocTable();

        //    var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
        //    using (SqlConnection cnn = new SqlConnection(constr))
        //    {
        //        cnn.Open();
        //        //var boite = numboite == "" ? "Numboite is null" : "Numboite = '" + numboite + "'";
        //        //string reqdocs = "select * from DossiersIndexeV where id_status in (3,6) and " + boite;
        //        string reqdocs = $"update {table} set id_status = 18 where NomDossier='{data.NomDoc.Replace("'","''")}'";
        //        new SqlCommand(reqdocs, cnn).ExecuteNonQuery();
        //    }
        //}
        // Obtenir tous les documents d'une boite
        private DataTable getDocs(string numboite)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                //var boite = numboite == "" ? "Numboite is null" : "Numboite = '" + numboite + "'";
                //string reqdocs = "select * from DossiersIndexeV where id_status in (3,6) and " + boite;
                string reqdocs = $"select * from DossiersIndexeV where NumBoite = "+numboite;

                SqlDataAdapter da = new SqlDataAdapter(reqdocs, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;           
            }
        }

        private string GetDocTable()
        {
            var data = (NodeData)CurrentDoc.Tag;

            var table = "";
            switch (data.type)
            {
                case "Achat/FOURNISSEUR":
                    table = "achat";
                    break;
                case "Vente/Client":
                    table = "vente";
                    break;
                case "BANQUES":
                    table = "banque";
                    break;
                case "CAISSES":
                    table = "caisse";
                    break;
                case "Import":
                    table = "import";
                    break;

            }
            return table;
        }

        private int GetBoiteStatus(DataTable Docs)
        {
            var alldocsCount = Docs.Rows.Count;
            int Fl_oks = 0;
            int status = 0;
            foreach (DataRow item in Docs.Rows)
            {
                var statusDoc = (int)item["id_status"];
                if (statusDoc == 6 || statusDoc == 18)
                {
                    Fl_oks++;
                }
            }
            if (Fl_oks > 0 && Fl_oks < alldocsCount)
            {
                status = 4;
            }
            else if (Fl_oks == alldocsCount)
            {
                status = 6;
            }
            return status;
        }
        // sélectionner un dossier
        private void Node_Changed(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }
            if (e.Node.Level == 1)
            {
                try
                {
                    radPdfViewer2.LoadDocument(e.Node.Value.ToString());
                    var CrData = (NodeData)CurrentDoc.Tag;
                    if (CrData != null)
                    {
                        if (CrData.image == "folder" && CrData.status == 3)
                        {
                            CurrentDoc.Image = Resources.folder_closed;
                            ((NodeData)CurrentDoc.Tag).image = "folder_closed";
                        }
                        else if (CrData.image == "folder" && CrData.status == 6)
                        {
                            CurrentDoc.Image = Resources.folder_ok;
                            ((NodeData)CurrentDoc.Tag).image = "folder_ok";
                        }
                        else if (CrData.image == "folder" && CrData.status == 18)
                        {
                            CurrentDoc.Image = Resources.folder_error;
                            ((NodeData)CurrentDoc.Tag).image = "folder_error";
                        }                        
                        else if (CrData.image == "folder" && CrData.status == 19)
                        {
                            CurrentDoc.Image = Resources.blueFolder;
                            ((NodeData)CurrentDoc.Tag).image = "blueFolder";
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                CurrentDoc = e.Node;
                CurrentDoc.Image = Resources.folder;
                ((NodeData)CurrentDoc.Tag).image = "folder";
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
                // Pour le type import
                else if (type == "IMPORT")
                {
                    var row = getIndexs(NomDoc, "import").Rows[0];
                    radLabel2.Text = row["user_index"].ToString();
                    CalcTauxErr(type, row["user_index"].ToString());
                    var import = new Import()
                    {
                        controle = this,
                        NomDoc = NomDoc.Replace("'", "''"),
                        id_user_control = id_user_control,
                        NumDossier = row["NumDossier"].ToString(),
                        NumFactureFournisseurEtrange = row["NumFactureFournisseurEtrange"].ToString(),
                        NumBonComndEtrnge = row["NumBonComndEtrnge"].ToString(),
                        NomFournisseurEtrange = row["NomFournisseurEtrange"].ToString(),
                        RefFactureFournisseurLocal1 = row["RefFactureFournisseurLocal1"].ToString(),
                        NumBonComndFournisseurLocal1 = row["NumBonComndFournisseurLocal1"].ToString(),
                        RefFactureFournisseurLocal2 = row["RefFactureFournisseurLocal2"].ToString(),
                        NumBonComndFournisseurLocal2 = row["NumBonComndFournisseurLocal2"].ToString(),
                        NumEngagementImport = row["NumEngagementImport"].ToString(),
                        NumBoite = row["NumBoite"].ToString()
                    };
                    foreach (Control item in splitPanel3.Controls)
                    {
                        if (item.GetType() == typeof(RadPanel))
                            continue;
                        item.Dispose();
                    }
                    splitPanel3.Controls.Add(import);
                    import.BringToFront();
                    import.Dock = DockStyle.Fill;
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
            CurrentDoc.Image = Resources.folder_ok;
            ((NodeData)CurrentDoc.Tag).image = "folder_ok";
            ((NodeData)CurrentDoc.Tag).status = 6;
            var docControle = CurrentDoc;
            var parent = docControle.Parent;

            radTreeView2.SelectedNode = docControle.NextNode??CurrentDoc;
            var allnodes = parent.Nodes.Count;
            var nodeok = 0;
            //foreach (var item in parent.Nodes)
            //{
            //    if (((NodeData)item.Tag).status == 6)
            //    {
            //        nodeok++;
            //    }
            //}
            //if (nodeok > 0 && nodeok < allnodes)
            //{
            //    parent.Image = Resources.boite_edit;
            //}
            //else if (nodeok == allnodes)
            //{
            //    parent.Image = Resources.boite_ok;
            //    parent.Collapse();
            //}
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

        private void radTreeView2_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                MessageBox.Show(e.Node.Value.ToString());
                //var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
                //using (SqlConnection cnn = new SqlConnection(constr))
                //{
                //    cnn.Open();

                //    var Docs = getDocs(e.Node.Value.ToString());
                //    foreach (DataRow item in Docs.Rows)
                //    {
                //        e.Node
                //    }
                //}
            }
        }

        private void affectBoite_Click(object sender, EventArgs e)
        {
            new AffecterBoites(this).ShowDialog();
        }

        private void radTreeView2_SelectedNodesChanged(object sender, RadTreeViewEventArgs e)
        {
            if (radTreeView2.SelectedNode.Level == 0)
            {
                lb_boitesSelected.Text = $"{radTreeView2.SelectedNodes.Count} Boite(s) Sélectionnées";
            }
        }
    }
}
