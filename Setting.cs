using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesbahComponent;
using System.Text.RegularExpressions;
using AmirCalendar;
using System.Diagnostics;

namespace ClinicMesbah
{
    public partial class Setting : Form
    {
        bool CalenderEnable;
        Color color; 
        private ToolStripMenuItem menuActiveTop;
        DataAccess da = new DataAccess();
        DataTable Department = new DataTable();
        DataTable shifts = new DataTable(); DataTable setting = new DataTable(); DataTable shift = new DataTable();
        public Setting()
        {
            InitializeComponent();
           
        }
        private void SelectMenuTop(ToolStripMenuItem menuItem)//تنظیمات دیزاین منو نمایش بخش ها
        {
            MenuItem1ToolStripMenuItem.Checked = false;
            MenuItem2ToolStripMenuItem.Checked = false;
            MenuItem3ToolStripMenuItem.Checked = false;
            MenuItem6ToolStripMenuItem.Checked = MenuItem7ToolStripMenuItem.Checked =
            MenuItem5ToolStripMenuItem.Checked=  MenuItem4ToolStripMenuItem.Checked = false;
            MenuItem1ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem2ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem3ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem6ToolStripMenuItem.BackColor = MenuItem7ToolStripMenuItem.BackColor =
            MenuItem5ToolStripMenuItem.BackColor = MenuItem4ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem1ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem2ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem3ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem6ToolStripMenuItem.ForeColor = MenuItem7ToolStripMenuItem.ForeColor =
            MenuItem5ToolStripMenuItem.ForeColor = MenuItem4ToolStripMenuItem.ForeColor = Color.Black;
            //menuItem.Checked = true;
            menuItem.BackColor = color;
            menuItem.ForeColor = Color.White;
            menuActiveTop = menuItem;
        }

        private bool ParseWithTwentyFourthHourToNextDay(string input)// جت تشخیص اینکه فرمت ساعت درست است یا خیر
        {

            Regex rgx = new Regex("[0-9]{2}:[0-9]{2}:[0-9]{2}");
            if (rgx.IsMatch(input))
            { return true; }

            else return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string eventlog = "save General infornatio for setting  ";


            try
            {

                if (txtAutoSmsTime.Text != "" && txtAutoSmsTime.Text != null && !ParseWithTwentyFourthHourToNextDay(txtAutoSmsTime.Text))
                {
                    var msg = "لطفا فرمت ساعت را اصلاح کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    txtAutoSmsTime.Focus();
                    return;
                }
                if (txtEndDelivercheck.Text!="" &&txtEndDelivercheck.Text!= null && !ParseWithTwentyFourthHourToNextDay(txtEndDelivercheck.Text))
                {
                    var msg = "لطفا فرمت ساعت را اصلاح کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    txtEndDelivercheck.Focus();
                    return;
                }
                


                if (da.SetSettings(Convert.ToDateTime(txtAutoSmsTime.Text), txtEmail.Text, txtMobile.Text, Convert.ToDateTime(txtEndDelivercheck.Text), radioButton1.Checked) > 0)
                ////   MessageBox.Show("ثبت با موفقیت انجام شد.");
                {
                    var msg = "ثبت با موفقیت انجام شد.";
                    MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                }
            }
            catch
            {
                NewMethod_eventlog(eventlog, 16003);
                throw;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (grdDepartments.SelectedRows.Count != 0)
            { int index = grdDepartments.SelectedRows[0].Index;
                chActive.Checked =  Convert.ToBoolean( grdDepartments.Rows[index].Cells[5].Value);
               
                // txtStartTime.Text = DataGridView.Rows[index].Cells[2].Value.ToString();
                //  txtEndTime.Text = DataGridView.Rows[index].Cells[3].Value.ToString();
                txtExtra.Text = grdDepartments.Rows[index].Cells[6].Value.ToString();
                txtVisitCount.Text = grdDepartments.Rows[index].Cells[4].Value.ToString();

            }
        }
        private void Setting_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
        }

        private void gbDepartment_Enter(object sender, EventArgs e)
        {

        }

