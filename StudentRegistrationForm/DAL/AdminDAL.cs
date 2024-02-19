using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationForm.DAL
{
    class AdminDAL
    {
        SqlConnection connection = new SqlConnection(DbConnection.DbConn);

        #region SelectData
        public DataTable LoginData(string username, string pass)
        {
            DataTable table = new DataTable();

            try
            {
                string sql = "SELECT *  FROM admin Where username=@username AND password=@password";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", pass);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(table);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;

        }
        #endregion
    }
}
