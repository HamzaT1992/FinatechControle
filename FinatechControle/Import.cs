using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Telerik.WinControls.UI;

namespace FinatechControle
{
    public partial class Import : UserControl
    {
        public Controle controle;
        public string NomDoc;
        public string id_user_control;
        public string NumBoite { get; set; }
        public string type = "IMPORT";

        public string NumDossier { get; set; }
        public string NumFactureFournisseurEtrange { get; set; }
        public string NumBonComndEtrnge { get; set; }
        public string NomFournisseurEtrange { get; set; }
        public string RefFactureFournisseurLocal1 { get; set; }
        public string NumBonComndFournisseurLocal1 { get; set; }
        public string RefFactureFournisseurLocal2 { get; set; }
        public string NumBonComndFournisseurLocal2 { get; set; }
        public string NumEngagementImport { get; set; }

        public Import()
        {
            InitializeComponent();
        }

        private void Import_Load(object sender, EventArgs e)
        {
            TB_numDoss.Text = NumDossier;
            TB_NFactFournEtrange.Text = NumFactureFournisseurEtrange;
            TB_numBCmdEtrange.Text = NumBonComndEtrnge;
            TB_NomFournEtrange.Text = NomFournisseurEtrange;
            TB_refFactFournLocal1.Text = RefFactureFournisseurLocal1;
            TB_numBonCmdFournLocal1.Text = NumBonComndFournisseurLocal1;
            TB_refFactFournLocal2.Text = RefFactureFournisseurLocal2;
            TB_numBonCmdFournLocal2.Text = NumBonComndFournisseurLocal2;
            TB_numEngagImport.Text = NumEngagementImport;
            TB_numBoite.Text = NumBoite;
        }

        private void validChanges_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Import_Values = new Dictionary<string, string>
            {
                { "NumDossier", TB_numDoss.Text },
                { "NumFactureFournisseurEtrange", TB_NFactFournEtrange.Text },
                { "NumBonComndEtrnge", TB_numBCmdEtrange.Text },
                { "NomFournisseurEtrange", TB_NomFournEtrange.Text },
                { "RefFactureFournisseurLocal1", TB_refFactFournLocal1.Text },
                { "NumBonComndFournisseurLocal1", TB_numBonCmdFournLocal1.Text },
                { "RefFactureFournisseurLocal2", TB_refFactFournLocal2.Text },
                { "NumBonComndFournisseurLocal2", TB_numBonCmdFournLocal2.Text },
                { "NumEngagementImport", TB_numEngagImport.Text },
                { "NumBoite", TB_numBoite.Text },
            };

            // Verifier les erreurs
            bool allgood = true;
            var errmsg = "Veillez remplir le champs";
            foreach (var item in Import_Values)
            {
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "NumDossier":
                            errorProvider1.SetError(TB_numDoss, errmsg);
                            allgood = false;
                            break;
                        case "NumFactureFournisseurEtrange":
                            errorProvider1.SetError(TB_NFactFournEtrange, errmsg);
                            allgood = false;
                            break;
                        case "NumBonComndEtrnge":
                            errorProvider1.SetError(TB_numBCmdEtrange, errmsg);
                            allgood = false;
                            break;
                        case "NomFournisseurEtrange":
                            errorProvider1.SetError(TB_NomFournEtrange, errmsg);
                            allgood = false;
                            break;
                        case "RefFactureFournisseurLocal1":
                            errorProvider1.SetError(TB_refFactFournLocal1, errmsg);
                            allgood = false;
                            break;
                        case "NumBonComndFournisseurLocal1":
                            errorProvider1.SetError(TB_numBonCmdFournLocal1, errmsg);
                            allgood = false;
                            break;
                        case "RefFactureFournisseurLocal2":
                            errorProvider1.SetError(TB_refFactFournLocal2, errmsg);
                            allgood = false;
                            break;
                        case "NumBonComndFournisseurLocal2":
                            errorProvider1.SetError(TB_numBonCmdFournLocal2, errmsg);
                            allgood = false;
                            break;
                        case "NumEngagementImport":
                            errorProvider1.SetError(TB_numEngagImport, errmsg);
                            allgood = false;
                            break;
                        case "NumBoite":
                            errorProvider1.SetError(TB_numBoite, errmsg);
                            allgood = false;
                            break;

                    }
                }
            }

            if (!allgood)
            {
                MessageBox.Show("Veillez remplir tous les champs nécessaire!!");
                return;
            }


            //verifier les chagements des colonnes
            Helper.VerifyChanges(Import_Values, this);

            Import_Values["NumBoite"] = string.IsNullOrWhiteSpace(TB_numBoite.Text) ? "0" : TB_numBoite.Text;

            Helper.CheckForQuote(ref Import_Values);

            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();

                // update vente set [Client]= ,[DateFacture]= ,[Numfacture]= ,[NumProjet]= ,[BU]= ,[Numboite]= where [NomDossier]=
                var req = $"UPDATE import SET [NumDossier]='{Import_Values["NumDossier"]}' ,[NumFactureFournisseurEtrange]='{Import_Values["NumFactureFournisseurEtrange"]}' ,[NumBonComndEtrnge]='{Import_Values["NumBonComndEtrnge"]}' ,[NomFournisseurEtrange]='{Import_Values["NomFournisseurEtrange"]}', [RefFactureFournisseurLocal1]='{Import_Values["RefFactureFournisseurLocal1"]}',[NumBonComndFournisseurLocal1]='{Import_Values["NumBonComndFournisseurLocal1"]}' ,[RefFactureFournisseurLocal2]={Import_Values["RefFactureFournisseurLocal2"]} ,[NumBonComndFournisseurLocal2]={Import_Values["NumBonComndFournisseurLocal2"]}, [NumEngagementImport]={Import_Values["NumEngagementImport"]} , [NumBoite]={Import_Values["NumBoite"]} ,[id_status]=6 ,[id_user_control]={id_user_control},date_control=GETDATE() WHERE [NomDossier]='{NomDoc}' ";

                var cmd = new SqlCommand(req, cnn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Opération effectué!!");
            }
            // supprimer le document dans le treeView
            controle.UpdateTreeView();
            controle.CalculeProdControl();
        }

        private void TB_numBoite_Validating(object sender, CancelEventArgs e)
        {
            RadTextBox tb = sender as RadTextBox;
            if (tb.Text == "")
            {
                errorProvider1.SetError(tb, "Veillez remplir le champs");
                errorProvider2.Clear();
            }
            else
            {
                errorProvider2.SetError(tb, "Correcte");
                errorProvider1.Clear();
            }
        }
    }
}
