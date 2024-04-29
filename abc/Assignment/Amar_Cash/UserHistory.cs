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
    public partial class UserHistory : Form
    {
        string num;
        public UserHistory(string num)
        {
            this.num = num;
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");

        private void DisplayAccounts()
        {
            try
            {

                con.Open();
                string strCommand = "SELECT [Tid]\r\n      ,[transactionType]\r\n      ,[Tdate]\r\n      ,[transactionbalance]\r\n      ,[UserAccNo]\r\n      ,[agentAccNO]\r\n      ,[transactionCode]\r\n  FROM [dbo].[Transaction] where useraccno='"+num+"' ";
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

        private void UserHistory_Load(object sender, EventArgs e)
        {
            DisplayAccounts();
        }
    }
}
