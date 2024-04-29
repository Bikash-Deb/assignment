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
    public partial class AddAgent : Form
    {
        public AddAgent()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
            SqlConnection con = new SqlConnection("Date Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all text fields are not blank
                if (!string.IsNullOrWhiteSpace(txtAgentNm.Text) && !string.IsNullOrWhiteSpace(txtPasAgent.Text) && !string.IsNullOrWhiteSpace(txtMoneyAgent.Text) && !string.IsNullOrWhiteSpace(txtphone.Text))
                {
                    // Create SQL command with parameters to prevent SQL injection
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AgentTbl] ([AgentName], [AgentPass], [AgentCash], [agentphoneno]) VALUES (@AgentName, @AgentPass, @AgentCash, @AgentPhone)", con);
                    cmd.Parameters.AddWithValue("@AgentName", txtAgentNm.Text);
                    cmd.Parameters.AddWithValue("@AgentPass", txtPasAgent.Text);
                    cmd.Parameters.AddWithValue("@AgentCash", txtMoneyAgent.Text);
                    cmd.Parameters.AddWithValue("@AgentPhone", txtphone.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Add Successfully");
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void DisplayAccounts()
        {
            try
            {

                con.Open();
                string strCommand = "Select * From agenttbl";
                SqlCommand objCommand = new SqlCommand(strCommand, con);
                //bind data with  ui
                DataSet objDataSet = new DataSet();
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
                dataGridView1.DataSource = objDataSet.Tables[0];
                con.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }

        }
        private void AddAgent_Load(object sender, EventArgs e)
        {
            DisplayAccounts();
        }
    }
}
