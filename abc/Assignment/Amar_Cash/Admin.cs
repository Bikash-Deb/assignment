using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amar_Cash
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAgent addAgent = new AddAgent();
            addAgent.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();    
            AddUserFromAdmin addUser = new AddUserFromAdmin();
            addUser.ShowDialog();   

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();   
            form.ShowDialog();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
