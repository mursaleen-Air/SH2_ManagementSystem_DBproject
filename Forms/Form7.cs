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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text);
            dataGridView1.DataSource = table;*/

            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string TeamLeadID = textBox1.Text;
                string EmployeeID = textBox2.Text;
                string TeamID = textBox3.Text;
                string Expertise = textBox5.Text;

                string strCommand = "INSERT INTO teamLead (teamLeadId, employeeId, teamId, expertise) VALUES (@TeamLeadID, @EmployeeID, @TeamID, @Expertise)";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@TeamLeadID", TeamLeadID);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@TeamID", TeamID);
                    cmd.Parameters.AddWithValue("@Expertise", Expertise);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Inserted.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM teamLead";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

        }
        DataTable table = new DataTable();
        int indexRow;
        private void Form7_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM teamlead";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }




            /*table.Columns.Add("ProjectID", typeof(string));
            table.Columns.Add("EmployeeID", typeof(int));
            table.Columns.Add("TeamID", typeof(string));
            table.Columns.Add("Expertise",typeof(string));

            table.Rows.Add("p1", 1, "1a", "Web Development");
            table.Rows.Add("p2", 2, "1b", "Graphic Designer");
            table.Rows.Add("p3", 3, "1c", "Web designer");


            dataGridView1.DataSource = table;*/
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox5.Text = selectedRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string TeamLeadID = textBox1.Text;
                string EmployeeID = textBox2.Text;
                string TeamID = textBox3.Text;
                string Expertise = textBox5.Text;

                string strCommand = "UPDATE teamLead SET employeeId=@EmployeeID, teamId=@TeamID, expertise=@Expertise WHERE teamLeadId=@TeamLeadID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@TeamLeadID", TeamLeadID);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@TeamID", TeamID);
                    cmd.Parameters.AddWithValue("@Expertise", Expertise);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Updated.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM teamLead";

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
            newDataRow.Cells[3].Value = textBox5.Text;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string TeamLeadID = textBox1.Text;

                string strCommand = "DELETE FROM teamLead WHERE teamLeadId=@TeamLeadID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@TeamLeadID", TeamLeadID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM teamLead";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }



            /* int rowIndex = dataGridView1.CurrentCell.RowIndex;
             dataGridView1.Rows.RemoveAt(rowIndex);*/
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, string.Empty);
                button1.Enabled = true;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox2, string.Empty);
                button1.Enabled = true;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox3, string.Empty);
                button1.Enabled = true;
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                errorProvider1.SetError(textBox5, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox5, string.Empty);
                button1.Enabled = true;
            }
        }
    }
}
