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

namespace QuanlyNhahang.UserControls
{
    public partial class ChangeInfoAccount : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QuanlyQuanAn"].ConnectionString;
        public ChangeInfoAccount(Account account)
        {
            InitializeComponent();
            textBox1.Text = account.username;
            textBox1.Enabled = false;
            textBox2.Text = account.displayname;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string queryAcc = @"SELECT TOP 1 * FROM Account";
            SqlDataAdapter da = new SqlDataAdapter(queryAcc, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string name = dt.Rows[0][1].ToString();

            if (textBox2.Text != name)
            {
                if (textBox3.Text == "")
                {
                    string modify = @"UPDATE Account SET DisplayName = @dname WHERE UserName = '" + textBox1.Text + "'";
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand com = new SqlCommand(modify, con);
                    con.Open();
                    com.Parameters.AddWithValue("@dname", textBox2.Text);
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thông tin đã được thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    MyAccountInfo mainew = new MyAccountInfo(user);
                    mainew.Show();
                }
                else
                {
                    string modify = @"UPDATE Account SET Password = @pass WHERE UserName = '" + textBox1.Text + "'";
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand com = new SqlCommand(modify, con);
                    con.Open();
                    com.Parameters.AddWithValue("@pass", textBox3.Text);
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thông tin đã được thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    MyAccountInfo mainew = new MyAccountInfo(user);
                    mainew.Show();
                }
            }
            else
            {
                if (textBox3.Text == textBox4.Text && textBox3.Text != "")
                {
                    string modify = @"UPDATE Account SET DisplayName = @dname, Password = @pass WHERE UserName = '" + textBox1.Text + "'";
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand com = new SqlCommand(modify, con);
                    con.Open();
                    com.Parameters.AddWithValue("@dname", textBox2.Text);
                    com.Parameters.AddWithValue("@pass", textBox3.Text);
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thông tin đã được thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    MyAccountInfo mainew = new MyAccountInfo(user);
                    mainew.Show();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại mật khẩu.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            MyAccountInfo mainew = new MyAccountInfo(user);
            mainew.Show();
            this.Close();
        }
    }
}
