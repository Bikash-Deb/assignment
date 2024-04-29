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

namespace Amar_Cash
{
    public partial class Home : Form
    {
        string num;
        public Home(string number)
        {
            InitializeComponent();
            this.num = number;
        }

       
        private void button2_Click(object sender, EventArgs e)
        { 
            this.Hide();


            CashOut cashOut = new CashOut(num);
            cashOut.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ShowBalance(string num)
        {
            int balance;
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");

                
                con.Open();
                string query = "SELECT * FROM AccountTbl WHERE accphonenumber = @accPhoneNumber";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@accPhoneNumber", num);

                

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                Console.WriteLine(dt.Rows.Count);
                foreach (DataRow dr in dt.Rows)
                {
                    balancelbl.Text = dr["accbalance"].ToString();
                    balance = Convert.ToInt32(dr["accbalance"].ToString());
                }


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowBalance(num);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            UserHistory userHistory = new UserHistory(num);
            userHistory.ShowDialog();
             
        }
    }
}