        private void txtVisitCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void chasr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chsobh_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void MenuItem1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chsobh_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chasr_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void gbSetting_Enter(object sender, EventArgs e)
        {

        }

        private void DataGridView_SelectionChanged_1(object sender, EventArgs e)
        {

        }

        private void Setting_Load_1(object sender, EventArgs e)
        {
            if (Environment.UserDomainName == "clinics" &&
                     Environment.UserName == "rashidi")
            {
                txtAutoSmsTime.Enabled = txtEmail.Enabled = txtEndDelivercheck.Enabled = txtMobile.Enabled = radioButton1.Enabled = radioButton2.Enabled =
                txtExtra.Enabled=txtVisitCount.Enabled=txtDrCalling.Enabled=
               txtDepName.Enabled= btnCancel2.Visible = btnAdd2.Visible = btnNew.Visible = true;
            }      
            int x=Convert.ToInt32( FarsiDateHelper.GetShortFarsiDate(DateTime.Now).Split('/')[2]);
            CalenderEnable = x < 25 ? true : false;
        //    if (x == 25) CreateNextCalender();
            color = Properties.Settings.Default.Color;
            Properties.Settings.Default.Color = color;
            btnNew.Location = btnNew1.Location;
            btnNew.Size = btnNew1.Size;
            //menuStrip1.BackColor = color;
            MenuItem2ToolStripMenuItem.BackColor = color;
            MenuItem3ToolStripMenuItem.BackColor = color;
            btnAdd2.BackColor = color;
            btnCancel2.BackColor = color;
            btnAdd1.BackColor = color;
            btnAdd2.BackColor = color; btnNew1.BackColor = color;
            btnCancel1.BackColor = color;
            btnCancel2.BackColor = color;
            //menuStrip1.BackColor = color;
            btnNew.BackColor = color;
            btnDelete.BackColor = color;
            btnAdd3.BackColor = color;
            btnCancel3.BackColor = color;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor =grdDepartments.ColumnHeadersDefaultCellStyle.BackColor = color;
            dataGridView2.RowsDefaultCellStyle.SelectionBackColor = grdDepartments.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = grdDepartments.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            btnAdd2.Location = btnAdd1.Location;
            btnCancel2.Location = btnCancel1.Location; btnAdd3.Location = btnAdd1.Location;
            btnCancel3.Location = btnCancel1.Location;
            btnAdd2.Size = btnCancel2.Size = btnAdd1.Size;
            //  this.Size = new Size(this.Size.Width, 450);
            gbSetting.Visible = true;
            gbDepartment.Location = gbSetting.Location;
            string eventlog = "Get General information for setting";
            try
            {
                setting = da.ExecuteCommand("GetSetting").Tables[0];
            }
            catch
            {
                NewMethod_eventlog(eventlog, 16004);
                throw;
            }
            string eventlog1 = "GetDepartmentsIfo";
             try
             {
                 Department = da.ExecuteCommand("GetDepartmentsIfo").Tables[0];
             }
             catch
             {
                 NewMethod_eventlog(eventlog1, 16005);
                 throw;
             }
            if (setting.Rows.Count != 0)
            {
                txtAutoSmsTime.Text = setting.Rows[0]["AutoSmsTimes"].ToString();
                txtEmail.Text = setting.Rows[0]["ManagerEmail"].ToString();
                txtEndDelivercheck.Text = setting.Rows[0]["DeliverCheckstop"].ToString();
                txtMobile.Text = setting.Rows[0]["ManagerMobile"].ToString();
                radioButton1.Checked = Convert.ToBoolean(setting.Rows[0]["OnlyToday"]);
                radioButton2.Checked =! Convert.ToBoolean(setting.Rows[0]["OnlyToday"]);
            }



            grdDepartments.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            //btnAdd2.Location = btnAdd1.Location;
            //btnCancel2.Location = btnCancel1.Location;
            // this.Size = new Size(this.Size.Width, 450);
            gbSetting.Visible = true;
            gbMobile.Visible =gbOffices.Visible = false;
            gbMobile.Location=gbOffices.Location=
            gbDepartment.Location = gbSetting.Location;
            gbShift.Location = gbSetting.Location;
            gbShift.Size = gbSetting.Size;
           
            try
            { 
            Department = da.ExecuteCommand("GetDepartmentsIfo").Tables[0];
            }
            catch
            {
                NewMethod_eventlog(eventlog1, 16005);
                throw;
            }
            grdDepartments.DataSource = Department;
            string eventlog2 = "Get GetBaseShift information for setting";
            try
            {
                shift = da.ExecuteCommand("GetBaseShift").Tables[0];
                if (shift.Rows.Count != 0)
                {
                    dataGridView2.DataSource = shift;

                }
            }
            catch
            {
                NewMethod_eventlog(eventlog2, 16006);
                throw;
            }
            //grdDepartments.Columns["ExtraVisitTime"].Visible = false;
            //grdDepartments.Columns["RequestRateInHour"].Visible = false;


            txtVisitCount.Text = "3";
            SelectMenuTop(MenuItem1ToolStripMenuItem);

        }
        //تابع کپی کردن تقویم ماه گذشته
        private void CreateNextCalender()
        {
            string eventlog = "CopyWorkingHoursFromLastMonth from mounth= " + Convert.ToInt32(FarsiDateHelper.GetShortFarsiDate(DateTime.Now).Split('/')[1]) + 1;
            try
            {
                SqlParameter[] param;
                param = new SqlParameter[1];
                param[0] = new SqlParameter("@Month", Convert.ToInt32(FarsiDateHelper.GetShortFarsiDate(DateTime.Now).Split('/')[1]) + 1);


                da.ExecuteScalarSP("CopyWorkingHoursFromLastMonth", param);
            }
            catch
            {
                NewMethod_eventlog(eventlog, 16002);
                throw;
 
            }
        }

