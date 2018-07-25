using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyNhahang.UserControls
{
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
            /*try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QuanlyQuanAn"].ConnectionString;
                string query = @"Lấy gì thì add vào đây";
                SqlConnection con = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["Cột1"].ToString());
                    listitem.SubItems.Add(dr["Cột2"].ToString());
                    listitem.SubItems.Add(dr["Cột3"].ToString());
                    listitem.SubItems.Add(dr["Cột4"].ToString());
                    listView1.Items.Add(listitem);
                }
            } catch (Exception e)
            {
            }*/
        }
    }
}
