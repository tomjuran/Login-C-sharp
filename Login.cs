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

namespace LoginPage
{
    public partial class Login : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-D3GS9TQ\SQLEXPRESS;Initial Catalog=LoginForm1;Integrated Security=True;Pooling=False");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) FROM UserTable where Username = '"+usernametb.Text+"' and Password = '"+passwordtb.Text+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new HomeForm().Show();
            }
            else
                MessageBox.Show("Invalid Username or Password");
            Con.Close();
        }
    }
}
