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

    public partial class AgentHome : Form
    {
        string num;
        public AgentHome(string num)
        {

            InitializeComponent();
            this.num = num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();    
            CashIN cashIN = new CashIN(num);   
            cashIN.ShowDialog();    

        }

        private void AgentHome_Load(object sender, EventArgs e)
        {

        }
    }
}
