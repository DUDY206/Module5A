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

namespace Modul5A
{

    public partial class Login : Form
    {
        public static int user_id;
        public Login()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q1QGNFE;Initial Catalog=module5a;Integrated Security=True");
            string query = "SELECT ID FROM Users where Email = '" + txtUserName.Text + "' AND Password = '" + txtPassWord.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    user_id = sdr.GetInt32(0);
                }
                MessageBox.Show("Login successfully " + user_id.ToString());
                MainOptions mainOptions = new MainOptions();
                mainOptions.Show();
            }
            else
            {
                MessageBox.Show("Login unsuccessfully");
            }

            
        }
    }
}
