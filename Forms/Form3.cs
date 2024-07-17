using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace SH2_ManagementSystem.Forms
{
    public partial class Form3 : System.Windows.Forms.Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string departmentID = textBox1.Text;

                string strCommand = "DELETE FROM department WHERE departmentID=@departmentID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted.");

                // Refresh the DataGridView
                string refreshCommandText = "SELECT * FROM department";
                using (MySqlCommand refreshCmd = new MySqlCommand(refreshCommandText, con))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                con.Close();
            }



            /*int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);*/
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            
        }
        DataTable table = new DataTable();
        int indexRow;
        private void Form3_Load(object sender, EventArgs e)
        {

            string connstring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from department";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();


            /*table.Columns.Add("DepartmentID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Functions", typeof(string));
           

            table.Rows.Add(1, "sameer", "1a");
            table.Rows.Add(2, "furqan", "1b");
            table.Rows.Add(3, "mursaleen", "1c");



            dataGridView1.DataSource = table;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
            dataGridView1.DataSource = table;*/

            string constring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();

            string DepartmentID = textBox1.Text;
            string Name = textBox2.Text;
            string Functions = textBox3.Text;

            string strCommand = "INSERT INTO department(departmentId, name, functions) VALUES (\""
                + DepartmentID + "\",\"" + Name + "\",\"" + Functions + "\")";
            MySqlCommand cmd = new MySqlCommand(strCommand, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted.");

            // Refresh Data Grid View
            string connstring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection conn = new MySqlConnection(connstring);
            conn.Open();
            MySqlCommand cmdd = conn.CreateCommand();
            cmdd.CommandType = CommandType.Text;
            cmdd.CommandText = "SELECT * FROM department";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = textBox1.Text;
            newDataRow.Cells[1].Value = textBox2.Text;
            newDataRow.Cells[2].Value = textBox3.Text;
           // newDataRow.Cells[3].Value = textBox4.Text;*/


        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Team ID cannot be empty.");
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
    }
}
