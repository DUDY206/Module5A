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
            string query = "SELECT * FROM Users where ID = '" + txtUserName.Text + "' AND Password = '" + txtPassWord.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            if (dtb.Rows.Count == 1)
            {
                MessageBox.Show("Login successfully");
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
