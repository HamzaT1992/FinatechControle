using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using FinatechControle.Properties;
using Telerik.WinControls.UI;

namespace FinatechControle
{
    public partial class Fourniss : UserControl
    {
        public Controle controle;
        public string NomDoc;
        public string id_user_control;
        public string NumBoite { get; set; }
        public string type = "Achat/FOURNISSEUR";
        public string Fournisseur { get; set; }
        public string DateFacture { get; set; }
        public string Reference { get; set; }
        public string NumProjet { get; set; }
        public string NumBonCommande { get; set; }
        public string BU { get; set; }

        public Fourniss()
        {
            InitializeComponent();
        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {
            TBFournisseur.Text = Fournisseur;
            TBDateFacture.Text = DateFacture;
            TBReference.Text = Reference;
            TBNumProjet.Text = NumProjet;
            TBNumBonCom.Text = NumBonCommande;
            TBbu.Text = BU;
            TBNumBoite.Text = NumBoite;
        }

        private void ValidChanges_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Fourn_Values = new Dictionary<string, string>
            {
                { "Fournisseur", TBFournisseur.Text },
                { "DateFacture", TBDateFacture.Text },
                { "NumProjet", TBNumProjet.Text },
                { "NumBonCommande", string.IsNullOrWhiteSpace(TBNumBonCom.Text) ? "" : TBNumBonCom.Text },
                { "NumBoite", TBNumBoite.Text },
                { "Reference", TBReference.Text },
                { "BU", TBbu.Text }
            };
            // Verifier la saisie
            bool allgood = true;
            var errmsg = "Veillez remplir le champs";
            foreach (var item in Fourn_Values)
            {
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "Fournisseur":
                            errorProvider1.SetError(TBFournisseur, errmsg);
                            allgood = false;
                            break;
                        case "DateFacture":
                            errorProvider1.SetError(TBDateFacture, errmsg);
                            allgood = false;
                            break;
                        case "NumBoite":
                            errorProvider1.SetError(TBNumBoite, errmsg);
                            allgood = false;
                            break;
                        case "Reference":
                            errorProvider1.SetError(TBReference, errmsg);
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
            Helper.VerifyChanges(Fourn_Values, this);

            Fourn_Values["NumBoite"] = TBNumBoite.Text == "" ? "0" : TBNumBoite.Text;

            Helper.CheckForQuote(ref Fourn_Values);
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();

                // update vente set [Client]= ,[DateFacture]= ,[Numfacture]= ,[NumProjet]= ,[BU]= ,[Numboite]= where [NomDossier]=
                var req = $"UPDATE achat SET  [Fournisseur]='{Fourn_Values["Fournisseur"]}' ,[DateFacture]='{Fourn_Values["DateFacture"]}' ,[Reference]='{Fourn_Values["Reference"]}' ,[NumBonCommande]='{Fourn_Values["NumBonCommande"]}', [NumProjet]='{Fourn_Values["NumProjet"]}',[BU]='{Fourn_Values["BU"]}' ,[NumBoite]={Fourn_Values["NumBoite"]} ,[id_status]=6 ,[id_user_control]={id_user_control},date_control=GETDATE() WHERE [NomDossier]='{NomDoc}' ";

                var cmd = new SqlCommand(req, cnn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Opération effectué!!");
            }
            // supprimer le document dans le treeView
            controle.UpdateTreeView();
            controle.CalculeProdControl();
        }

        private void TB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RadTextBox tb = sender as RadTextBox;
            if (tb.Text == "")
            {
                errorProvider1.SetError(tb, "Veillez remplir le champs");
            }
            else
            {
                errorProvider2.SetError(tb, "Correcte");
            }
        }
    }
}
