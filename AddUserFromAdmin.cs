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
    public partial class AddUserFromAdmin : Form
    {
        public AddUserFromAdmin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a row is selected and if the clicked cell is not the header cell
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Populate text boxes with values from the selected row
                txtName.Text = selectedRow.Cells[1].Value?.ToString();
                txtPass.Text = selectedRow.Cells[2].Value?.ToString();

                txtNumber.Text = selectedRow.Cells[3].Value?.ToString();
                txtGender.Text = selectedRow.Cells[4].Value?.ToString();
                
                // Assign key value
                key = Convert.ToInt32(selectedRow.Cells[0].Value);
            }
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-QGOC4G7V;Initial Catalog=Amar_Cash;Integrated Security=True;");
        private void DisplayAccounts()
        {
            try
            {

                con.Open();
                string strCommand = "Select * From AccountTbl";
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtNumber.Text) && txtGender.SelectedItem != null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AccountTbl] ([AccName], [AccPass], [AccPhoneNumber], [AccGender], [AccBalance]) VALUES (@AccName, @AccPass, @AccPhoneNumber, @AccGender, @AccBalance)", con);
                    cmd.Parameters.AddWithValue("@AccName", txtName.Text);
                    cmd.Parameters.AddWithValue("@AccPass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@AccPhoneNumber", txtNumber.Text);
                    cmd.Parameters.AddWithValue("@AccGender", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AccBalance", 0);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayAccounts();
                    MessageBox.Show("Registration Successful");
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



        private void AddUserFromAdmin_Load(object sender, EventArgs e)
        {
            DisplayAccounts();

        }
        int key = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (key != 0) // Check if a row is selected
                {
                    if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtNumber.Text) && txtGender.SelectedItem != null)
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE [dbo].[AccountTbl] SET AccName = @AccName, AccPass = @AccPass, AccPhoneNumber = @AccPhoneNumber, AccGender = @AccGender WHERE accphonenumber = @ackey", con);
                        cmd.Parameters.AddWithValue("@AccName", txtName.Text);
                        cmd.Parameters.AddWithValue("@AccPass", txtPass.Text);
                        cmd.Parameters.AddWithValue("@AccPhoneNumber", txtNumber.Text);
                        cmd.Parameters.AddWithValue("@AccGender", txtGender.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ackey", key); // Set ackey to the actual key value
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Edit succesfully");
                        con.Close();
                        reset();
                        DisplayAccounts();
                        key = 0; // Reset key after successful update
                    }
                    else
                    {
                        MessageBox.Show("Please fill in all the fields.");
                    }
                }
                else
                {
                    MessageBox.Show("Select an item to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void reset()
        {
            txtName.Text = "";
            txtGender.SelectedIndex = -1;
            txtNumber.Text = "";
            txtPass.Text = "";


        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the item");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM accounttbl WHERE accphonenumber = @accphonenumber", con);
                    cmd.Parameters.AddWithValue("@accphonenumber", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account deleted");
                    con.Close();
                    reset();
                    DisplayAccounts();
                    key = 0; // Reset key after successful deletion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

    }
}

