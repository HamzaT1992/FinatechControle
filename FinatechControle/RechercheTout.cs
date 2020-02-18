using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace FinatechControle
{
    public partial class RechercheTout : Telerik.WinControls.UI.RadForm
    {
        public Controle controle { get; set; }
        public RechercheTout(Controle controle)
        {
            InitializeComponent();
            this.controle = controle;
        }

        private void RechercheTout_Load(object sender, EventArgs e)
        {
            dd_proj.Items.Add("Achat");
            dd_proj.Items.Add("Banque");
            dd_proj.Items.Add("Caisse");
            dd_proj.Items.Add("Import");
            dd_proj.Items.Add("Vente");



        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            var table = dd_proj.Text;
            var champs = dd_champs.Text;
            var rechValue = tb_rechValue.Text;
            if (string.IsNullOrEmpty(table) || string.IsNullOrEmpty(champs) || string.IsNullOrEmpty(rechValue))
            {
                return;
            }
            var req = $"select * from {table} where {champs}=@rechVal";
            var conStr = ConfigurationManager.ConnectionStrings["StrCon"].ToString();
            using (var con = new SqlConnection(conStr))
            {
                con.Open();
                var da = new SqlDataAdapter(req, con);
                da.SelectCommand.Parameters.AddWithValue("@rechVal", rechValue.Replace("'", "''"));
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
                    radGridView1.DataSource = null;
                    radGridView1.DataSource = dt;

                }
            }
        }

        private void dd_proj_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            switch (dd_proj.Text)
            {
                case "Achat":
                    dd_champs.Items.Clear();
                    dd_champs.Items.Add("Fournisseur");
                    dd_champs.Items.Add("DateFacture");
                    dd_champs.Items.Add("NumProjet");
                    dd_champs.Items.Add("NumBonCommande");
                    dd_champs.Items.Add("Reference");
                    dd_champs.Items.Add("BU");
                    break;
                case "Vente":
                    dd_champs.Items.Clear();
                    dd_champs.Items.Add("Client");
                    dd_champs.Items.Add("DateFacture");
                    dd_champs.Items.Add("Numfacture");
                    dd_champs.Items.Add("NumProjet");
                    dd_champs.Items.Add("BU");
                    break;
                case "Banque":
                    dd_champs.Items.Clear();
                    dd_champs.Items.Add("NumOP");
                    dd_champs.Items.Add("NumSerieCheque");
                    dd_champs.Items.Add("Date");
                    dd_champs.Items.Add("Beneficiaire");
                    dd_champs.Items.Add("Reference");
                    dd_champs.Items.Add("Montant");
                    break;
                case "Caisse":
                    dd_champs.Items.Clear();
                    dd_champs.Items.Add("DatePiece");
                    dd_champs.Items.Add("NumProjet");
                    dd_champs.Items.Add("BU");
                    dd_champs.Items.Add("Reference");
                    dd_champs.Items.Add("NumDImatricul");
                    dd_champs.Items.Add("Salarie");
                    break;
                case "Import":
                    dd_champs.Items.Clear();
                    dd_champs.Items.Add("NumDossier");
                    dd_champs.Items.Add("NumFactureFournisseurEtrange");
                    dd_champs.Items.Add("NumBonComndEtrnge");
                    dd_champs.Items.Add("NomFournisseurEtrange");
                    dd_champs.Items.Add("RefFactureFournisseurLocal1");
                    dd_champs.Items.Add("NumBonComndFournisseurLocal1");
                    dd_champs.Items.Add("RefFactureFournisseurLocal2");
                    dd_champs.Items.Add("NumBonComndFournisseurLocal2");
                    dd_champs.Items.Add("NumEngagementImport");
                    break;
                default:
                    dd_champs.Items.Clear();
                    break;
            }
        }


    }
}
