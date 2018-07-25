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
using QuanlyNhahang.DAO;

namespace QuanlyNhahang
{
    public partial class fLogin : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QuanlyQuanAn"].ConnectionString;
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AccountDAO aDAO = new AccountDAO();
            string username = textBox1.Text;
            string password = textBox2.Text;
            int login = aDAO.Login(username, password);

            if(login >= 0)
            {
                fTableManager f = new fTableManager(username, login);
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy kiểm tra lại thông tin tài khoản của bạn", "Đăng nhập không thành công"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
