using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Telerik.WinControls.UI;
using System.Reflection;

namespace FinatechControle
{
    public partial class Banque : UserControl
    {
        public Controle controle;
        public string NomDoc;
        public string id_user_control;
        public string NumBoite { get; set; }
        public string type = "BANQUES";
        public string NumOP { get; set; }
        public string NumSerieCheque { get; set; }
        public string Date { get; set; }
        public string Beneficiaire { get; set; }
        public string Reference { get; set; }
        public string Montant { get; set; }

        public Banque()
        {
            InitializeComponent();
        }

        private void Banque_Load(object sender, EventArgs e)
        {
            //,[NumOP]
            //,[NumSerieCheque]
            //,[Date]
            //,[Beneficiaire]
            //,[Reference]
            //,[Montant]
            //,[NumBoite]
            //,[NomDossier]
            TBNumOP.Text = NumOP;
            TBNumSerCk.Text = NumSerieCheque;
            TBDate.Text = Date;
            TBBeneficiaire.Text = Beneficiaire;
            TBReference.Text = Reference;
            TBMt.Text = Montant;
            TBNumBoite.Text = NumBoite;
        }

        private void ValidChanges_Click(object sender, EventArgs e)
        {
            
            Dictionary<string, string> bnq_Values = new Dictionary<string, string>()
            {
                {"NumOP", TBNumOP.Text},
                {"NumSerieCheque", TBNumSerCk.Text},
                {"Date", TBDate.Text},
                {"Beneficiaire", TBBeneficiaire.Text},
                {"Reference", TBReference.Text},
                {"Montant", TBMt.Text},
                {"NumBoite", TBNumBoite.Text}
            };

            // Verifier la saisie
            bool allgood = true;
            var errmsg = "Veillez remplir le champs";
            foreach (var item in bnq_Values)
            {
                if (item.Key == "Montant")
                    continue;
                if (item.Value == "")
                {
                    allgood = false;
                    switch (item.Key)
                    {
                        case "NumOP":
                            errorProvider1.SetError(TBNumOP, errmsg);
                            break;
                        case "Date":
                            errorProvider1.SetError(TBDate, errmsg);
                            break;
                        case "NumBoite":
                            errorProvider1.SetError(TBNumBoite, errmsg);
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

            ColumnModified.VerifyChanges(bnq_Values, this);


            bnq_Values["NumBoite"] = string.IsNullOrWhiteSpace(TBNumBoite.Text) ? "0" : TBNumBoite.Text;
            bnq_Values["Montant"] = string.IsNullOrWhiteSpace(Montant) ? "0" : Montant;

            // update vente set [Client]= ,[DateFacture]= ,[Numfacture]= ,[NumProjet]= ,[BU]= ,[Numboite]= where [NomDossier]=
            var req = $"UPDATE banque SET  [NumOP]='{bnq_Values["NumOP"]}' ,[NumSerieCheque]='{bnq_Values["NumSerieCheque"]}' ,[Date]='{bnq_Values["Date"]}' ,[Beneficiaire]='{bnq_Values["Beneficiaire"]}' ,[Reference]='{bnq_Values["Reference"]}' ,[Montant]={bnq_Values["Montant"]} ,[NumBoite]='{bnq_Values["NumBoite"]}' ,[id_status]=6 ,[id_user_control]={id_user_control},date_control=GETDATE() WHERE [NomDossier]='{NomDoc}' " +
                $"UPDATE FinaTech_Test.dbo.DossiersIndexes SET id_status=6 WHERE NomDossier='{NomDoc}'";
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                var cmd = new SqlCommand(req, cnn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Opération effectué!!");
            }
            // supprimer le document dans le treeView
            controle.DelDocFromTreeView();
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
