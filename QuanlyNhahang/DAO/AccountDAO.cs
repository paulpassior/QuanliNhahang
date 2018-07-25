using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyNhahang.DAO
{
    public class AccountDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QuanlyQuanAn"].ConnectionString;
        public int Login(string username, string password)
        {
            string query = @"SELECT TOP 1 * FROM Account WHERE UserName = '" + username 
                            + "' AND Password = '" + password + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count == 0)
            {
                return -1;
            }
            else
            {
                int accountType = int.Parse(dt.Rows[0][3].ToString());
                return accountType;
            }
        }

        public void ChangeAccountInfo()
        {

        }
    }
}
