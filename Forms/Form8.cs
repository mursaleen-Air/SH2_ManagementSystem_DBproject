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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        int indexRow;
        private void Form8_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM recruitment";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }



            /*table.Columns.Add("RecruitmentID", typeof(int));
            table.Columns.Add("Position", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("OpenDate", typeof(DateTime));
            table.Columns.Add("CloseDate", typeof(DateTime));
            table.Columns.Add("Method", typeof(string));
            table.Columns.Add("DepartmentID", typeof(string));

            table.Rows.Add(1, "leadSoftEng", "des", new DateTime(2020, 9, 1), new DateTime(2020, 9, 1), "interview", "1s");
            table.Rows.Add(2, "juniorEng", "des", new DateTime(2020, 9, 1), new DateTime(2020, 9, 1), "interview", "1s");
            table.Rows.Add(3, "ProJectManager", "des", new DateTime(2020, 9, 1), new DateTime(2020, 9, 1), "interview", "1p");*/




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = selectedRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = selectedRow.Cells[4].Value.ToString();
            textBox7.Text = selectedRow.Cells[5].Value.ToString();
            textBox8.Text = selectedRow.Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text, dateTimePicker2.Text, textBox7.Text, textBox8.Text);
            dataGridView1.DataSource = table;*/
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string RecruitmentID = textBox1.Text;
                string Position = textBox2.Text;
                string Description = textBox3.Text;
                DateTime OpenDate = dateTimePicker1.Value;
                DateTime CloseDate = dateTimePicker2.Value;
                string Method = textBox7.Text;
                string DepartmentID = textBox8.Text;

                string strCommand = "INSERT INTO recruitment (recruitmentId, position, description, openDate, closeDate, method, departmentId) VALUES (@RecruitmentID, @Position, @Description, @OpenDate, @CloseDate, @Method, @DepartmentID)";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@RecruitmentID", RecruitmentID);
                    cmd.Parameters.AddWithValue("@Position", Position);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@OpenDate", OpenDate);
                    cmd.Parameters.AddWithValue("@CloseDate", CloseDate);
                    cmd.Parameters.AddWithValue("@Method", Method);
                    cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Inserted.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM recruitment";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string RecruitmentID = textBox1.Text;
                string Position = textBox2.Text;
                string Description = textBox3.Text;
                DateTime OpenDate = dateTimePicker1.Value;
                DateTime CloseDate = dateTimePicker2.Value;
                string Method = textBox7.Text;
                string DepartmentID = textBox8.Text;

                string strCommand = "UPDATE recruitment SET position=@Position, description=@Description, openDate=@OpenDate, closeDate=@CloseDate, method=@Method, departmentId=@DepartmentID WHERE recruitmentId=@RecruitmentID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@RecruitmentID", RecruitmentID);
                    cmd.Parameters.AddWithValue("@Position", Position);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@OpenDate", OpenDate);
                    cmd.Parameters.AddWithValue("@CloseDate", CloseDate);
                    cmd.Parameters.AddWithValue("@Method", Method);
                    cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Updated.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM recruitment";

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
            newDataRow.Cells[3].Value = dateTimePicker1.Text;
            newDataRow.Cells[3].Value = dateTimePicker2.Text;
            newDataRow.Cells[2].Value = textBox7.Text;
            newDataRow.Cells[2].Value = textBox8.Text;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string RecruitmentID = textBox1.Text;

                string strCommand = "DELETE FROM recruitment WHERE recruitmentId=@RecruitmentID";
                using (MySqlCommand cmd = new MySqlCommand(strCommand, con))
                {
                    cmd.Parameters.AddWithValue("@RecruitmentID", RecruitmentID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted.");

                // Refresh the DataGridView
                MySqlCommand refreshCmd = con.CreateCommand();
                refreshCmd.CommandType = CommandType.Text;
                refreshCmd.CommandText = "SELECT * FROM recruitment";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }



            /*int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);*/
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

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

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                errorProvider1.SetError(dateTimePicker1 ," cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(dateTimePicker1, string.Empty);
                button1.Enabled = true;
            }
        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text))
            {
                errorProvider1.SetError(dateTimePicker2, " cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(dateTimePicker2, string.Empty);
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
