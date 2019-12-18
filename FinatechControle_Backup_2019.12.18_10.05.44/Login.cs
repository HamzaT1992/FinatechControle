using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace FinatechControle
{
    public partial class Login : Telerik.WinControls.UI.ShapedForm
    {
        public Login()
        {
            InitializeComponent();
            loginTBox.Select();
        }

        private void ShapedForm1_Load(object sender, EventArgs e)
        {

        }

        private void cnxButton_Click(object sender, EventArgs e)
        {
            var constr = ConfigurationManager.ConnectionStrings["StrConCX"].ConnectionString;
            var login = loginTBox.Text;
            var pass = passTBox.Text;
            if (login == "" || pass == "")
            {
                return;
            }
            var req = $"SELECT id_user,id_equipe,login,pass FROM TB_Utilisateurs WHERE login='{login}' and pass='{pass}'";
            using (var con = new SqlConnection(constr))
            {
                var da = new SqlDataAdapter(req, con);
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Login ou Pass Incorrect!!");
                    return;
                }
                var row = dt.Rows[0];
                var id_user = row["id_user"].ToString();
                var id_equipe = row["id_equipe"].ToString();
                if (id_equipe != "7")
                {
                    MessageBox.Show("Vous n'êtes pas en équipe Finatech!!");
                    return;
                }
                Hide();
                new Controle(id_user, login).Show();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
