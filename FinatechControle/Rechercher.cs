
using FinatechControle.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace FinatechControle
{
    public partial class Rechercher : Telerik.WinControls.UI.RadForm
    {
        public Controle controle { get; set; }
        public Rechercher(Controle controle)
        {
            this.controle = controle;
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (!controle.boiteOpen)
            {
                MessageBox.Show("Merci d'ouvrir une boite");
                return;
            }
            var numBoite = controle.CurrentBoite.Value.ToString();
            var table = ddlProjet.Text;
            var champs = ddlChamps.Text;
            var rechValue = tb_rechValue.Text;
            if (string.IsNullOrEmpty(table) || string.IsNullOrEmpty(champs) || string.IsNullOrEmpty(rechValue))
            {
                return;
            }
            var req = $"select NomDossier from {table} where numboite={numBoite} and {champs}=@rechVal";
            var conStr = ConfigurationManager.ConnectionStrings["StrCon"].ToString();
            using (var con = new SqlConnection(conStr))
            {
                con.Open();
                var da = new SqlDataAdapter(req, con);
                da.SelectCommand.Parameters.AddWithValue("@rechVal", rechValue.Replace("'","''"));
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Introuvable");
                    return;
                }
                else
                {
                    //var doss = dt.Rows[0][0].ToString();
                    //var upReq = $"update {table} set id_status=19 where NomDossier='{doss}'";
                    //new SqlCommand(upReq, con).ExecuteNonQuery();
                    //controle.radTree.SelectedNode = controle.CurrentDoc = controle.CurrentBoite.Nodes.SingleOrDefault(n => n.Name == doss);
                    //controle.CurrentDoc.Image = Resources.blueFolder;
                    //var data = (NodeData)controle.CurrentDoc.Tag;
                    //data.image = "blueFolder";
                    radGridView1.DataSource = dt;

                }
            }
        }

        private void ddlProjet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            switch (ddlProjet.Text)
            {
                case "Achat":
                    ddlChamps.Items.Clear();
                    ddlChamps.Items.Add("Fournisseur");
                    ddlChamps.Items.Add("DateFacture");
                    ddlChamps.Items.Add("NumProjet");
                    ddlChamps.Items.Add("NumBonCommande");
                    ddlChamps.Items.Add("Reference");
                    ddlChamps.Items.Add("BU");
                    break;
                case "Vente":
                    ddlChamps.Items.Clear();
                    ddlChamps.Items.Add("Client");
                    ddlChamps.Items.Add("DateFacture");
                    ddlChamps.Items.Add("Numfacture");
                    ddlChamps.Items.Add("NumProjet");
                    ddlChamps.Items.Add("BU");
                    break;
                case "Banque":
                    ddlChamps.Items.Clear();
                    ddlChamps.Items.Add("NumOP");
                    ddlChamps.Items.Add("NumSerieCheque");
                    ddlChamps.Items.Add("Date");
                    ddlChamps.Items.Add("Beneficiaire");
                    ddlChamps.Items.Add("Reference");
                    ddlChamps.Items.Add("Montant");
                    break;
                case "Caisse":
                    ddlChamps.Items.Clear();
                    ddlChamps.Items.Add("DatePiece");
                    ddlChamps.Items.Add("NumProjet");
                    ddlChamps.Items.Add("BU");
                    ddlChamps.Items.Add("Reference");
                    ddlChamps.Items.Add("NumDImatricul");
                    ddlChamps.Items.Add("Salarie");
                    break;
                case "Import":
                    ddlChamps.Items.Clear();
                    ddlChamps.Items.Add("NumDossier");
                    ddlChamps.Items.Add("NumFactureFournisseurEtrange");
                    ddlChamps.Items.Add("NumBonComndEtrnge");
                    ddlChamps.Items.Add("NomFournisseurEtrange");
                    ddlChamps.Items.Add("RefFactureFournisseurLocal1");
                    ddlChamps.Items.Add("NumBonComndFournisseurLocal1");
                    ddlChamps.Items.Add("RefFactureFournisseurLocal2");
                    ddlChamps.Items.Add("NumBonComndFournisseurLocal2");
                    ddlChamps.Items.Add("NumEngagementImport");
                    break;
                default:
                    ddlChamps.Items.Clear();
                    break;
            }
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            var doss = radGridView1.CurrentRow.Cells["NomDossier"].Value.ToString();
            controle.radTree.SelectedNode = controle.CurrentDoc = controle.CurrentBoite.Nodes.SingleOrDefault(n => n.Name == doss); 
        }
    }
}
