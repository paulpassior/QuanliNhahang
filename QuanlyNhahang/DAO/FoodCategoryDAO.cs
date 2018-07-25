using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanlyNhahang.Entity;

namespace QuanlyNhahang.DAO
{
    class FoodCategoryDAO
    {
        public List<FoodCategory> loadFoodCategories()
        {
            List<FoodCategory> fds = new List<FoodCategory>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;
                string query = @"SELECT * FROM FoodCategory";
                SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                foreach (DataRow dr in dt.Rows)
                {
                    FoodCategory fd = new FoodCategory()
                    {
                        id = int.Parse(dr[0].ToString()),
                        name = dr[1].ToString()
                    };
                    fds.Add(fd);
                }
            }
            catch(Exception e)
            {
            }
            return fds;
        }

        public bool checkDuplicate(string name)
        {
            List<FoodCategory> fcs = loadFoodCategories();
            foreach (FoodCategory fc in fcs)
            {
                if (fc.name == name)
                {
                    return false;
                }
            }
            return true;
        }

        public bool addFoodCategory(string name)
        {
            try
            {
                List<FoodCategory> fcs = loadFoodCategories();

                foreach(FoodCategory fc in fcs)
                {
                    if(fc.name == name)
                    {
                        return false;
                    }
                }

                string connectionString = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;
                string insert = @"INSERT INTO FoodCategory VALUES(@name)";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand com = new SqlCommand(insert, con);
                con.Open();
                com.Parameters.AddWithValue("@name", name);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
            }
            return true;
        }
    }
}
