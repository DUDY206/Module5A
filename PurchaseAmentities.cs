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
    public partial class PurchaseAmentities : Form
    {
        public PurchaseAmentities()
        {
            InitializeComponent();
        }
        //dictionary "amenities - price"
        Dictionary<int, bool> select_amt = new Dictionary<int, bool>();
        Dictionary<int, double> amt_pri = new Dictionary<int, double>();
        int num_amenities_selected = 0;
        double total_payable=0;
        int tick_id, cabin_id;

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Xóa hết checkbox cũ, dictionary cũ, thông tin cũ lưu lại từ phiên tra cứu trước
            clear_old_data();
            total_payable = 0;
            num_amenities_selected = 0;
            lb_it_selected.Text = "0";
            ttp.Text = "0";
            //CONNECTION
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q1QGNFE;Initial Catalog=module5a;Integrated Security=True");
            string query = "SELECT Tickets.FirstName,Tickets.LastName,CabinTypes.Name,Tickets.PassportNumber,Schedules.ID,Routes.DepartureAirportID,Routes.ArrivalAirportID,Schedules.Date,Schedules.Time,CabinTypes.ID,Tickets.ID FROM Tickets INNER JOIN Schedules ON Tickets.ScheduleID = Schedules.ID INNER JOIN Routes ON Schedules.RouteID = Routes.ID INNER JOIN CabinTypes ON Tickets.CabinType = CabinTypes.ID WHERE Tickets.BookingReference = '" + txtBR.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            int Sched_ID, DA_ID, AA_ID;

            DateTime Sched_Date;
            TimeSpan Sched_Time;

            //TRA THONG TIN TỪ BOOKING REFERENCE
            if (sdr.HasRows)
            {
                //MessageBox.Show("OK");
                while (sdr.Read())
                {
                    //Lấy thông tin đổ ra giao diên
                    txtName.Text = sdr.GetString(0) + " " + sdr.GetString(1);
                    txtCabinClass.Text = sdr.GetString(2);
                    txtPPNum.Text = sdr.GetString(3);
                    Sched_ID = sdr.GetInt32(4);
                    DA_ID = sdr.GetInt32(5);
                    AA_ID = sdr.GetInt32(6);
                    Sched_Date = sdr.GetDateTime(7);
                    Sched_Time = sdr.GetTimeSpan(8);
                    cabin_id = sdr.GetInt32(9);
                    tick_id = sdr.GetInt32(10);


                    string temp = Sched_ID + ", " + DA_ID + "-" + AA_ID + ", " + Sched_Date.Date.ToString("dd/MM/yyyy") + ", " + Sched_Time.ToString("hh\\:mm");
                    txtTicketInfo.Items.Add(temp);
                }
                txtTicketInfo.Text = txtTicketInfo.Items[0].ToString();
            }
            else
            {
                MessageBox.Show("CANNOT FOUND BOOKING REFERENCE");
            }

            con.Close();

        }

        

        private void btnShowBR_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q1QGNFE;Initial Catalog=module5a;Integrated Security=True");

            string query = "SELECT Amenities.AmenService,Amenities.Price,AmenitiesID FROM Amenities INNER JOIN AmenitiesCabinType ON Amenities.ID = AmenitiesCabinType.AmenitiesID WHERE AmenitiesCabinType.CabinTypeID = " + cabin_id + "";
            
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();


            //Đổ ra thông tin nếu tra được mã booking
            if (sdr.HasRows)
            {
                int index_top = 0, index_left = 0;
                while (sdr.Read())
                {
                    //tạo các checkbox mới khi tra được mã booking
                    CheckBox checkbox_t = new CheckBox();
                    this.groupBox2.Controls.Add(checkbox_t);

                    //định vị tọa độ các checkbox theo cột
                    checkbox_t.AutoSize = true;
                    checkbox_t.Location = new Point(17 + index_left * 200, 19 + index_top * 19);
                    if (index_top != 3)
                    {
                        index_top++;
                    }
                    else
                    {
                        index_left++;
                        index_top = 0;
                    }

                    double price = sdr.GetDouble(1);
                    int amt_id = sdr.GetInt32(2);
                    checkbox_t.Tag = amt_id;
                    amt_pri.Add(amt_id, price);

                    select_amt.Add(amt_id, false);

                    if (price != 0)
                    {
                        checkbox_t.Text = sdr.GetString(0) + " ($" + price.ToString() + ")";
                    }
                    else
                    {
                        checkbox_t.Enabled = false;
                        checkbox_t.Text = sdr.GetString(0) + " (FREE)";
                        num_amenities_selected++;

                    }
                    checkbox_t.Click += chk_Clicked;
                }
            }
            else
            {
                MessageBox.Show("KHong co amenities thuoc cabin type :" + cabin_id);
            }
        }
        protected void chk_Clicked(object sender,EventArgs e)
        {
            CheckBox chk = (sender as CheckBox);
            int chk_tag = int.Parse(chk.Tag.ToString());
            double price = amt_pri[chk_tag];
            if (chk.Checked)
            {
                total_payable += price;
                select_amt[chk_tag] = true;
                num_amenities_selected++;
            }
            else
            {
                total_payable -= price;
                select_amt[chk_tag] = false;
                num_amenities_selected--;
            }
            ttp.Text = total_payable.ToString();
            lb_it_selected.Text = num_amenities_selected.ToString();
        }

        private void PurchaseAmentities_Load(object sender, EventArgs e)
        {
                lb_it_selected.Text = num_amenities_selected.ToString();
        }

        private void btnconfirmed_buy_Click(object sender, EventArgs e)
        {
            string message = "Do you confirm buy there amenities?";
            string title = "Save and confirm";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q1QGNFE;Initial Catalog=module5a;Integrated Security=True");
                //delete lựa chọn cũ trong db
                string query = "DELETE FROM AmenitiesTickets WHERE AmenitiesTickets.TicketID = " + tick_id + "";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                foreach (KeyValuePair<int,bool> item in select_amt)
                {
                    if(item.Value == true)
                    {
                        //test_string.Text = item.Key +","+tick_id;
                        //query = "INSERT INTO AmenitiesTickets VALUES(" + item.Key + "," + tick_id + "," + amt_pri[item.Key] + ")";
                        query = "INSERT INTO AmenitiesTickets VALUES('" + item.Key + "','" + tick_id + "',111)";
                        cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clear_old_data()
        {
            int c = groupBox2.Controls.Count;

            for (int i = c - 1; i >= 0; i--)
                groupBox2.Controls.Remove(groupBox2.Controls[i]);
            select_amt.Clear();
            amt_pri.Clear();
            txtTicketInfo.Items.Clear();
        }

    }
}
