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
using System.Xml.Linq;

namespace Amar_Cash
{
    public partial class CashIN : Form
    {
        string num;
        public CashIN(string num)
        {
            InitializeComponent();
            this.num = num;
        }
        int balance;
        private void GetBalance()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");

                con.Open();
                string query = "SELECT * FROM AccountTbl WHERE accphonenumber = @accPhoneNumber";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@accPhoneNumber", txtaccnumber.Text);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    balance = Convert.ToInt32(dr["accbalance"]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string randomDigit()
        {
            Random random = new Random();
            string randomDigits = random.Next(1000, 10000).ToString();

            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            string uniqueNumber = randomDigits + timestamp;
            return uniqueNumber;
        }
        public void deposite()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Transaction] ([transactionType], [Tdate], [transactionbalance], [UserAccNo], [agentAccNO], [transactionCode]) VALUES (@transactionType, @Tdate, @transactionbalance, @UserAccNo, @agentAccNO, @transactionCode)", con);
                cmd.Parameters.AddWithValue("@transactionType", "Deposite");
                cmd.Parameters.AddWithValue("@Tdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@transactionbalance", txtamount.Text);
                cmd.Parameters.AddWithValue("@UserAccNo", txtaccnumber.Text);
                cmd.Parameters.AddWithValue("@agentAccNO", num);
                cmd.Parameters.AddWithValue("@transactionCode", randomDigit());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
               
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");

                GetBalance();
               

               
                deposite();
                int newbal = balance + Convert.ToInt32(txtamount.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update AccountTbl set accbalance=@AB where accphonenumber=@num", con);
                cmd.Parameters.AddWithValue("@AB", newbal);
                cmd.Parameters.AddWithValue("@num", txtaccnumber.Text);
                cmd.ExecuteNonQuery(); // Execute the query
                AgentUpdate();
                MessageBox.Show("Cash in successful");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                
            }
        }

        private void GetBalanceAgent()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");

                con.Open();
                string query = "SELECT agentcash FROM AgentTbl WHERE agentphoneno = @accPhoneNumber";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@accPhoneNumber", num);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    balance = Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Agent balance not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();

                if (balance == 0)
                {
                    MessageBox.Show("Cash-out is not possible. Agent balance is zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Proceed with cash-out operation
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgentUpdate()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");
                GetBalanceAgent();

                // Check if the balance is sufficient for cash-out
                

                
                int newbal = balance - Convert.ToInt32(txtamount.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update AgentTbl set agentcash=@AB where agentphoneno=@num", con);
                cmd.Parameters.AddWithValue("@AB", newbal);
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating agent's balance: " + ex.Message);
                
            }
        }


        private void CashIN_Load(object sender, EventArgs e)
        {

        }
    }
}
