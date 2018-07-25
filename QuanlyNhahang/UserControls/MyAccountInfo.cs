using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanlyNhahang.Entity;
using QuanlyNhahang.UserControls;

namespace QuanlyNhahang
{
    public partial class MyAccountInfo : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QuanlyQuanAn"].ConnectionString;
        Account account;
        public MyAccountInfo(string user)
        {
            InitializeComponent();
            string query = @"SELECT * FROM Account WHERE UserName = '" + user + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            account = new Account()
            {
                username = dt.Rows[0][0].ToString(),
                displayname = dt.Rows[0][1].ToString(),
                password = dt.Rows[0][2].ToString(),
                type = int.Parse(dt.Rows[0][3].ToString())
            };

            label2.Text = "Xin chào, " + account.displayname + "!";
            textBox1.Text = account.username;
            textBox1.Enabled = false;
            if(account.type == 1)
            {
                textBox2.Text = "Quản trị";
            }
            else
            {
                textBox2.Text = "Nhân viên";
            }
            textBox2.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult signedout = MessageBox.Show(
                            "Bạn có chắc chắn muốn đăng xuất?\nPhiên làm việc của bạn sẽ đóng sau khi đăng xuất.",
                            "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (signedout == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            ChangeInfoAccount cia = new ChangeInfoAccount(account);
            this.Close();
            cia.Show();
        }
    }
}
