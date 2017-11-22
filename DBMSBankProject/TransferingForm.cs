using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMSBankProject
{
    public partial class TransferingForm : Form
    {
        public TransferingForm()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=FIGOS\\SQLEXPRESS;Initial Catalog=BANK;Integrated Security=True");
        private void TransferingForm_Load(object sender, EventArgs e)
        {

        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            Personnel ps = new Personnel();
            ps.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("begin transaction begin try update Account set Balance=Balance-'" + textBox2.Text + "' where CustomerID='" + textBox1.Text + "' update Account set Balance=Balance+'" + textBox2.Text + "' where CustomerID='" + textBox3.Text + "'commit end try begin catch rollback end catch", connect);
            SqlCommand command2 = new SqlCommand("insert into BankStatement(CustomerID,OperationTypeNo,TheAmountofMoney,Date)values('" + textBox1.Text + "',3,'" + textBox2.Text + "','" + dateTimePicker1.Text + "')", connect);
            SqlCommand command3 = new SqlCommand("insert into Transfer(SenderID,ReceiveID,Date)values ('" + textBox1.Text + "','" + textBox3.Text + "','" + dateTimePicker1 + "')", connect);
            command2.ExecuteNonQuery();
            command.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connect.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("Transfering is succesfull!!!");
        }
    }
}