        private void DataGridView_SelectionChanged_2(object sender, EventArgs e)
        {

        }

        private void MenuItem2ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            gbShift.Visible = false;
            gbDepartment.Visible = true;
            gbSetting.Visible = false;
            gbCalender.Visible = false;
            gbOffices.Visible = false;
            gbMobile.Visible = false;
            SelectMenuTop(MenuItem2ToolStripMenuItem);
        }

        private void MenuItem1ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            gbShift.Visible = false;
            gbSetting.Visible = true;
            gbDepartment.Visible = false;
            gbCalender.Visible = false;
            gbOffices.Visible = false;
            gbMobile.Visible = false;
            SelectMenuTop(MenuItem1ToolStripMenuItem);
        }


        //if (txtExtra.Text == "" || txtVisitCount.Text == ""

        //              || txtDepName.Text == "")
        //{
        //    MessageBox.Show("اطلاعات بخش را وارد کنید");
        //    return;
        //}
        //Department dpt;
        //DataRow dr = Department.NewRow();
        //if (DataGridView.SelectedRows.Count == 0)
        //{
        //  //  List<Shift> shiftsInfos = new List<Shift>();
        //  //  if (chsobh.Checked)
        //  //      shiftsInfos.Add(new Shift(
        //  //  0, "صبح", Convert.ToDateTime(txtEndSobh.Text).TimeOfDay
        //  //      , Convert.ToDateTime(txtStartSobh.Text).TimeOfDay, 0));
        //  //  if (chasr.Checked)
        //  //      shiftsInfos.Add(new Shift(
        //  //  0, "عصر", Convert.ToDateTime(txtendasr.Text).TimeOfDay
        //  //      , Convert.ToDateTime(txtstartasr.Text).TimeOfDay, 0));

        //    dpt = new Department(0, txtDepName.Text,
        //  Convert.ToInt16(txtVisitCount.Text), Convert.ToDateTime(txtExtra.Text).TimeOfDay, null);


        //}
        //else
        //{
        //    int index = DataGridView.SelectedRows[0].Index;
        //    int id = Convert.ToInt32(DataGridView.Rows[index].Cells[0].Value);
        //    //List<Shift> shiftsInfos = new List<Shift>();
        //    //if (chsobh.Checked)
        //    //    shiftsInfos.Add(new Shift(
        //    //0, "صبح", Convert.ToDateTime(txtEndSobh.Text).TimeOfDay
        //    //    , Convert.ToDateTime(txtStartSobh.Text).TimeOfDay, 0));
        //    //if (chasr.Checked)
        //    //    shiftsInfos.Add(new Shift(
        //    //0, "عصر", Convert.ToDateTime(txtendasr.Text).TimeOfDay
        //    //    , Convert.ToDateTime(txtstartasr.Text).TimeOfDay, id));

        //    dpt = new Department(id, txtDepName.Text,
        //    Convert.ToInt16(txtVisitCount.Text), Convert.ToDateTime(txtExtra.Text).TimeOfDay, null);

        //}

        //dr["DepartmentName"] = dpt.DepartmentName;
        ////dr["StartTime"] = dpt.StartTime.TimeOfDay;
        ////dr["EndTime"] = dpt.EndTime.TimeOfDay;
        //dr["RequestRateInHour"] = dpt.VisitCount;

        //dr["ExtraVisitTime"] = dpt.ExtraVisitTime;
        //Department.Rows.Add(dr);
        //DataGridView.DataSource = Department;

        //if (da.SetDep(dpt) > 0)
        //    MessageBox.Show("ثبت با موفقیت انجام شد.");

        private void btnAdd2_Click_1(object sender, EventArgs e)
        {

        }

        private void DataGridView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void MenuItem3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuTop(MenuItem3ToolStripMenuItem);
            gbCalender.Visible = false;
            gbOffices.Visible = false;
            gbMobile.Visible = false;
            gbDepartment.Visible = false;
            gbSetting.Visible = false;
            gbShift.Visible = true;
        }

        private void MenuItem2ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SelectMenuTop(MenuItem2ToolStripMenuItem);
        }

        private void gbShift_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd2_Click_2(object sender, EventArgs e)
        {

        }

        private void txtDrCalling_Validating(object sender, CancelEventArgs e)
        {
            //TextBox box = sender as TextBox;
            //string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM)";

            //if (box != null)
            //{
            //    if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
            //    {
            //        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').");
            //        e.Cancel = true;
            //        box.Select(0, box.Text.Length);
            //    }
            //}
        }

        private void txtDrCalling_TextChanged(object sender, EventArgs e)
        {
            txtDrCalling.MaxLength = 5;
            DeleteChars();
            if (txtDrCalling.Text.Length == 1)
                if (Convert.ToInt32(txtDrCalling.Text) > 2)
                { SendKeys.Send("{BACKSPACE}"); return; }
                else if (txtDrCalling.Text.Length == 2)
                    if (Convert.ToInt32(txtDrCalling.Text) > 24)
                    { SendKeys.Send("{BACKSPACE}"); return; }
            if (txtDrCalling.Text.Length == 2)
                txtDrCalling.Text += ":";

            txtDrCalling.SelectionStart = txtDrCalling.Text.Length;
        }
        private void DeleteChars()
        {

            if (!txtDrCalling.Text.EndsWith("0") && !txtDrCalling.Text.EndsWith("1") && !txtDrCalling.Text.EndsWith("2") && !textBox1.Text.EndsWith("3") && !txtDrCalling.Text.EndsWith("4") && !txtDrCalling.Text.EndsWith("5") && !txtDrCalling.Text.EndsWith("6") && !textBox1.Text.EndsWith("7") && !txtDrCalling.Text.EndsWith("8") && !textBox1.Text.EndsWith("9") && !txtDrCalling.Text.EndsWith(":"))

                SendKeys.Send("{BACKSPACE}");

        }

        private void DataGridView_SelectionChanged_3(object sender, EventArgs e)
        {

            if (grdDepartments.SelectedRows.Count != 0)
            {
             
                int index = grdDepartments.SelectedRows[0].Index;
                chActive.Checked =  Convert.ToBoolean(grdDepartments.Rows[index].Cells[5].Value);
                //txtStartTime.Text = DataGridView.Rows[index].Cells[2].Value.ToString();
                txtDrCalling.Text = grdDepartments.Rows[index].Cells[3].Value.ToString();
                txtExtra.Text = grdDepartments.Rows[index].Cells[4].Value.ToString();
                txtVisitCount.Text = grdDepartments.Rows[index].Cells[2].Value.ToString();
                txtDepName.Text = grdDepartments.Rows[index].Cells[1].Value.ToString();


            }
        }

        private void grdDepartments_DoubleClick(object sender, EventArgs e)
        {
            int index = grdDepartments.SelectedRows[0].Index;
            grdDepartments.Rows[grdDepartments.SelectedRows[0].Index].Cells[2].Value.ToString();
            Calender c = new Calender(Convert.ToInt32(grdDepartments.Rows[grdDepartments.SelectedRows[0].Index].Cells[0].Value), grdDepartments.Rows[grdDepartments.SelectedRows[0].Index].Cells[1].Value.ToString());
            c.ShowDialog();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd2_Click_3(object sender, EventArgs e)
        {
            string eventlog = "shift Set Info";
            try
            {
                int id;


                if (txtShiftName.Text == "" || txtStartSobh.Text == "" || txtEndSobh.Text == "")
                { MessageForm.Show("لطفا اطلاعات را وارد نمایید"); return; }
                SqlParameter[] param;
                param = new SqlParameter[5];
                int index = 0;
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int i = dataGridView2.SelectedRows[0].Index;
                    id = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);
                }
                else id = 0;
                param[index++] = new SqlParameter("@StartTime", (Convert.ToDateTime(txtStartSobh.Text)).TimeOfDay);

                param[index++] = new SqlParameter("@ID", id);
                param[index++] = new SqlParameter("@EndTime", (Convert.ToDateTime(txtEndSobh.Text)).TimeOfDay);

                param[index++] = new SqlParameter("@ShiftName", txtShiftName.Text);
                da.ExecuteScalarSP("SetBaseShift", param);

                shift = da.ExecuteCommand("GetBaseShift").Tables[0];
                if (shift.Rows.Count != 0)
                {
                    dataGridView2.DataSource = shift;

                }
            }
            catch
            {
                NewMethod_eventlog(eventlog, 16001);
                throw;
            }
        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {

            string eventlog = "Department Setting Set Info for DepartmentID=  ";//
            try
            {
                int id;
               

                if (txtDrCalling.Text == "" || txtExtra.Text == "" || txtDepName.Text == "")
                {
                    MessageForm.Show("لطفا اطلاعات را وارد نمایید"); return; 
                
                }
                if (txtDrCalling.Text != "" && txtDrCalling.Text != null && !ParseWithTwentyFourthHourToNextDay(txtDrCalling.Text))
                {
                    var msg = "لطفا فرمت ساعت را اصلاح کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    txtDrCalling.Focus();
                    return;
                }
                if (txtExtra.Text != "" && txtExtra.Text != null && !ParseWithTwentyFourthHourToNextDay(txtExtra.Text))
                {
                    var msg = "لطفا فرمت ساعت را اصلاح کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    txtExtra.Focus();
                    return;
                }
                SqlParameter[] param;
                param = new SqlParameter[6];
                int index = 0;
                if (grdDepartments.SelectedRows.Count > 0)
                {
                    int i = grdDepartments.SelectedRows[0].Index;
                    id = Convert.ToInt32(grdDepartments.Rows[i].Cells[0].Value);
                }
                else id = 0;
                param[index++] = new SqlParameter("@DRCalling", (Convert.ToDateTime(txtDrCalling.Text)).TimeOfDay);

                param[index++] = new SqlParameter("@ID", id);
                param[index++] = new SqlParameter("@Extra", (Convert.ToDateTime(txtExtra.Text)).TimeOfDay);
                param[index++] = new SqlParameter("@Active", chActive.Checked);
                param[index++] = new SqlParameter("@DepName", txtDepName.Text);
                param[index++] = new SqlParameter("@RequestRateInHour", Convert.ToInt32(txtVisitCount.Text));
                // Department dep = new Department(0, txtDepName.Text, Convert.ToInt32(txtVisitCount.Text), (Convert.ToDateTime(txtExtra.Text)).TimeOfDay, !chActive.Checked);
                if (Convert.ToInt16(da.ExecuteScalarSP("SetDep", param)) == 1)
                    MessageForm.Show("ثبت با موفقیت انجام شد.", "", MessageFormIcons.Info, MessageFormButtons.Ok);
                else MessageForm.Show("در روند ثبت خطایی رخ داده است.", "", MessageFormIcons.Info, MessageFormButtons.Ok);
                Department = da.ExecuteCommand("GetDepartmentsIfo").Tables[0];
                grdDepartments.DataSource = Department;
            }
            catch
            {
                NewMethod_eventlog(eventlog, 16000);
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtShiftName.Text = "";
            txtStartSobh.Text = "";
            txtEndSobh.Text = "";
            dataGridView2.ClearSelection();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            gbCalender.Visible = true;
            gbDepartment.Visible = gbSetting.Visible = gbShift.Visible = false;
            
        }

        private void farsiCalendar1_DateChanged_1(object sender, FarsiDatePickerEventArgs e)
        {
           
            var datePicker = (FarsiCalendar)sender;
            SqlParameter[] param;
            param = new SqlParameter[3];
            int index = 0;
            param[index++] = new SqlParameter("@SectionID",-1);
           
            param[index++] = new SqlParameter("@Month", datePicker.Value.FarsiSelectedDate.Split('/')[1]);
            param[index++] = new SqlParameter("@Day", datePicker.Value.FarsiSelectedDate.Split('/')[2]);
            bool IsHoliday;
            string eventlog = "GetHolidays  for SectionID=" + -1 + "Month=" + datePicker.Value.FarsiSelectedDate.Split('/')[1] + "Day=" + datePicker.Value.FarsiSelectedDate.Split('/')[2];
            try
            {
                 IsHoliday = Convert.ToBoolean(da.ExecuteSP("GetHolidays", param).Tables[0].Rows[0][0]);
            }
            catch
            {
                NewMethod_eventlog(eventlog, 16011);
                throw;
            }
            if (CalenderEnable)
            {
                var mes = string.Format("روز:" +
                                              "{0}",

                                          //   e.NewFarsiDate + Environment.NewLine,


                         //  datePicker.Value.GregorianSelectedDate.ToShortDateString() + Environment.NewLine,
                    //datePicker.Value.NumberOfDaysInFarsiSelectedMonth + Environment.NewLine,
                                              FarsiDateHelper.GetLongFarsiDate(datePicker.Value.GregorianSelectedDate) +
                                            "این روز تعطیل است. آیا غیر تعطیل باشد؟");

                if (!IsHoliday)
                {
                    string mess;
                    mess = string.Format("این روز کاری است. آیا  تعطیل باشد؟");

                    MessageFormResult r = MessageForm.Show(mess, "", MessageFormIcons.Question, MessageFormButtons.YesNo, color);
                    if (r == MessageFormResult.Yes)
                    {
                        SqlParameter[] pa;
                        pa = new SqlParameter[3];
                        int ind = 0;

                        pa[ind++] = new SqlParameter("@SectionID", -1);
                        pa[ind++] = new SqlParameter("@Month", datePicker.Value.FarsiSelectedDate.Split('/')[1]);
                        pa[ind++] = new SqlParameter("@Day", datePicker.Value.FarsiSelectedDate.Split('/')[2]);

                        string eventlog1 = "SetHolidays  for SectionID=" + -1 + "Month=" + datePicker.Value.FarsiSelectedDate.Split('/')[1] + "Day=" + datePicker.Value.FarsiSelectedDate.Split('/')[2];
                        try
                        {
                            da.ExecuteSP("SetHolidays", pa);
                        }
                        catch
                        {
                            NewMethod_eventlog(eventlog1, 16012);
                            throw;
                        }
                    }
                }
                else
                {
                    MessageFormResult r = MessageForm.Show(mes, "", MessageFormIcons.Question, MessageFormButtons.YesNo, color);
                    if (r == MessageFormResult.Yes)
                    {
                        SqlParameter[] pa;
                        pa = new SqlParameter[3];
                        int ind = 0;
                        pa[ind++] = new SqlParameter("@SectionID", -1);
                        pa[ind++] = new SqlParameter("@Month", datePicker.Value.FarsiSelectedDate.Split('/')[1]);
                        pa[ind++] = new SqlParameter("@Day", datePicker.Value.FarsiSelectedDate.Split('/')[2]);
                         string eventlog1 = "DeleteHolidays  for SectionID=" + -1 + "Month=" + datePicker.Value.FarsiSelectedDate.Split('/')[1] + "Day=" + datePicker.Value.FarsiSelectedDate.Split('/')[2];
                         try
                         {

                             da.ExecuteSP("DelHolidays", pa);
                         }
                         catch
                         {
                             NewMethod_eventlog(eventlog1, 16013);
                             throw;
                         }
                    }
                }
            }
            else
            {
                var mes = string.Format("روز:" +
                                                  " {0}",

                                              //   e.NewFarsiDate + Environment.NewLine,


                             //  datePicker.Value.GregorianSelectedDate.ToShortDateString() + Environment.NewLine,
                    //datePicker.Value.NumberOfDaysInFarsiSelectedMonth + Environment.NewLine,
                                                  FarsiDateHelper.GetLongFarsiDate(datePicker.Value.GregorianSelectedDate) +
                                                "این روز تعطیل است.");
                if (!IsHoliday)
                {
                    string mess;
                    mess = string.Format("روز:" + " {0}",
                  FarsiDateHelper.GetLongFarsiDate(datePicker.Value.GregorianSelectedDate) +
                                                  "این روز کاری است.");

                    MessageForm.Show(mess, "", MessageFormIcons.Question, MessageFormButtons.Ok, color);

                }
                else
                {
                    MessageForm.Show(mes, "", MessageFormIcons.Question, MessageFormButtons.Ok, color);


                }
            }
        }

        private void btnNew1_Click(object sender, EventArgs e)
        {
            grdDepartments.ClearSelection();
            txtDepName.Text = "";
            txtDrCalling.Text = "";
            txtExtra.Text = "00:00:00";
            txtVisitCount.Text = "17";
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                  txtStartSobh.Text = dataGridView2.Rows[index].Cells[2].Value.ToString();
                txtEndSobh.Text = dataGridView2.Rows[index].Cells[3].Value.ToString();
                txtShiftName.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {

        }

        private void تقویمکلینیکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuTop(MenuItem5ToolStripMenuItem);

            gbCalender.Visible = true;
            gbDepartment.Visible = false;
            gbSetting.Visible = false;
            gbShift.Visible = false;
            gbOffices.Visible = false;
            gbMobile.Visible = false;
        }

        private void MenuItem1ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;//دیزاین
        }

        private void MenuItem1ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;//دیزاین
        }

        private void MenuItem6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuTop(MenuItem6ToolStripMenuItem);
gbCalender.Visible = false;
            gbOffices.Visible = true;
            txtCenterName.Visible = true;
            lblCenterNmae.Visible =
                txtAddress.Visible =
                lblAddressCenter.Visible =
                    lblCenterEmail.Visible =
                    txtEmailCenter.Visible =
                        lblCenterTel.Visible =
                        txtTelephone.Visible =
                            lblCenterType.Visible =
                            rbDrugstore.Visible =
                                rbLabratory.Visible = true;
            

            gbDepartment.Visible = false;
            gbSetting.Visible = false;
            gbShift.Visible = false;
            
            gbMobile.Visible = false;
           
        }

        private void MenuItem7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuTop(MenuItem7ToolStripMenuItem);gbMobile.Visible = true;
            gbCalender.Visible = false;
            gbDepartment.Visible = false;
            gbSetting.Visible = false;
            gbShift.Visible = false;
            gbOffices.Visible = false;
            
        }
    }
}
 
