using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace FinatechControle
{
    public partial class AffecterBoites : RadForm
    {
        private Controle controle;

        public AffecterBoites(Controle controle)
        {
            InitializeComponent();
            this.controle = controle;
            
        }

        private void AffecterBoites_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'administration_ANCFCCDataSet.TB_Utilisateurs'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.tB_UtilisateursTableAdapter.Fill(this.administration_ANCFCCDataSet.TB_Utilisateurs);

        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        

        private void bt_affect_Click(object sender, EventArgs e)
        {
            var userIndex = dd_agent.SelectedValue.ToString();
            var userLogin = dd_agent.Text;
            foreach (var boite in controle.radTree.SelectedNodes)
            { 
                var numBoite = boite.Value.ToString();
                var req = $"update boite set user_affect={userIndex} where numBoite={numBoite} ";
                var conStr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
                using (var con = new SqlConnection(conStr))
                {
                    con.Open();
                    new SqlCommand(req, con).ExecuteNonQuery();
                }
                boite.Text = $"Boite {numBoite} [{userLogin}] ({boite.Tag})";
            }
            Close();
        }
    }
}
