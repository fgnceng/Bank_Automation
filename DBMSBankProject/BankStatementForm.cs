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
    public partial class BankStatementForm : Form
    {
        public BankStatementForm()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=FIGOS\\SQLEXPRESS;Initial Catalog=BANK;Integrated Security=True");
        private void BackBTN_Click(object sender, EventArgs e)
        {
            Personnel ps = new Personnel();
            ps.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select *From BankStatement", connect);
            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["Rank"].ToString();
                add.SubItems.Add(read["CustomerID"].ToString());
                add.SubItems.Add(read["OperationTypeNo"].ToString());
                add.SubItems.Add(read["TheAmountofMoney"].ToString());
                add.SubItems.Add(read["Date"].ToString());

                listView1.Items.Add(add);
            }
            connect.Close();
        }
    }
}
