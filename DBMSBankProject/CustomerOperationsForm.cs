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
    public partial class CustomerOperationsForm : Form
    {
        public CustomerOperationsForm()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=FIGOS\\SQLEXPRESS;Initial Catalog=BANK;Integrated Security=True");
        private void CustomerOperationsForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Personnel ps = new Personnel();
            ps.Show();
            this.Hide();
        }


        public void viewdetails()
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select *From Customer", connect);
            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["CustomerID"].ToString();
                add.SubItems.Add(read["Name"].ToString());
                add.SubItems.Add(read["Surname"].ToString());
                add.SubItems.Add(read["Address"].ToString());
                add.SubItems.Add(read["Telephone"].ToString());
                add.SubItems.Add(read["Email"].ToString());
                listView1.Items.Add(add);


            }
            connect.Close();
        }

        private void ViewBTN_Click(object sender, EventArgs e)
        {
            viewdetails();
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {     
            if (CustomerIDText.Text == "" || NameText.Text == "" || SurnameText.Text == "" || AddressText.Text == "" || TelephoneText.Text == "" || EmailText.Text == "")
            {
                errorProvider1.SetError(CustomerIDText, "Doldurulması Zorunlu Alan");
                errorProvider1.SetError(NameText, "Doldurulması Zorunlu Alan");
                errorProvider1.SetError(SurnameText, "Doldurulması Zorunlu Alan");
                errorProvider1.SetError(AddressText, "Doldurulması Zorunlu Alan");
                errorProvider1.SetError(TelephoneText, "Doldurulması Zorunlu Alan");
                errorProvider1.SetError(EmailText, "Doldurulması Zorunlu Alan");

            }
            else
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("CustomerRegister", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("CustomerID", CustomerIDText.Text);
                cmd.Parameters.Add("Name", NameText.Text);
                cmd.Parameters.Add("Surname", SurnameText.Text);
                cmd.Parameters.Add("Telephone", TelephoneText.Text);
                cmd.Parameters.Add("Address", AddressText.Text);
                cmd.Parameters.Add("Email", EmailText.Text);
                cmd.ExecuteNonQuery();
                connect.Close();
                viewdetails();
            }
        }
        int CustomerID = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            sira = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            CustomerIDText.Text = listView1.SelectedItems[0].SubItems[0].Text;
            NameText.Text = listView1.SelectedItems[0].SubItems[1].Text;
            SurnameText.Text = listView1.SelectedItems[0].SubItems[2].Text;
            AddressText.Text = listView1.SelectedItems[0].SubItems[3].Text;
            TelephoneText.Text = listView1.SelectedItems[0].SubItems[4].Text;
            EmailText.Text = listView1.SelectedItems[0].SubItems[5].Text;
            
        }
        int sira = 0;
        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand komut = new SqlCommand("Delete From Customer Where CustomerID=(" + sira + ")", connect);
            komut.ExecuteNonQuery();
            connect.Close();
            viewdetails();

            viewdetails();
            CustomerIDText.Clear();
            NameText.Clear();
            SurnameText.Clear();
            AddressText.Clear();
            TelephoneText.Clear();
            EmailText.Clear();
            
        }

        private void UpdateBTN_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("update Customer set CustomerID='" + CustomerIDText.Text.ToString() + "',Name='" + NameText.Text.ToString() + "',Surname='" + SurnameText.Text.ToString() + "',Address='" + AddressText.Text.ToString() + "',Telephone='" + TelephoneText.Text.ToString() + "',Email='" + EmailText.Text.ToString() + "'where CustomerID="+ CustomerID+"", connect);
            command.ExecuteNonQuery();
            connect.Close();
            viewdetails();
            CustomerIDText.Clear();
            NameText.Clear();
            SurnameText.Clear();
            AddressText.Clear();
            TelephoneText.Clear();
            EmailText.Clear();
            
        }
    }
}
