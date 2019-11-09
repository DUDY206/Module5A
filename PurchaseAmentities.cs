﻿using System;
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

        List<double> list_price = new List<double>();
        int num_amenities = 0, num_amenities_selected = 0;
        
        private void btnOK_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q1QGNFE;Initial Catalog=module5a;Integrated Security=True");
            string query = "SELECT Tickets.FirstName,Tickets.LastName,CabinTypes.Name,Tickets.PassportNumber,Schedules.ID,Routes.DepartureAirportID,Routes.ArrivalAirportID,Schedules.Date,Schedules.Time,CabinTypes.ID,Tickets.ID FROM Tickets INNER JOIN Schedules ON Tickets.ScheduleID = Schedules.ID INNER JOIN Routes ON Schedules.RouteID = Routes.ID INNER JOIN CabinTypes ON Tickets.CabinType = CabinTypes.ID WHERE Tickets.BookingReference = '" + txtBR.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            string Sched_ID, DA_ID, AA_ID,tick_id,cabin_id ;
            DateTime Sched_Date;
            TimeSpan Sched_Time;
            SqlDataReader sdr = cmd.ExecuteReader();

            
            if (sdr.HasRows)
            {
                //MessageBox.Show("OK");
                while (sdr.Read())
                {
                    txtName.Text = sdr.GetString(0) +" "+ sdr.GetString(1);
                    txtCabinClass.Text = sdr.GetString(2);
                    txtPPNum.Text = sdr.GetString(3);
                    Sched_ID = sdr.GetString(4);
                    DA_ID = sdr.GetString(5);
                    AA_ID = sdr.GetString(6);
                    Sched_Date = sdr.GetDateTime(7);
                    Sched_Time = sdr.GetTimeSpan(8);
                    cabin_id = sdr.GetString(9);
                    tick_id = sdr.GetString(10);

                    
                    txtTicketInfo.Text = Sched_ID + ", " + DA_ID + "-" + AA_ID + ", " + Sched_Date.Date.ToString("dd/MM/yyyy") + ", " + Sched_Time.ToString("hh\\:mm");

                   
                    sdr.Close();
                    query = "SELECT Amenities.AmenService,Amenities.Price FROM Amenities INNER JOIN AmenitiesCabinType ON Amenities.ID = AmenitiesCabinType.AmenitiesID WHERE AmenitiesCabinType.CabinTypeID = '"+ cabin_id + "'";

                    cmd = new SqlCommand(query, con);
                    sdr = cmd.ExecuteReader();

                    
                    if (sdr.HasRows)
                    {
                        int index_top = 0,index_left=0;
                        while (sdr.Read())
                        {
                            CheckBox checkbox_t = new CheckBox();
                            this.groupBox2.Controls.Add(checkbox_t);

                            
                            //checkbox_t.Text = sdr.GetString(0) ;
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
                            list_price.Add(price);
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
                            checkbox_t.Name = "cbx_amen" + num_amenities.ToString();
                            num_amenities++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("KHong co amenities thuoc cabin type :"+cabin_id);
                    }
                }
            }
            else
            {
                MessageBox.Show("NOT");
            }

        }

        private void PurchaseAmentities_Load(object sender, EventArgs e)
        {
            lb_it_selected.Text = num_amenities.ToString();
        }
    }
}