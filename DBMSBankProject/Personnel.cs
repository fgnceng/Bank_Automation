using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMSBankProject
{
    public partial class Personnel : Form
    {
        public Personnel()
        {
            InitializeComponent();
        }

        private void Personnel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WithdrawalsForm wdf = new WithdrawalsForm();
            wdf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepositingMoneyForm dmf = new DepositingMoneyForm();
            dmf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransferingForm tf = new TransferingForm();
            tf.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerOperationsForm cof = new CustomerOperationsForm();
            cof.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BankStatementForm bsf = new BankStatementForm();
            bsf.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TransferingViewForm twf = new TransferingViewForm();
            twf.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
    }
}
