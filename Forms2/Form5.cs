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

namespace SH2_ManagementSystem.Forms2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;uid=root;pwd=TASHFEEN300;database=ads";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string employeeID = textBox1.Text;

                    string query = @"
                    SELECT 
                        e.employeeId,
                        a.street,
                        a.city,
                        a.postalCode,
                        a.country
                    FROM 
                        employee e
                    JOIN 
                        address a ON e.employeeId = a.employeeId
                    WHERE 
                        e.employeeId = @EmployeeID;
                ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, " cannot be empty.");
                iconButton1.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, string.Empty);
                iconButton1.Enabled = true;
            }
        }
    }
}
