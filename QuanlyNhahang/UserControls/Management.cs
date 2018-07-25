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
using QuanlyNhahang.DAO;
using QuanlyNhahang.Entity;

namespace QuanlyNhahang.UserControls
{
    public partial class Management : UserControl
    {
        public Management()
        {
            InitializeComponent();
            try
            {
                FoodCategoryDAO fcDAO = new FoodCategoryDAO();
                dataGridView1.DataSource = fcDAO.loadFoodCategories();
                textBox1.Enabled = false;
            }
            catch (Exception e)
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Width = button1.Width;
            panel3.Top = button1.Bottom;
            panel3.Left = button1.Left;
            managementFood1.Visible = false;
            managementAccount1.Visible = false;
            managementTable1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Width = button2.Width;
            panel3.Top = button2.Bottom;
            panel3.Left = button2.Left;
            managementFood1.Visible = true;
            managementFood1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Width = button3.Width;
            panel3.Top = button3.Bottom;
            panel3.Left = button3.Left;
            managementTable1.Visible = true;
            managementTable1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Width = button4.Width;
            panel3.Top = button4.Bottom;
            panel3.Left = button4.Left;
            managementAccount1.Visible = true;
            managementAccount1.BringToFront();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            FoodCategoryDAO fcDAO = new FoodCategoryDAO();
            if (fcDAO.addFoodCategory(textBox2.Text)){
                MessageBox.Show("Dữ liệu được thêm thành công", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = fcDAO.loadFoodCategories();
            }
            else
            {
                MessageBox.Show("Dữ liệu không được thêm", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
