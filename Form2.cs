using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SH2_ManagementSystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            EmployeeForm f2 = new EmployeeForm();
            
            string id, pass;
            id = textBox1.Text;
            pass = textBox2.Text;
            string userType = comboBox1.SelectedItem?.ToString();
            if ((id=="231185" || id=="231187") && pass=="1234" && (userType=="CEO" || userType =="Database Administrator") )
            {
                MessageBox.Show("Login Successful");
                f1.Show();
                Visible = false;
            }

            else if(id=="231213" && pass=="123" && userType=="Employee")
            {
                MessageBox.Show("Login Successful");
                f2.Show();
                Visible = false;


            }
            else

            {
                MessageBox.Show("Wrong ID, PASSWORD or UserType");
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
