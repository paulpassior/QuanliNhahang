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

namespace QuanlyNhahang
{
    public partial class fTableManager : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["QuanlyQuanAn"].ConnectionString;
        string user;
        public fTableManager(string username, int accountType)
        {
            InitializeComponent();
            table1.BringToFront();
            user = username;
            
            if (accountType != 1)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Click += button4_Click;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Height = button2.Height;
            panel5.Top = button2.Top;
            table1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel5.Height = button3.Height;
            panel5.Top = button3.Top;
            statistics1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel5.Height = button4.Height;
            panel5.Top = button4.Top;
            management1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel5.Height = button5.Height;
            panel5.Top = button5.Top;
            MyAccountInfo ai = new MyAccountInfo(user);
            ai.Show();
        }
    }
}
