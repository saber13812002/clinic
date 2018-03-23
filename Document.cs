using MesbahComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicMesbah
{
    public partial class Document : Form
    {
        public string _mobileNumber;
        private Color color;
        private string nasionalityCode; private string TelORMobile;
        DataAccess da = new DataAccess();
        public Document()
        {
            InitializeComponent();
        }
        public Document(string nasionalityCode , string TelORMobile)
        {
            InitializeComponent();
            this.nasionalityCode = nasionalityCode;
            this.TelORMobile = TelORMobile;
        }
        private void setcolor()
        {
            color = Properties.Settings.Default.Color;
            gbEnergy.BackColor = ControlPaint.LightLight(ControlPaint.LightLight((ControlPaint.LightLight(color))));
            
            button1.BackColor = color;
            button2.BackColor = color;
        }
        private bool IsMobileNumberValid(string mobileNumber)
        {

            _mobileNumber = CleanNumber(mobileNumber);


            _mobileNumber = _mobileNumber.TrimStart(new char[] { '0' });


            if (_mobileNumber.StartsWith("98"))
            {
                _mobileNumber = _mobileNumber.Remove(0, 2);
            }


            if (!_mobileNumber.StartsWith("9"))
            {
                return false;
            }


            if (_mobileNumber.Length != 10)
            {
                return false;
            }

            return true;
        }
        private string CleanNumber(string phone)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(phone, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string eventlog = "set a Document for a NationalityCode=" + txtNationalityCode.Text;
            try
            {
                int result = da.InsertPatient("SetCostumerInfo", txtNationalityCode.Text, txtName.Text, txtLastName.Text, txtFather.Text, txtAdress.Text, txtisurance.Text, txtTel.Text, txtMobile.Text);
                if (result > 0)
                {
                    var msg = "ثبت با موفقیت انجام شد";
                    MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                  
                    txtAdress.Enabled = false;
                    txtFather.Enabled = false;
                    txtisurance.Enabled = false;
                    txtLastName.Enabled = false;
                    txtMobile.Enabled = false;
                    txtName.Enabled = false;
                    txtTel.Enabled = false;
                    txtNationalityCode.Enabled = false;
                    button2.Enabled = false;
            
                }
                else
                {
                    var msg = "ثبت ناموفق بود";
                    MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                
                    timer1.Start();
                }


            }
            catch (Exception e1)
            {


                NewMethod_eventlog(eventlog, 17000);
                throw;
            }

        }
        private static void NewMethod_eventlog(string eventlog, int id)
        {
            EventLog log = new EventLog();
            //log.taskca
            log.Source = "application";
            log.WriteEntry(eventlog, EventLogEntryType.Information, id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Document_Load(object sender, EventArgs e)
        {

           // System.Timers.Timer aTimer = new System.Timers.Timer(10000);

            // Hook up the Elapsed event for the timer.
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            
            // Set the Interval to 2 seconds (2000 milliseconds).
            timer1.Interval = 500;
            timer1.Enabled = false;
            
            DataSet ds = new DataSet();

            txtNationalityCode.Text = nasionalityCode;
                if(IsMobileNumberValid( TelORMobile))
                  txtMobile.Text=TelORMobile;
                else
                    txtTel.Text =TelORMobile;
                string eventlog = "Get a Document by a NationalityCode=" + nasionalityCode;
                try
                {
                    ds = da.GetpationtInfo("GetCustomerInfo", nasionalityCode);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtAdress.Text = ds.Tables[0].Rows[0]["Adress"].ToString();
                            txtFather.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                            txtisurance.Text = ds.Tables[0].Rows[0]["IsuranceID"].ToString();
                            txtLastName.Text = ds.Tables[0].Rows[0]["Lname"].ToString();
                            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["Fname"].ToString();
                            txtTel.Text = ds.Tables[0].Rows[0]["Telphone"].ToString();
                        }
                    }
                }
                catch
                {
                    NewMethod_eventlog(eventlog, 17001);
                    throw;
                }
                setcolor();
        }

        private void txtNationalityCode_KeyDown(object sender, KeyEventArgs e)
        {
            //char c = Convert.ToChar(e.PlatformKeyCode);
            //if (!char.IsDigit(c))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtisurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
            if (txtMobile.Text.Length > 10)
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtNationalityCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
            if (txtNationalityCode.Text.Length > 9)
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Gray)
            { button1.BackColor = Color.Red; }
            else
            { button1.BackColor = Color.Gray; }
        }


    }
}
