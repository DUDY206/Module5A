using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul5A
{
    public partial class MainOptions : Form
    {
        public MainOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PurchaseAmentities purchaseAmentities = new PurchaseAmentities();
            purchaseAmentities.Show();
        }
    }
}
