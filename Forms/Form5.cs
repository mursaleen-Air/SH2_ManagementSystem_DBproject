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
    public partial class Form5 : System.Windows.Forms.Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        DataTable table = new DataTable();
        int indexRow;

        private void Form5_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM legalreview";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }





            /*  table.Columns.Add("LegalReviewtID", typeof(int));
              table.Columns.Add("ProjectId", typeof(int));
              table.Columns.Add("reviewDate", typeof(DateTime));
              table.Columns.Add("Status", typeof(string));
              table.Columns.Add("Notes", typeof(string));


              table.Rows.Add(1, 101, new DateTime(2020, 9, 1), "Approved", "nil");
              table.Rows.Add(2, 102, new DateTime(2020, 9, 1), "Approved", "nil");
              table.Rows.Add(3, 103, new DateTime(2020, 9, 1), "Approved", "nil");


              dataGridView1.DataSource = table;*/
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = selectedRow.Cells[2].Value.ToString();
            textBox7.Text = selectedRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];



            newDataRow.Cells[0].Value = textBox1.Text;
            newDataRow.Cells[1].Value = textBox2.Text;
            newDataRow.Cells[2].Value = textBox3.Text;
            newDataRow.Cells[2].Value = dateTimePicker1.Text;
            newDataRow.Cells[3].Value = textBox7.Text;*/

            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string LegalReviewID = textBox1.Text;
                string ProjectID = textBox2.Text;
                DateTime ReviewDate = dateTimePicker1.Value;
                string Status = textBox3.Text;
                string Notes = textBox7.Text;

                string strCommand = "UPDATE legalReview SET projectId=@ProjectID, reviewDate=@ReviewDate, status=@Status, notes=@Notes WHERE legalReviewId=@LegalReviewID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@LegalReviewID", LegalReviewID);
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@ReviewDate", ReviewDate);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Notes", Notes);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Updated.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM legalReview";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);*/

            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string LegalReviewID = textBox1.Text;

                string strCommand = "DELETE FROM legalReview WHERE legalReviewId=@LegalReviewID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@LegalReviewID", LegalReviewID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM legalReview";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text,textBox7.Text);
            dataGridView1.DataSource = table;*/

            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string LegalReviewID = textBox1.Text;
                string ProjectID = textBox2.Text;
                DateTime ReviewDate = dateTimePicker1.Value;
                string Status = textBox3.Text;
                string Notes = textBox7.Text;

                string strCommand = "INSERT INTO legalReview (legalReviewId, projectId, reviewDate, status, notes) VALUES (@LegalReviewID, @ProjectID, @ReviewDate, @Status, @Notes)";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@LegalReviewID", LegalReviewID);
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@ReviewDate", ReviewDate);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Notes", Notes);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Inserted.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM legalReview";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

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

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                errorProvider1.SetError(dateTimePicker1, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(dateTimePicker1, string.Empty);
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
    }
}
