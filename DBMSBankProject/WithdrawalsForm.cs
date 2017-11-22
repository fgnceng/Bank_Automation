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
    public partial class WithdrawalsForm : Form
    {
        public WithdrawalsForm()
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

        private void button3_Click(object sender, EventArgs e)
        {
           
           
                connect.Open();
                SqlCommand komut2 = new SqlCommand("Update Account Set Balance=Balance-'" + textBox2.Text + "'where CustomerID='" + textBox1.Text + "'", connect);
              SqlCommand command=new SqlCommand("insert into BankStatement(CustomerID,OperationTypeNo,TheAmountofMoney,Date)values('"+textBox1.Text+"',1,'"+textBox2.Text+"','"+dateTimePicker1.Text+"')",connect);
               
                komut2.ExecuteNonQuery();
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Para Çekme İşlemi Başarıyla Gerçekleşti");
                textBox1.Clear();
                textBox2.Clear();
                
               
            }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select *From Account where CustomerID='" + textBox1.Text + "'", connect);
            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["CustomerID"].ToString();
                add.SubItems.Add(read["Balance"].ToString());


                listView1.Items.Add(add);
            }
            connect.Close();
        }
        }
    }

