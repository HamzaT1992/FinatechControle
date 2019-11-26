using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace FinatechControle
{
    public partial class Cl : UserControl
    {
        public Controle controle;
        public string NomDoc;
        public string id_user_control;
        public string NumBoite;
        public string type = "Vente/Client";
        public string Client;
        public string DateFacture;
        public string Numfacture;
        public string NumProjet;
        public string BU;

        public Cl()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            TBClient.Text = Client;
            TBDateFacture.Text = DateFacture;
            TBNFacture.Text = Numfacture;
            TBNumProjet.Text = NumProjet;
            TBbu.Text = BU;
            TBNumBoite.Text = NumBoite;
        }

        private void validChanges_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> cl_Values = new Dictionary<string, string>()
            {
                {"Client", TBClient.Text},
                {"DateFacture", TBDateFacture.Text},
                {"Numfacture", TBNFacture.Text},
                {"NumProjet", TBNumProjet.Text},
                {"BU", TBbu.Text},
                {"NumBoite", TBNumBoite.Text},
            };

            // Verifier la saisie
            bool allgood = true;
            var errmsg = "Veillez remplir le champs";
            foreach (var item in cl_Values)
            {
                if (item.Value == "")
                {
                    allgood = false;
                    switch (item.Key)
                    {
                        case "Client":
                            errorProvider1.SetError(TBClient, errmsg);
                            break;
                        case "DateFacture":
                            errorProvider1.SetError(TBDateFacture, errmsg);
                            break;
                        case "Numfacture":
                            errorProvider1.SetError(TBNFacture, errmsg);
                            break;
                        case "NumProjet":
                            errorProvider1.SetError(TBNumProjet, errmsg);
                            break;
                        case "BU":
                            errorProvider1.SetError(TBbu, errmsg);
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
            ColumnModified.VerifyChanges(cl_Values, this);

            cl_Values["NumBoite"] = string.IsNullOrWhiteSpace(TBNumBoite.Text) ? "0" : TBNumBoite.Text;

            // update vente set [Client]= ,[DateFacture]= ,[Numfacture]= ,[NumProjet]= ,[BU]= ,[Numboite]= where [NomDossier]=
            var req = $"UPDATE vente SET [Client]='{cl_Values["Client"]}' ,[DateFacture]='{cl_Values["DateFacture"]}' ,[Numfacture]='{cl_Values["Numfacture"]}' ,[NumProjet]='{cl_Values["NumProjet"]}' ,[BU]='{cl_Values["BU"]}' ,[NumBoite]='{cl_Values["NumBoite"]}',id_status=6,id_user_control='{id_user_control}',date_control=GETDATE() WHERE [NomDossier]='{NomDoc}' " +
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
