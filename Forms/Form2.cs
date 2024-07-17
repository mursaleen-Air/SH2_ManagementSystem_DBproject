using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;
using MySql.Data.MySqlClient;

namespace SH2_ManagementSystem.Forms
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //table.Rows.Add(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
           // dataGridView1.DataSource = table;
            string constring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constring;
            con.Open();

            string TeamID = textBox1.Text;
            string Name = textBox2.Text;
            string SkillID = textBox3.Text;
            string TeamLeadID = textBox4.Text;
            
            string strCommand = "insert into team(teamid,name,skillId,teamLeadId) values (\""
            + TeamID + "\",\"" + Name + "\",\"" + SkillID + "\",\"" + TeamLeadID + "\")";
            //MessageBox.Show(strCommand);
            MySqlCommand cmd = new MySqlCommand(strCommand, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted.");

            string connstring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection conn = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            MySqlCommand cmdd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from team";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
         DataTable table = new DataTable();
        int indexRow;
        private void Form2_Load(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from team";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();

            /* table.Columns.Add("teamID", typeof(int));
             table.Columns.Add("Name", typeof(string));
             table.Columns.Add("SkillID", typeof(string));
             table.Columns.Add("TeamLeadID", typeof(string));

             table.Rows.Add(1, "sameer", "1a", "101");
             table.Rows.Add(2 ,"furqan", "1b", "102");
             table.Rows.Add(3, "mursaleen", "1c", "103");
 */


           // dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index=e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[3].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constring;
            con.Open();

            string TeamID = textBox1.Text;
            string Name = textBox2.Text;
            string SkillID = textBox3.Text;
            string TeamLeadID = textBox4.Text;

            // Update query with parameterized inputs
            string strCommand = "UPDATE team SET name=@Name, skillId=@SkillID, teamLeadId=@TeamLeadID WHERE teamid=@TeamID";
            MySqlCommand cmd = new MySqlCommand(strCommand, con);

            // Using parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@TeamID", TeamID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@SkillID", SkillID);
            cmd.Parameters.AddWithValue("@TeamLeadID", TeamLeadID);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated.");



            string connstring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection conn = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            MySqlCommand cmdd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from team";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();



            /* DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
             newDataRow.Cells[0].Value = textBox1.Text;
             newDataRow.Cells[1].Value = textBox2.Text;
             newDataRow.Cells[2].Value = textBox3.Text;
             newDataRow.Cells[3].Value = textBox4.Text;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constring;
            con.Open();

            string TeamID = textBox1.Text;

            // Delete query with parameterized input
            string strCommand = "DELETE FROM team WHERE teamid=@TeamID";
            MySqlCommand cmd = new MySqlCommand(strCommand, con);

            // Using parameter to avoid SQL injection
            cmd.Parameters.AddWithValue("@TeamID", TeamID);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted.");




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    errorProvider1.SetError(textBox2, "Team ID cannot be empty.");
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
                    errorProvider1.SetError(textBox3, "Team ID cannot be empty.");
                    button1.Enabled = false;
                }
                else
                {
                    errorProvider1.SetError(textBox3, string.Empty);
                    button1.Enabled = true;
                }
            }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Team ID cannot be empty.");
                button1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox4, string.Empty);
                button1.Enabled = true;
            }
        }
    }
    }
    


    

