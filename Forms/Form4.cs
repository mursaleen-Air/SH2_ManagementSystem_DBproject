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
    public partial class Form4 : System.Windows.Forms.Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        int indexRow;
        private void Form4_Load(object sender, EventArgs e)
        {

            string connstring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM project";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Customize DataGridView text color
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;

            con.Close();



            /*table.Columns.Add("ProjectID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Assigned by", typeof(string));
            table.Columns.Add("TeamID", typeof(string));
            table.Columns.Add("LegalReviewID", typeof(string));
            table.Columns.Add("Status", typeof(string));

            table.Rows.Add(1, "sameer", "des", "CEO","1a","1s","Processing");
            table.Rows.Add(2, "furqan", "des", "CEO","1b","1s","Processing");
            table.Rows.Add(3, "mursaleen", "des", "CEO","1c","1p","Completed");


            dataGridView1.DataSource = table;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
            dataGridView1.DataSource = table;*/

            string constring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();

            string ProjectID = textBox1.Text;
            string Name = textBox2.Text;
            string Description = textBox3.Text;
            string AssignedBy = textBox5.Text;
            string TeamID = textBox6.Text;
            string LegalReviewID = textBox7.Text;
            string Status = textBox8.Text;

            string strCommand = "INSERT INTO project(projectId, name, description, assignedBy, teamId, legalReviewId, status) VALUES (@ProjectID, @Name, @Description, @AssignedBy, @TeamID, @LegalReviewID, @Status)";
            MySqlCommand cmd = new MySqlCommand(strCommand, con);

            // Using parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@AssignedBy", AssignedBy);
            cmd.Parameters.AddWithValue("@TeamID", TeamID);
            cmd.Parameters.AddWithValue("@LegalReviewID", LegalReviewID);
            cmd.Parameters.AddWithValue("@Status", Status);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted.");

            // Refresh Data Grid View
            con = new MySqlConnection(constring);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM project";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];



            newDataRow.Cells[0].Value = textBox1.Text;
            newDataRow.Cells[1].Value = textBox2.Text;
            newDataRow.Cells[2].Value = textBox3.Text;
            newDataRow.Cells[3].Value = textBox5.Text;
            newDataRow.Cells[3].Value = textBox6.Text;
            newDataRow.Cells[3].Value = textBox7.Text;
            newDataRow.Cells[3].Value = textBox8.Text;*/

            string constring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();

            string ProjectID = textBox1.Text;
            string Name = textBox2.Text;
            string Description = textBox3.Text;
            string AssignedBy = textBox5.Text;
            string TeamID = textBox6.Text;
            string LegalReviewID = textBox7.Text;
            string Status = textBox8.Text;

            string strCommand = "UPDATE project SET name=@Name, description=@Description, assignedBy=@AssignedBy, teamId=@TeamID, legalReviewId=@LegalReviewID, status=@Status WHERE projectId=@ProjectID";
            MySqlCommand cmd = new MySqlCommand(strCommand, con);

            // Using parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@AssignedBy", AssignedBy);
            cmd.Parameters.AddWithValue("@TeamID", TeamID);
            cmd.Parameters.AddWithValue("@LegalReviewID", LegalReviewID);
            cmd.Parameters.AddWithValue("@Status", Status);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated.");

            // Refresh Data Grid View
            string connstring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection conn = new MySqlConnection(connstring);
            conn.Open();
            MySqlCommand cmdd = conn.CreateCommand();
            cmdd.CommandType = CommandType.Text;
            cmdd.CommandText = "SELECT * FROM project";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);*/
            string constring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();

            string ProjectID = textBox1.Text;

            string strCommand = "DELETE FROM project WHERE projectId=@ProjectID";
            MySqlCommand cmd = new MySqlCommand(strCommand, con);

            // Using parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@ProjectID", ProjectID);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted.");

            // Refresh Data Grid View
            con = new MySqlConnection(constring);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM project";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox5.Text = selectedRow.Cells[3].Value.ToString();
            textBox6.Text = selectedRow.Cells[4].Value.ToString();
            textBox7.Text = selectedRow.Cells[5].Value.ToString();
            textBox8.Text = selectedRow.Cells[6].Value.ToString();
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

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                errorProvider1.SetError(textBox6, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox6, string.Empty);
                button1.Enabled = true;
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                errorProvider1.SetError(textBox7, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox7, string.Empty);
                button1.Enabled = true;
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                errorProvider1.SetError(textBox8, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox8, string.Empty);
                button1.Enabled = true;
            }
        }
    }
}
