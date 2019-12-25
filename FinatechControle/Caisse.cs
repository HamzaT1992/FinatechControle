using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace FinatechControle
{
    public partial class Caisse : UserControl
    {
        public Controle controle;
        public string NomDoc;
        public string id_user_control;
        public string NumBoite { get; set; }
        public string type = "CAISSES";
        public string NumDImatricul { get; set; }
        public string DatePiece { get; set; }
        public string Salarie { get; set; }
        public string Reference { get; set; }
        public string BU { get; set; }
        public string NumProjet { get; set; }

        public Caisse()
        {
            InitializeComponent();
        }

        private void Caisse_Load(object sender, EventArgs e)
        {
            TBDatePiece.Text = DatePiece;
            TBBU.Text = BU;
            TBNProjet.Text = NumProjet;
            TBNumBoite.Text = NumBoite;
            TBNumImm.Text = NumDImatricul;
            TBSalarie.Text = Salarie;
            TBReference.Text = Reference;
        }

        private void ValidChanges_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> cs_Values = new Dictionary<string, string>()
            {
                {"DatePiece", TBDatePiece.Text},
                {"NumProjet", TBNProjet.Text},
                {"BU", TBBU.Text},
                {"Reference", TBReference.Text},
                {"NumDImatricul", TBNumImm.Text},
                {"Salarie", TBSalarie.Text},
                {"NumBoite", TBNumBoite.Text},
            };

            // Verifier la saisie

            bool allgood = true;
            var errmsg = "Veillez remplir le champs";
            foreach (var item in cs_Values)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    
                    switch (item.Key)
                    {
                        case "DatePiece":
                            errorProvider1.SetError(TBDatePiece, errmsg);
                            allgood = false;
                            break;
                        case "NumProjet":
                            errorProvider1.SetError(TBNProjet, errmsg);
                            allgood = false;
                            break;
                        case "NumDImatricul":
                            errorProvider1.SetError(TBNumImm, errmsg);
                            allgood = false;
                            break;
                        case "Salarie":
                            errorProvider1.SetError(TBSalarie, errmsg);
                            allgood = false;
                            break;
                        case "NumBoite":
                            errorProvider1.SetError(TBNumBoite, errmsg);
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
            Helper.VerifyChanges(cs_Values, this);

            cs_Values["NumBoite"] = string.IsNullOrWhiteSpace(TBNumBoite.Text) ? "0" : TBNumBoite.Text;
            Helper.CheckForQuote(ref cs_Values);
            // Enregistrer les modifications
            var req = $"update Caisse set [DatePiece]='{cs_Values["DatePiece"]}' ,[NumProjet]='{cs_Values["NumProjet"]}' ,[BU]='{cs_Values["BU"]}' ,[NumBoite]={cs_Values["NumBoite"]},Reference='{cs_Values["Reference"]}',NumDImatricul='{cs_Values["NumDImatricul"]}',Salarie='{cs_Values["Salarie"]}',id_status=6,id_user_control={id_user_control},date_control=GETDATE() WHERE [NomDossier]='{NomDoc}' ";
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
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
