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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Amar_Cash
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccNum.Text))
            {
                MessageBox.Show("Please enter username");
            }
            else if (string.IsNullOrEmpty(txtAccPass.Text))
            {
                MessageBox.Show("Please enter password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");
                    con.Open(); // Open the connection

                    SqlCommand cmd = new SqlCommand("SELECT * FROM AccountTbl WHERE accphonenumber=@accphonenumber AND accpass=@password", con);
                    cmd.Parameters.AddWithValue("@accphonenumber", txtAccNum.Text);
                    cmd.Parameters.AddWithValue("@password", txtAccPass.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        this.Hide();
                        Welcome welcome = new Welcome();
                        welcome.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }

                    reader.Close(); // Close the reader
                    con.Close(); // Close the connection
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog(); 

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
