using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace cafemanagement
{
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cloud"].ConnectionString);
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Required");
            }
            else if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Required");
            }
          
            else 
            {
                
                cn.Open();
                SqlCommand cmd = new SqlCommand("select [username],password from [registration] where [username]='" + textBox1.Text + "' and password='" + textBox2.Text + "'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (textBox1.Text == dr[0].ToString() || textBox2.Text == dr[1].ToString())
                    {
                        FileSplitter.Master  e1 = new    FileSplitter.Master (textBox1.Text);
                        e1.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
                cn.Close();
                
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
