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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection connect=new SqlConnection("Data Source=FIGOS\\SQLEXPRESS;Initial Catalog=BANK;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string sql = "Select *From Personnel where Username=@un AND Password=@pass";
                SqlParameter prm3 = new SqlParameter("un", textBox1.Text.Trim());
                SqlParameter prm4 = new SqlParameter("pass", textBox2.Text.Trim());
                SqlCommand command = new SqlCommand(sql, connect);
                command.Parameters.Add(prm3);
                command.Parameters.Add(prm4);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Personnel pes = new Personnel();
                    pes.Show();
                    this.Hide();
                    

                }
                else
                {
                    MessageBox.Show("Login Failed! Please check your Username or Password");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Connection Failed! Please Check Your Connection");
                
            }
            connect.Close();
        }
    }
}
