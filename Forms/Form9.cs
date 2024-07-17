using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SH2_ManagementSystem.Forms
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        int indexRow;

        private void Form9_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM role";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }


            /*
            table.Columns.Add("RoleID", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Description", typeof(string));
          

            table.Rows.Add(1, "PrepareDocuments", "nil");
            table.Rows.Add(2, "GatherMaterial", "nil");
            table.Rows.Add(3, "ManageInterviews", "nil");*/

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string RoleID = textBox1.Text;
                string Title = textBox2.Text;
                string DepartmentID = textBox3.Text;

                string strCommand = "INSERT INTO role (roleId, title, departmentId) VALUES (@RoleID, @Title, @DepartmentID)";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@RoleID", RoleID);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Inserted.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM role";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }



            /*table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
            dataGridView1.DataSource = table;*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string RoleID = textBox1.Text;
                string Title = textBox2.Text;
                string DepartmentID = textBox3.Text;

                string strCommand = "UPDATE role SET title=@Title, departmentId=@DepartmentID WHERE roleId=@RoleID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@RoleID", RoleID);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Updated.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM role";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }




            /*DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];



            newDataRow.Cells[0].Value = textBox1.Text;
            newDataRow.Cells[1].Value = textBox2.Text;
            newDataRow.Cells[2].Value = textBox3.Text;
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string RoleID = textBox1.Text;

                string strCommand = "DELETE FROM role WHERE roleId=@RoleID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@RoleID", RoleID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM role";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }


            /*int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);*/

        }
    }
}
