using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinatechControle
{
    public class ColumnModified
    {
        private static void AddModificaiton(string Column,UserControl control)
        {
            var userInsex = "";
            var NomDoc = "";
            var type = "";
            var id_user_control = "";

            dynamic cnt = Convert.ChangeType(control, control.GetType());

            userInsex = cnt.controle.radLabel2.Text;
            NomDoc = cnt.NomDoc;
            type = cnt.type;
            id_user_control = cnt.id_user_control;
            
            var constr = ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();

                var mdreq = $"INSERT INTO Modifications VALUES ('$Col','{NomDoc}','{type}','{userInsex}',{id_user_control},GETDATE())";

                var cmd = new SqlCommand(mdreq, cnn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Opération effectué!!");
            }
        }

        public static void VerifyChanges(Dictionary<string,string> valuePairs,UserControl control)
        {
            dynamic cnt = Convert.ChangeType(control, control.GetType());
            foreach (var item in valuePairs)
            {
                var pName = item.Key;
                var pValue = cnt.GetType().GetProperty(pName).GetValue(cnt, null).ToString();
                if (pValue != item.Value)
                {
                    AddModificaiton(pName, cnt);
                }
            }
        }
    }
}
