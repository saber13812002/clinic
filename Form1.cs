using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesbahComponent;
using MesbahComponent.Grid;
using System.Threading;
using System.Media;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Timers;
using AmirCalendar;
using System.Diagnostics;
using System.Xml;
using USBDriveSerialNumber;

namespace ClinicMesbah
{
    public partial class Form1 : Form
    {
       
        #region Variables 
        public short DepartmentSelected;
        List<DataMesbah> lst = new List<DataMesbah>(); Int64 Counter=0;
        public static SystemSound Beep { get; set; }
        private short DepartmentID = 0;
        private DataSet DepartementInfo = new DataSet();
        private DataSet sectionDS = new DataSet();
        private Byte witchDay;
        private ToolStripItem menuActiveRight;
        private ToolStripMenuItem menuActiveTop;
        private DataTable dt = new DataTable();
        private DataTable smsDt = new DataTable();
        bool sentsms = false; Color color;
        public string IDs = "";
        private DataAccess da = new DataAccess();
        public string _mobileNumber;
        private List<Patient> patientList = new List<Patient>();
        private Patient patient = new Patient();
        private byte status = 0;//0=sms, 1= tel 3= tel&sms
        private int columnCount;
        private float IndexSortOld;
        private float IndexSortNew;
        public DataSet GridDataSource;
        private List<String> columnsKey;
        private bool showdeleteDialogbox = true; 
        private bool exchangeclicked = false;
        private bool haveChekBoxColumn;
        public bool pasteRow;
        private bool rowsSelectedForCopy;
        private bool rowSelectedForCopy;
        private int startime;
        private int endtime;
        private Color backColor;
        private int steps=1;
        private bool todaytelephon=false;
        private bool todaySMS = true;
        private bool todayagainConnect = false;
        private bool todayfinalyTry = false;
        private bool tomarowtelephon = false;
        private bool tomarowSMS = true;
        private bool tomarowagainConnect = false;
        private bool tomarowfinalyTry = false;
        private XmlDocument doc;
        private string PATH = Application.StartupPath + @"\setting.xml";
        private int current = 0;
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            //SelectMenuRight(menuStrip1.Items[0]);// تنظیمات دیزاین منوی بخش ها
            SelectMenuTop(MenuTop4ToolStripMenuItem);// تنظیمات دیزاین منوی مراحل قطعی کردن
            setcolor();
        }
        #endregion

        #region eventlog

        private static void NewMethod_eventlog(string eventlog, int id)
        {
            EventLog log = new EventLog();
            //log.taskca
            log.Source = "application";
            log.WriteEntry(eventlog, EventLogEntryType.Information, id);
        }
        #endregion

        #region ColorBox
        private void colorBox1_ColorChange(Color color)
        {
            //color = Properties.Settings.Default.Color;
            //TopPanelWithBorder.BorderColor = color;
            //BottomPanelWithBorder.BorderColor = color;
            //RightPanelWithBorder.BorderColor = color;
            //MenuRightPanelWithBorder.BorderColor = color;
            //SendSMSPanelWithBorder.BorderColor = color;
            //ColorCheckBox.BackColor = color;
            ////menuActiveRight.BackColor = color;
            //menuActiveTop.BackColor = color; button4.BackColor = color;
            //SendSMSButton.BackColor = color;
            //SMSDataGridView.ColumnHeadersDefaultCellStyle.BackColor = color;
            //SMSDataGridView.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            //SMSDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            //button1.BackColor = color;
            //button2.BackColor = color;
            //button3.BackColor = color;

            ////btnToday.BackColor = Color.c;
            ////btnTomarow.BackColor = color;
            ////button4.BackColor = color;
            ////button5.BackColor = color;
            ////button6.BackColor = color;
            //gridMesbah2.RowsBorderColor = color;
            //gridMesbah2.CellsBorderColor = ControlPaint.Dark(color);
            //gridMesbah2.CellsForColor = ControlPaint.DarkDark(color);
            //gridMesbah2.CellsButtonColor = color;
            //SendSMSColorProgressBar.BarColor = ControlPaint.LightLight(color);

             this.color=color ;
            Properties.Settings.Default.Color = color;
            //   Properties.Settings.Default.GridText = dataGridView1.Rows[0].Cells[0].Value.ToString();

            Properties.Settings.Default.Save();
          
            //   Properties.Settings.Default.GridText = dataGridView1.Rows[0].Cells[0].Value.ToString();
           // Color C = Properties.Settings.Default.myColor;
            TopPanelWithBorder.BorderColor = color;
            BottomPanelWithBorder.BorderColor = color;
            RightPanelWithBorder.BorderColor = color;
            MenuRightPanelWithBorder.BorderColor = color;
            SendSMSPanelWithBorder.BorderColor = color;
            ColorCheckBox.BackColor = color;
            if (menuActiveRight!=null)
            menuActiveRight.BackColor = color;
            menuActiveTop.BackColor = color;
            SendSMSButton.BackColor = color; button4.BackColor = color;
            SMSDataGridView.ColumnHeadersDefaultCellStyle.BackColor = color;
            SMSDataGridView.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            SMSDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            button1.BackColor = color;
            button2.BackColor = color;
            button3.BackColor = color;
            if (btnToday.BackColor != System.Drawing.Color.FromName("Control"))
            btnToday.BackColor = color;
            if (btnTomarow.BackColor != System.Drawing.Color.FromName("Control"))
           
           btnTomarow.BackColor = color;
            //button4.BackColor = color;
            //button5.BackColor = color;
            //button6.BackColor = color;
            gridMesbah2.RowsBorderColor = color;
            gridMesbah2.CellsBorderColor = ControlPaint.Dark(color);
            gridMesbah2.CellsForColor = ControlPaint.DarkDark(color);
            gridMesbah2.CellsButtonColor = color;
            lblDate1.ForeColor = ControlPaint.Dark(color);
            lblDate1.BackColor = ControlPaint.LightLight(ControlPaint.LightLight((color)));
            lblDate.ForeColor = ControlPaint.Dark(color);
            lblDate.BackColor = ControlPaint.LightLight(ControlPaint.LightLight((color)));
            SendSMSColorProgressBar.BarColor = ControlPaint.LightLight(color);

        }

        private void colorBox1_Leave(object sender, EventArgs e)
        {
            ColorCheckBox.Checked = false;
          //  Properties.Settings.Default.myColor = Color.AliceBlue;
         //   Properties.Settings.Default.GridText = dataGridView1.Rows[0].Cells[0].Value.ToString();

          //  Properties.Settings.Default.Save();
        }

        private void ColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            colorBox1.Visible=panel4.Visible = ColorCheckBox.Checked;
        }
        #endregion

        #region btnMouse_Enter_Leave

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Image = Properties.Resources.Dental;//دیزاین
            button1.Text = string.Empty;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.GREY;//دیزاین
            button2.Text = string.Empty;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = null;//دیزاین
           button1.Text = "داروخانه";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = null;//دیزاین
            button2.Text = "پزشک";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Text = string.Empty;//دیزاین
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Text = "تنظیمات";//دیزاین
        }

        private void btnToday_MouseEnter(object sender, EventArgs e)
        {
            btnToday.Text = string.Empty;//دیزاین
        }

        private void btnToday_MouseLeave(object sender, EventArgs e)
        {
            btnToday.Text = "امروز";//دیزاین
        }

        private void btnTomarow_MouseEnter(object sender, EventArgs e)
        {
            btnTomarow.Text = string.Empty;//دیزاین
        }

        private void btnTomarow_MouseLeave(object sender, EventArgs e)
        {
            btnTomarow.Text = "فردا";//دیزاین
        }

        #endregion

        #region Menu
        private void MenuItem1ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;//دیزاین
           
        }

        private void MenuItem1ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;//دیزاین
        }

        private void MenuItem1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SelectMenuRight(MenuItem1ToolStripMenuItem);//تنظیمات دیزاین منو مراحل قطعی کردن
            //MenuItemClickHandler(MenuItem1ToolStripMenuItem);
        }

        private void MenuItem2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SelectMenuRight(MenuItem2ToolStripMenuItem);//تنظیمات دیزاین منو مراحل قطعی کردن
            //MenuItemClickHandler(MenuItem2ToolStripMenuItem);
        }

        private void MenuItem3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SelectMenuRight(MenuItem3ToolStripMenuItem);//تنظیمات دیزاین منو مراحل قطعی کردن
            //MenuItemClickHandler(MenuItem3ToolStripMenuItem);
        }

        private void MenuItem4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    SelectMenuRight(MenuItem4ToolStripMenuItem);//تنظیمات دیزاین منو مراحل قطعی کردن
        //    MenuItemClickHandler(MenuItem4ToolStripMenuItem);
        }

        private void SelectMenuRight(ToolStripItem menuItem)//تنظیمات دیزاین منو مراحل قطعی کردن
        {
            menuStrip1.Items[0].BackColor = menuStrip1.Items[1].BackColor = menuStrip1.Items[2].BackColor = menuStrip1.Items[3].BackColor = Color.Transparent;

            menuStrip1.Items[0].ForeColor = menuStrip1.Items[1].ForeColor = menuStrip1.Items[2].ForeColor = menuStrip1.Items[3].ForeColor = Color.Black;
            //MenuItem1ToolStripMenuItem.Checked = false;
            //MenuItem2ToolStripMenuItem.Checked = false;
            //MenuItem3ToolStripMenuItem.Checked = false;
            //MenuItem4ToolStripMenuItem.Checked = false;
            //MenuItem1ToolStripMenuItem.BackColor = Color.Transparent;
            //MenuItem2ToolStripMenuItem.BackColor = Color.Transparent;
            //MenuItem3ToolStripMenuItem.BackColor = Color.Transparent;
            //MenuItem4ToolStripMenuItem.BackColor = Color.Transparent;
            //MenuItem1ToolStripMenuItem.ForeColor = Color.Black;
            //MenuItem2ToolStripMenuItem.ForeColor = Color.Black;
            //MenuItem3ToolStripMenuItem.ForeColor = Color.Black;
            //MenuItem4ToolStripMenuItem.ForeColor = Color.Black;
            //menuItem.Checked = true;
            menuItem.BackColor = color;
            menuItem.ForeColor = Color.White;
            menuActiveRight = menuItem;
        }

        private void SelectMenuTop(ToolStripMenuItem menuItem)//تنظیمات دیزاین منو نمایش بخش ها
        {
            MenuTop1ToolStripMenuItem.Checked = false;
            MenuTop2ToolStripMenuItem.Checked = false;
            MenuTop3ToolStripMenuItem.Checked = false;
            MenuTop4ToolStripMenuItem.Checked = false;
            MenuTop1ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop2ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop3ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop4ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop1ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop2ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop3ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop4ToolStripMenuItem.ForeColor = Color.Black;
            menuItem.Checked = true;
            menuItem.BackColor = color;
            menuItem.ForeColor = Color.White;
            menuActiveTop = menuItem;
        }

        private void MenuTop1ToolStripMenuItem_Click(object sender, EventArgs e)// ارتباط دوباره
        {
            string eventlog = "Get Indecisive Intermittences for step 3 (Tel & SMS) by DepartmentID= " + DepartmentID+ "and Day ="+ witchDay;

        try
        {
            steps = 3;
            SendSMSButton.Text = "اتمام ارتباط دوباره ";

            status = 3;//  ( داده های مربوط به نوبت دهی پیامکی (پیام ها ی دلیور نشده)و تلفنی ها( اشغال Status=3/Status=0 SMS/Status=1 Tel
            DataSet IntermittenceDS = new DataSet();
            IntermittenceDS = da.ExecuteCommand("GetTelSecodTime", DepartmentID, witchDay);// نوبت هایی که در دو استپ قبل  با پیامک و تلفن نتواستیم قطعی کنیم به علت دلیور نشدن و یا اشغال بودن
            GridSetTel(); // تنظیم عنوان و نوع  ستون های گرید قطعی کردن 
            FillTelGrid(IntermittenceDS); // پرکردن گرید قطعی کردن 
            SelectMenuTop(MenuTop1ToolStripMenuItem);//تنظیمات دیزاین منو نمایش بخش ها
            if (witchDay == 0)//witchDay=0 امروز witchDay=1 فردا
            {
                MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = todaySMS;// اگر باتن ارسال شد تب پیامک برا ی امروز کلیک شده است تب پیامک غیر فعال و غیر انتخاب شده باشد 
                MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = todaytelephon;// اگر باتن اتمام تماس تب تلفن  برای امروز کلیک شده است تب تلفن غیر فعال و غیر انتخاب شده باشد 
                MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = todayagainConnect;// اگر باتن اتمام ارتباط دوباره تب اتباط دوباره  برای امروز کلیک شده است تب اتباط دوباره غیر فعال و غیر انتخاب شده باشد
                MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry;// اگر باتن قطعی کردن کلی  تب قطعی کردن نهایی  برای امروز کلیک شده است تب قطعی کردن نهایی غیر فعال و غیر انتخاب شده باشد
                SMSDataGridView.Enabled = todayagainConnect;
                SendSMSButton.Enabled = todayagainConnect;

                if (todayagainConnect) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;//اگر قطعی کردن کلی را برای امرزواعمال کرده است گرید قطعی کردن با رنگ خاکستری غیر فعال شود
            }
            if (witchDay == 1)//witchDay=0 امروز witchDay=1 فردا
            {
                MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = tomarowSMS;// اگر باتن ارسال شد تب پیامک برا ی فردا کلیک شده است تب پیامک غیر فعال و غیر انتخاب شده باشد 
                MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon;// اگر باتن اتمام تماس تب تلفن  برای فردا کلیک شده است تب تلفن غیر فعال و غیر انتخاب شده باشد 
                MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect;// اگر باتن اتمام ارتباط دوباره تب اتباط دوباره  برای فردا کلیک شده است تب اتباط دوباره غیر فعال و غیر انتخاب شده باشد
                MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry;// اگر باتن قطعی کردن کلی  تب قطعی کردن نهایی  برای فردا کلیک شده است تب قطعی کردن نهایی غیر فعال و غیر انتخاب شده باشد
                SMSDataGridView.Enabled = tomarowagainConnect;
                SendSMSButton.Enabled = tomarowagainConnect;

                if (tomarowagainConnect) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;//اگر قطعی کردن کلی را برای فردا اعمال کرده است گرید قطعی کردن با رنگ خاکستری غیر فعال شود
            }
        }
        catch
        {
            NewMethod_eventlog(eventlog, 15013);
            throw;
        }
        }

        private void MenuTop2ToolStripMenuItem_Click(object sender, EventArgs e)// تب قطعی کردن نهایی
        { string eventlog = "Get Indecisive Intermittences for step 4 (Finaly Try for tel & sms) by DepartmentID= " + DepartmentID+ "and Day ="+ witchDay;

        try
        {
            steps = 4;// مرحله 4
            SendSMSButton.Text = "قطعی کردن کلی";
            SendSMSButton.Tag = 4;
            status = 3;
            DataSet IntermittenceDS = new DataSet();
            IntermittenceDS = da.ExecuteCommand("GetTelSecodTime", DepartmentID, witchDay);// نوبت هایی که در دو استپ قبل  با پیامک و تلفن نتواستیم قطعی کنیم به علت دلیور نشدن و یا اشغال بودن 
            GridSetTel();// تنظیم عنوان و نوع  ستون های گرید قطعی کردن 
            FillTelGrid(IntermittenceDS);// پرکردن گرید قطعی کردن
            SelectMenuTop(MenuTop2ToolStripMenuItem);//تنظیمات دیزاین منو نمایش بخش ها
            if (witchDay == 0)//witchDay=0 امروز witchDay=1 فردا
            {
                MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = todaySMS;
                MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = todaytelephon;
                MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = todayagainConnect;
                MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry;
                SMSDataGridView.Enabled = todayfinalyTry;
                SendSMSButton.Enabled = todayfinalyTry;
                if (todayfinalyTry) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
            }
            if (witchDay == 1)//witchDay=0 امروز witchDay=1 فردا
            {
                MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = tomarowSMS;
                MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon;
                MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect;
                MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry;
                SMSDataGridView.Enabled = tomarowfinalyTry;
                SendSMSButton.Enabled = tomarowfinalyTry;
                if (tomarowfinalyTry) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;

            }
        }
        catch
        {
            NewMethod_eventlog(eventlog, 15014);
            throw;
        }
        }

        private void MenuTop3ToolStripMenuItem_Click(object sender, EventArgs e)// تب تلفن ثابت
        {
            string eventlog = "Get Indecisive Intermittences for step 2 (Tel) by DepartmentID= " + DepartmentID+ "and Day ="+ witchDay;

            try
            {
                steps = 2;
                SendSMSButton.Text = "اتمام تماس ها ";


                status = 1;
                DataSet IntermittenceDS = new DataSet();
                IntermittenceDS = da.ExecuteCommand("GetTelFirstTime", DepartmentID, witchDay);//نوبت هایی که چه تلفنی و چه پیامکی برای اولین بار قصد داریم قطعی کنیم 
                GridSetTel();
                FillTelGrid(IntermittenceDS);
                SelectMenuTop(MenuTop3ToolStripMenuItem);

                if (witchDay == 0)
                {
                    MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = todaySMS;
                    MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = todaytelephon;
                    MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = todayagainConnect;
                    MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry;
                    SMSDataGridView.Enabled = todaytelephon;
                    SendSMSButton.Enabled = todaytelephon;
                    if (todaytelephon) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
                }
                if (witchDay == 1)
                {
                    MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = tomarowSMS;
                    MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon;
                    MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect;
                    MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry;
                    SMSDataGridView.Enabled = tomarowtelephon;
                    SendSMSButton.Enabled = tomarowtelephon;
                    if (tomarowtelephon) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;

                }
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15012);
                throw;
            }
        }

        private void MenuTop4ToolStripMenuItem_Click(object sender, EventArgs e)// تب پیامک
        {
            string eventlog = "Get Indecisive Intermittences for step 1 (SMS) by DepartmentID= " + DepartmentID+ "and Day ="+ witchDay;

            try
            {
                SendSMSButton.Text = "ارسال پیامک ها";

                steps = 1;
                status = 0;
                DataSet IntermittenceDS = new DataSet();
                IntermittenceDS = da.ExecuteCommand("GetTelFirstTime", DepartmentID, witchDay);//نوبت هایی که چه تلفنی و چه پیامکی برای اولین بار قصد داریم قطعی کنیم
                GridSetTel();
                FillTelGrid(IntermittenceDS);
                SelectMenuTop(MenuTop4ToolStripMenuItem);
                if (witchDay == 0)
                {
                    SMSDataGridView.Enabled = todaySMS;
                    SendSMSButton.Enabled = todaySMS;
                    if (todaySMS) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
                    MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = todaySMS;
                    MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = todaytelephon;
                    MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = todayagainConnect;
                    MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry;
                }
                if (witchDay == 1)
                {
                    MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = tomarowSMS;
                    MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon;
                    MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect;
                    MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry;
                    SMSDataGridView.Enabled = tomarowSMS;
                    SendSMSButton.Enabled = tomarowSMS;
                    if (tomarowSMS) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
                }
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15011);
                throw;
            }
        }


        #region FillMenu
        private void FillMenu()
        {
            string eventlog = "Fill Departments Menu";
            try
            {
                menuStrip1.Items.Clear();
                int i = 0;
                ToolStripMenuItem[] items = new ToolStripMenuItem[sectionDS.Tables[0].Rows.Count]; // You would obviously calculate this value at runtime
                foreach (DataRow Row in sectionDS.Tables[0].Rows)// there is one department in each row 
                {
                    items[i] = new ToolStripMenuItem();
                    items[i].Name = "Item" + i.ToString();
                    items[i].Tag = Row["DepartmentID"];// set tag by department ID
                    items[i].Text = Row["DepartmentName"].ToString();// set tag by department Name
                    //items[i].Click += new EventHandler(MenuItemClickHandler);// add an event that fire when click on 
                    menuStrip1.Items.Add(items[i]);// add items to menuStrip control from DS
                    i++;
                }
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15007);
                throw;
            }

            //  MenuItemClickHandler(null, null);

        }

        private void MenuItemClickHandler(ToolStripMenuItem clickedItem)// fire when clicked on menuStrip Tabs
        {

        //    ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            DepartmentID = Convert.ToInt16(clickedItem.Tag);// get the ID of Clicked Tab
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            string eventlog = "Get Department info by DepartmentID=" + DepartmentID;
            try
            {
                if (DepartmentSelected != null)
                    if (DepartmentSelected != DepartmentID)
                    {
                        param[index++] = new SqlParameter("@DepartementId", DepartmentID);
                        DepartementInfo = da.ExecuteCommand("GetDepartementInfo", DepartmentID);// get Clicke Department Information From DB
                        if (DepartementInfo.Tables[0].Rows.Count > 0)
                        {
                            //startime = DepartementInfo.Tables[0].Rows[0]["StartTime"].ToString() != "" ? Convert.ToInt16(DepartementInfo.Tables[0].Rows[0]["StartTime"].ToString()) : 0;
                            //endtime = DepartementInfo.Tables[0].Rows[0]["EndTime"].ToString() != "" ? Convert.ToInt16(DepartementInfo.Tables[0].Rows[0]["EndTime"].ToString()) : 0;
                        }

                        FillGrid();// Fill Secretary Kartable Grid
                       
                       
                        DepartmentSelected = DepartmentID;//save selected Depertment ID as A Public Variable
                    } 
                SelectMenuRight(clickedItem);
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15008);
                throw;
            }
        }
        #endregion

        #endregion

        #region Grid

        private void FillTelGrid(DataSet IntermittenceDS)// پرکردن گرید قطعی کردن  
        {
            string eventlog = "Fill Decisive Grid";
            try
            {
                smsDt.Rows.Clear();
                if (SMSDataGridView.Rows.Count > 0)
                    SMSDataGridView.Rows.Clear();
                if (SMSDataGridView.DataSource != null)
                    smsDt = (DataTable)SMSDataGridView.DataSource;// پاک کردن داده های قبلی گرید

                foreach (DataRow row in IntermittenceDS.Tables[0].Rows)
                {

                    if ((status == 0 && IsMobileNumberValid(row["Telphone"].ToString())) || (status == 1 && !IsMobileNumberValid(row["Telphone"].ToString())) || status == 3)// بررسی میکند اگر استتوس برابر 0 باشد داده ها ی اس ام اس و اگر برابر  1 باشد داده های تلفنی و اگر برابر 3 باشد هم اس هم تل را در گرید کارتابل اضافه کند 
                    {
                        DataRow dr = smsDt.Rows.Add();
                        dr["ID"] = (row["ID"]);
                        dr["TimeCol"] = PersianDate.GetPersianDate(
                        Convert.ToDateTime(row["VisitDateTime"])).TimeOfDay.ToString().Substring(0, 5);
                        dr["CustomerCol"] = row["NationalityCode"];
                        dr["NumberCol"] = row["Telphone"];
                        dr["StateCol"] = Convert.ToBoolean(row["Status"]);
                        dr["SectionCol"] = row["DepartmentName"];
                        dr["CancelCol"] = Convert.ToBoolean(0);
                        Int32 index = SMSDataGridView.Rows.Count - 1;
                        SMSDataGridView.Rows[index].Tag = row;
                    }

                }
                SMSDataGridView.DataSource = smsDt;

                SMSDataGridView.Columns["StateCol"].Visible = status == 0 ? false : true;// اگر در مرحله پیامک هستیم نیازی به ستون چک باکس وضعیت ندارم زیرا پیامک ها غیر دستی قطعی می شوند
                SMSDataGridView.Columns["ID"].Visible = false;// در هر حالتی ستون آی دی نمایش داده نشود
                foreach (DataGridViewRow Row in SMSDataGridView.Rows)// پیمایش کل سطر های گرید قطعی کردن برای سبز کردن نوبت هایی که قطعی شده اند
                {
                    if (Convert.ToBoolean(Row.Cells["StateCol"].Value))
                    {
                        Row.DefaultCellStyle.BackColor = Color.LightGreen;
                        Row.ReadOnly = true;// اگر نوبتی قطعی شده است دیگر امکان غیر قطعی کردن آن  را ندارد
                    }
                }
            }
            catch
            {

                NewMethod_eventlog(eventlog, 15000);
                throw;
            }
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
        }// تشخیص اینکه شماره تماس ، تلفن ثابت است یا موبایل
        private string CleanNumber(string phone)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(phone, "");
        }

        private void SendSMSButton_Click(object sender, EventArgs e)
        {
            if (steps == 1)
            {
                if (SendSMSColorProgressBar.Value == 100)
                    SendSMSColorProgressBar.Value = 0;

                if (SendSMS() >0)
                {
                    SendSMSButton.Text = "ارسال شد";
                    SendSMSButton.Enabled = false;
                    if (witchDay == 0)
                    {
                        MenuTop4ToolStripMenuItem.Enabled = todaySMS = false;
                        MenuTop1ToolStripMenuItem.Enabled = todayagainConnect = false;
                        MenuTop3ToolStripMenuItem.Enabled = todaytelephon = true;
                        MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry = false;
                    }
                    if (witchDay == 1)
                    {
                        MenuTop4ToolStripMenuItem.Enabled = tomarowSMS = false;
                        MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect = false;
                        MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon = true;
                        MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry = false;
                    }
                }}
                if (steps == 2)
                {
                    if (witchDay == 0)
                    {
                        todaySMS = false;
                    }
                    if (witchDay == 1)
                    {
                        tomarowSMS = false;

                    }
                    SendSMSButton.Enabled = SMSDataGridView.Enabled = false;
                    SMSDataGridView.BackgroundColor = Color.LightGray;


                    if (witchDay == 0)
                    {
                        MenuTop4ToolStripMenuItem.Enabled = todaySMS = false;
                        MenuTop1ToolStripMenuItem.Enabled = todayagainConnect = true;
                        MenuTop3ToolStripMenuItem.Enabled = todaytelephon = false;
                        MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry = false;
                    }
                    if (witchDay == 1)
                    {
                        MenuTop4ToolStripMenuItem.Enabled = tomarowSMS = false;
                        MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect = true;
                        MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon = false;
                        MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry = false;
                    }
                }
                if (steps == 3)
                {
                    //againConnect = false;
                    if (witchDay == 0)
                    {
                        todayagainConnect = false;
                    }
                    if (witchDay == 1)
                    {
                        tomarowagainConnect = false;

                    }

                    SendSMSButton.Enabled = SMSDataGridView.Enabled = false;
                    SMSDataGridView.BackgroundColor = Color.LightGray;


                    if (witchDay == 0)
                    {
                        MenuTop4ToolStripMenuItem.Enabled = todaySMS = false;
                        MenuTop1ToolStripMenuItem.Enabled = todayagainConnect = false;
                        MenuTop3ToolStripMenuItem.Enabled = todaytelephon = false;
                        MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry = true;
                    }
                    if (witchDay == 1)
                    {
                        MenuTop4ToolStripMenuItem.Enabled = tomarowSMS = false;
                        MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect = false;
                        MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon = false;
                        MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry = true;
                    }


                    //SMS = false;
                    //againConnect = false;
                    //telephon = false;
                    //finalyTry = true;

                }
                if (steps == 4)
                {

                    if (witchDay == 0)
                    {
                        todayfinalyTry = false;
                    }
                    if (witchDay == 1)
                    {
                        tomarowfinalyTry = false;

                    }
                    //finalyTry = false;
                    SendSMSButton.Enabled = SMSDataGridView.Enabled = false;
                    SMSDataGridView.BackgroundColor = Color.LightGray;
                    string eventlog = "Decisive Rest OF Intermittences In Step 4 ";
                    
                        for (int i = 0; i < SMSDataGridView.Rows.Count; i++)
                        {
                            try
                           {
                            int result1 = 0;
                            result1 = da.UpdateIntermittence("SetDecisiveIntermittence", Convert.ToInt32(((DataRow)SMSDataGridView.Rows[i].Tag)["ID"]), true);
                          }
                          catch 
                              {
                            NewMethod_eventlog(eventlog + (((DataRow)SMSDataGridView.Rows[i].Tag)["ID"]).ToString(), 15002);
                             throw;
                             }  
                        }
                   
                    GridSet();
                    FillGrid();
                    GridSetTel();

                    if (witchDay == 0)
                    {
                        MenuTop4ToolStripMenuItem.Enabled = todaySMS = false;
                        MenuTop1ToolStripMenuItem.Enabled = todayagainConnect = false;
                        MenuTop3ToolStripMenuItem.Enabled = todaytelephon = false;
                        MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry = false;
                    }
                    if (witchDay == 1)
                    {
                        MenuTop4ToolStripMenuItem.Enabled = tomarowSMS = false;
                        MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect = false;
                        MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon = false;
                        MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry = false;
                    }


                    //SMS = false;
                    //againConnect = false;
                    //telephon = false;
                    //finalyTry = false;

                }
            }
      

        private int SendSMS()//تابع ارسال پیامک
        {
            string eventlog = "Sending SMS For Today OR Tomarow" ;
                string IDs = "";
                foreach (DataRow dr in smsDt.Rows)
                    IDs += ',' + dr["ID"].ToString();

                int result = da.Insert("SetSmsInfo", IDs);
            try
            {
                if (result > 1)
                // MessageBox.Show("sms Sent");
                {
                    DeliveredSmsProgressBar1.Maximum = smsDt.Rows.Count;
                    SendSMSColorProgressBar.Maximum = smsDt.Rows.Count;
                    SendSMSColorProgressBar.Value = 0;// smsDt.Rows.Count;
                    timer1.Enabled = !timer1.Enabled;

                    timer1.Start();
                    SendSMSButton.Enabled = SMSDataGridView.Enabled = false;
                    SMSDataGridView.BackgroundColor = Color.LightGray;
                    if (witchDay == 0)
                    {
                        todaySMS = false;
                    }
                    if (witchDay == 1)
                    {
                        tomarowSMS = false;

                    }
                    // SMS = false;
                }
                else if (result == -2)
                {
                    var msg = "در روند ارسال خطایی رخ داده"; MessageForm.Show(msg, "اخطار", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    //  MessageBox.Show("در روند ارسال خطایی رخ داده");
                }

            }
            catch (Exception e1)
            {

                NewMethod_eventlog(eventlog, 15001);
                throw;
            }
        return result; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Counter == 10 * 60 * 1000)
            {
                timer1.Enabled = false;
                return;
            }
            else
            {
                Counter++;
                DeliveredSmsProgressBar1.Maximum = smsDt.Rows.Count;
                SendSMSColorProgressBar.Maximum = smsDt.Rows.Count;

                CheckSentSms();
            }
              
            
           
        }
     
        private void CheckSentSms()
        {
            string eventlog = "CheckSentSms";
            try
            {
                int rowcount;
                if (tomarowtelephon == true || tomarowtelephon == true)
                {
                    rowcount = smsDt.Rows.Count;


                }
                else
                    rowcount = 0;

                DeliveredSmsProgressBar1.Maximum = rowcount;
                SendSMSColorProgressBar.Maximum = rowcount;
                DataSet ds = da.ExecuteCommand("GetSentSmsCount");
                if (Convert.ToInt32(ds.Tables[1].Rows[0][0]) >= DeliveredSmsProgressBar1.Minimum && Convert.ToInt32(ds.Tables[1].Rows[0][0]) <= DeliveredSmsProgressBar1.Maximum)
                    DeliveredSmsProgressBar1.Value = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                //  Application.DoEvents();
                if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) >= SendSMSColorProgressBar.Minimum && Convert.ToInt32(ds.Tables[0].Rows[0][0]) <= SendSMSColorProgressBar.Maximum)
                    SendSMSColorProgressBar.Value = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                // Application.DoEvents();
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15006);
                throw;
            }
        }
        #region PatientInfo
        public class Patient// اینفوی اطلاعات بیمار
        {
            public string nationalID;// کد ملی
            public string name;// نام و نام خانوادگی
            public byte index;// اندیس
            public byte status;// وضعیت فالس = نوبت غیر قطعی است و ترو= نوبت قطعی
            public PersianDate date;// تاریخ نوبت بیمار
            public int departmentID;//  آی دی بخشی که بیمار نوبت گرفته  
            public Patient()
            { }
            public Patient(string nationalID, byte index, string name, byte status, PersianDate date, int departmentID)
            {
                this.nationalID = nationalID;
                this.index = index;
                this.name = name;
                this.status = status;
                this.date = date;
                this.departmentID = DepartmentID;

            }
            public Patient(byte index, string name, byte status)
            {

                this.index = index;
                this.name = name;
                this.status = status;

            }

            public string NationalID
            {
                get { return nationalID; }
                set { nationalID = value; }
            }

            public byte Index
            {
                get { return index; }
                set { index = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public byte Status
            {
                get { return status; }
                set { status = value; }
            }
            public PersianDate Date
            {
                get { return date; }
                set { date = value; }
            }
            public int DepartmentID
            {
                get { return departmentID; }
                set { departmentID = value; }
            }

        }
        #endregion
        private void gridMesbah1_CellClickAdd(object sender, GridMesbahCellEventArgs e)//  ADD
        {
            //(sender as CellGrid).
            // انتقال شماره ملی وشماره تماس بیمار به فرم ثبت پرونده
            string nationalityCode =( gridMesbah2.Rows[e.RowIndex - 1].Cells[e.CellIndex - 1].Id).ToString();
            string TELOrMobile= gridMesbah2.Rows[e.RowIndex - 1].Cells[e.CellIndex - 1].CustomerNumber.ToString();
            if (nationalityCode.Length == 9)
                nationalityCode = "0" + nationalityCode;
            if (nationalityCode.Length == 8)
                nationalityCode = "00" + nationalityCode;

            Document document = new Document(nationalityCode, TELOrMobile);

            document.Load += delegate
            {
                document.Location = new Point(MousePosition.X-500, MousePosition.Y);
            };
            document.ShowDialog();
            GridSet();// رفرش کردن گرید کارتابل منشی پس از ثبت یا آپدیت اطلاعات بیمار
            FillGrid();
        }
        #region GridSet
        private void GridSet()
        {

        }

        private void GridSetTel()// تنظیم ستون گرید قطعی کردن
        {
            //SMSDataGridView.DataSource = null;
            dt = new DataTable();

            dt.Columns.Add(ID.Name);//شناسه
            dt.Columns.Add(TimeCol.Name);// تاریخ نوبت
            dt.Columns.Add(CustomerCol.Name);// کد ملی بیمار
            dt.Columns.Add(NumberCol.Name);// شماره تماس
            dt.Columns.Add(StateCol.Name);// وضعیت 0= غیر قطعی 1= قطعی
            dt.Columns.Add(SectionCol.Name);// بخش
            dt.Columns.Add(CancelCol.Name);
            SMSDataGridView.DataSource = dt;
        }


        #endregion

       
        #region FillGrid
        private void FillGrid()// پر کردن گرید کارتابل منشی
        {

            DataSet PatientCalanderDS = new DataSet();
            string eventlog = "Get All Decisived Intermittences by departmentID=  " + DepartmentID + " and Day= " + witchDay;
            try
            {
                PatientCalanderDS = da.ExecuteCommand("GetCalendar", DepartmentID, witchDay);// گرفتن داده نوبت های مربوط به روز  و بخش انتخاب شده 
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15003);
                throw;
            }
            
            patientList = new List<Patient>();
            dt = new DataTable();
            gridMesbah2.DataSource = null;
            List<DataMesbah> lst = new List<DataMesbah>();
              string eventlog1 = "Fill DataMesbahList for katrable Grid" ;
              try
              {
                  foreach (DataRow Row in PatientCalanderDS.Tables[0].Rows)
                  {
                      string TelORMobile = "";
                      string id = "0";
                      if (Row["NationalityCode"] != null)
                          id =((Row["NationalityCode"])).ToString();

                      if (Row["Telphone"].ToString().Length > 11 && Row["Telphone"].ToString().Substring(0, 2) == "98")
                          TelORMobile = "0" + Row["Telphone"].ToString().Substring(2).Trim();
                      else TelORMobile = Row["Telphone"].ToString();
                      lst.Add(new DataMesbah { CustomerName = Row["Fname"].ToString() + " " + Row["Lname"].ToString(), CustomerNumber = TelORMobile, Id = id, Time = ((System.DateTime)Row["Date"]).Hour.ToString() });// + ":" + ((System.DateTime)Row["Date"]).Minute.ToString()).ToString() });

                  }
              }
              catch
              {
                  NewMethod_eventlog(eventlog1, 15004);
                  throw;
              }
           gridMesbah2.DataSource = lst;
           setcolor();//colorBox1_ColorChange(color);// ست کردن تنظیمات دیزاین پس از پرکردن گرید
           backColor = color;
           
        }

        #endregion


        private void gridMesbah1_CellClickAttach(object sender, GridMesbahCellEventArgs e)// دکمه پیوست گرید کارتابل = پیوست فایل برای بیمار
        {
            //var msg = "Attach= RowIndex:" + e.RowIndex.ToString() + " CellIndex:" + e.CellIndex.ToString() + " Id:" + (sender as CellGrid).Id.ToString();
            //MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, color);
        
        }

        private void gridMesbah1_CellClickDelete(object sender, GridMesbahCellEventArgs e)// دکمه حذف گرید کارتابل = لغو نوبت 
        {
            
         //  (sender as CellGrid).ContentColor = Color.Red;
            //var msg = "Delete= RowIndex:" + e.RowIndex.ToString() + " CellIndex:" + e.CellIndex.ToString() + " Id:" + (sender as CellGrid).Id.ToString();
            //MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, color);

            var msg = "لغو نوبت بیمار تایید شد."; MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, color);
       
            gridMesbah2.Rows[e.RowIndex-1].Cells[e.CellIndex-1].BackColor = Color.Red;
           
        }

        private void gridMesbah1_CellClickForward(object sender, GridMesbahCellEventArgs e)// دکمه فوروارد گرید کارتابل =ورود بیمار به مطب
        {
            //(sender as CellGrid).ContentColor= Color.Gray;
            //var msg = "Forward= RowIndex:" + e.RowIndex.ToString() + " CellIndex:" + e.CellIndex.ToString() + " Id:" + (sender as CellGrid).Id.ToString();
            //MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, color);
            gridMesbah2.Rows[e.RowIndex - 1].Cells[e.CellIndex - 1].BackColor = Color.Gray;
            var msg = "ویزیت بیمار تایید شد."; MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, color);
       
        }

        private void SMSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // با کلیک روی چک باکس وضعیت گرید قطعی کردن حالت غیر قطعی به قطعی تبدیل شده و سبز می شود 
            //if (SMSDataGridView.CurrentRow != null && SMSDataGridView.CurrentRow.Cells["StateCol"].Value != DBNull.Value && !Convert.ToBoolean(SMSDataGridView.CurrentRow.Cells["StateCol"].Value))
            //    SMSDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;

        }

        private void SMSDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // با کلیک روی چک باکس وضعیت گرید قطعی کردن حالت غیر قطعی به قطعی تبدیل شده و سبز می شود 

            if (e.ColumnIndex ==4 && !(Convert.ToBoolean(SMSDataGridView.CurrentCell.Value)))// اگر روی ستون وضعیت و مقدار قبلی فالس کلیک کرد بتواند آن را به مقدار ترو تغییر مقدار دهد
            {
                int result1 = 0;
                string eventlog = "Checked status by click on  decisive Grid for IntermittenceID= " +(DataRow)SMSDataGridView.CurrentRow.Tag!= null?(((DataRow)SMSDataGridView.CurrentRow.Tag)["ID"]).ToString():"0";
                try { SMSDataGridView.CurrentCell.Value = true; result1 = da.UpdateIntermittence("SetDecisiveIntermittence", Convert.ToInt32(((DataRow)SMSDataGridView.CurrentRow.Tag)["ID"]), true); }
                catch
                {
                    NewMethod_eventlog(eventlog, 15005);
                    throw;
                }
                int i = SMSDataGridView.CurrentRow.Index;
                SMSDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;
                SMSDataGridView.CurrentRow.ReadOnly = true;
                FillGrid();// پرکردن گرید کارتابل 
                
            }
              if (e.ColumnIndex ==6 && !(Convert.ToBoolean(SMSDataGridView.CurrentCell.Value)))// اگر روی ستون وضعیت و مقدار قبلی فالس کلیک کرد بتواند آن را به مقدار ترو تغییر مقدار دهد
              {
                  int result1 = 0;
                  SqlParameter[] param;
                  param = new SqlParameter[1];
                  int index = 0;
                  string eventlog = "Cancel status by click on  Canceled  Grid for IntermittenceID= " + (DataRow)SMSDataGridView.CurrentRow.Tag != null ? (((DataRow)SMSDataGridView.CurrentRow.Tag)["ID"]).ToString() : "0";

                  try { SMSDataGridView.CurrentCell.Value = true;
                  param[index++] = new SqlParameter("@IntermittenceID", Convert.ToInt32(((DataRow)SMSDataGridView.CurrentRow.Tag)["ID"]));
                  result1 = Convert.ToInt16(da.ExecuteScalarSP("SetCanceledInfo", param));
                  }
                  catch
                  {
                      NewMethod_eventlog(eventlog, 15015);
                      throw;
                  }
                  int i = SMSDataGridView.CurrentRow.Index;
                  SMSDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.LightPink;
                 SMSDataGridView.CurrentRow.ReadOnly = true;
                  FillGrid();// پرکردن گرید کارتابل 
                  
              }
               
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {


            //if (gridMesbah1.Rows.Count == 0) return;حذف یک سطر
            //gridMesbah1.Rows.Remove(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorKartable dk = new DoctorKartable();
            dk.ShowDialog();
            //gridMesbah1.Rows.Add();اضافه کردن یک سطر
            //gridMesbah1.Rows[gridMesbah1.Rows.Count - 1].Time = "07:50";
            //gridMesbah1.DataSource = lst; پرکردن تقویم
            //colorBox1_ColorChange(color);//این خط برای حفظ استایل هست که در نسخه ی بعدی یرطرف گشته و نیازی نیست
       }

        private void button3_Click(object sender, EventArgs e)//  تنظیمات
        {
            if ((Application.OpenForms["Setting"] as Setting) != null)
            {
                //Form is already open
            }
            else
            {
                Form set = new Setting();// نمایش فرم تنظیمات
                set.ShowDialog();
                // Form is not open
            }
        
        }
        private void Lock()
        {
            string serial;
            USBSerialNumber usb = new USBSerialNumber();
                 if (usb.getSerialNumberFromDriveLetter("a:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("a:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }
            else if (usb.getSerialNumberFromDriveLetter("b:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("b:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }
            else if (usb.getSerialNumberFromDriveLetter("c:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("c:") == "A110000000028845")
                         return;
                     else 
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }
            else if (usb.getSerialNumberFromDriveLetter("d:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("d:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }
            else if (usb.getSerialNumberFromDriveLetter("e:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("e:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("f:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("f:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("g:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("g:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("h:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("h:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("i:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("i:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("j:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("j:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("k:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("k:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("l:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("l:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("m:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("m:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

            else if (usb.getSerialNumberFromDriveLetter("n:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("n:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }

                 else if (usb.getSerialNumberFromDriveLetter("o:") != null)
                 {
                     if (usb.getSerialNumberFromDriveLetter("o:") == "A110000000028845")
                         return;
                     else
                     {
                         var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                         this.Close();
                         System.Environment.Exit(1);
                     }
                 }
                 else {
                     var msg = "لطفا قفل را وارد کنید."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);

                     //this.Close();
                     //System.Environment.Exit(1);
                   
                    }
        }
        private bool TestConnection()
        {
            if (System.IO.File.Exists(PATH))
            {


                try
                {
                    using (SqlConnection con = new SqlConnection(da.GetConnectionString()))
                    {

                        SqlCommand command = new SqlCommand();
                        con.Open(); con.Close();
                         return true;

                       
                    }

                }
                catch
                {
                    return false;

                }
            }
            else return false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            Lock();
            this.Hide();
            ConnectionString logon = new ConnectionString();

            if (TestConnection())
                this.Show();
            else   if (  logon.ShowDialog() != DialogResult.OK)
            {
                this.Show();
            }
            WindowState = FormWindowState.Maximized;

            lblDate.Text = string.Format(  "{0}",  FarsiDateHelper.GetLongFarsiDate(DateTime.Now) ) ;
            DeliveredSmsProgressBar1.Maximum = smsDt.Rows.Count;
            SendSMSColorProgressBar.Maximum = smsDt.Rows.Count;
            CheckSentSms();
            //Application.DoEvents();
           
            const double interval60minutes = 60 * 60 * 1000;
            //System.Windows.Forms.Timer checkForTime = new System.Threading.Timer(interval60minutes);
            //checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
            //checkForTime.Elapsed = true;
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         
            sectionDS = da.ExecuteCommand("GetActiveDep");
            FillMenu();//پر کردن منو بخش ها 
            DepartmentID = Convert.ToInt16(menuStrip1.Items[0].Tag);// تنظیم اولین بخش به عنوان بخش پیش فرض
            //menuStrip1.Items[0].Click += new EventHandler(MenuItemClickHandler);
            // MenuItem1ToolStripMenuItem.CheckState = CheckState.Checked;
            //columnCount = da.GetColumnCount("GetColumnCount");
            string eventlog = "GetSentSmsCountForToday";

            try
            {
                if (da.GetColumnCount("GetSentSmsCountForToday") > 0)
                {
                    todaytelephon = true;
                    todaySMS = false;
                }
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15009);
                throw;
            }
            btnDay_Click(null, null);//پیش فرض نوبت های امروز نمایش داده شوند
            //FillGrid();
            this.ActiveControl = SMSDataGridView;// پیش فرض گرید اس ام اس فعال باشد
            bool isTodayOrTodayAndTomarrow = false;// و 1= امروز 0= فردا و امروز
            string eventlog1 = "GetTodayORTodayTomatow";

             try
             {

                 isTodayOrTodayAndTomarrow = da.GetIsTodayORTodatTomarow("GetTodayORTodayTomatow");
                 if (isTodayOrTodayAndTomarrow == false)
                 {
                     btnTomarow.Visible = true;
                 }
                 else
                     btnTomarow.Visible = false;
             }
             catch {
                 NewMethod_eventlog(eventlog1, 15010);
                throw;
             }
             lblDate.ForeColor = ControlPaint.Dark(color);
             lblDate.BackColor = ControlPaint.LightLight(ControlPaint.LightLight((color)));
            lblDate1.ForeColor =ControlPaint.Dark( color);
            lblDate1.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color)));
        }

        private void setcolor()
        {
            color = Properties.Settings.Default.Color;
            TopPanelWithBorder.BorderColor = color;
            BottomPanelWithBorder.BorderColor = color;
            RightPanelWithBorder.BorderColor = color;
            MenuRightPanelWithBorder.BorderColor = color;
            SendSMSPanelWithBorder.BorderColor = color;
            ColorCheckBox.BackColor = color; 
            if (menuActiveRight != null)
            menuActiveRight.BackColor = color;
            menuActiveTop.BackColor = color; button4.BackColor = color;
            SendSMSButton.BackColor = color;
            SMSDataGridView.ColumnHeadersDefaultCellStyle.BackColor = color;
            SMSDataGridView.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            SMSDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            button1.BackColor = color;
            button2.BackColor = color;
            button3.BackColor = color;
            //btnToday.BackColor = Color.c;
            //btnTomarow.BackColor = color;
            //button4.BackColor = color;
            //button5.BackColor = color;
            //button6.BackColor = color;
            gridMesbah2.RowsBorderColor = color;
            gridMesbah2.CellsBorderColor = ControlPaint.Dark(color);
            gridMesbah2.CellsForColor = ControlPaint.DarkDark(color);
            gridMesbah2.CellsButtonColor = color;
            SendSMSColorProgressBar.BarColor = ControlPaint.LightLight(color);
        }

      
        private void btnDay_Click(object sender, EventArgs e)//  امروز
        {
            lblDate1.Text = "";
            lblDate1.Text = string.Format("{0}", FarsiDateHelper.GetLongFarsiDate(DateTime.Now));
            
            btnToday.BackColor = color; btnTomarow.BackColor =System.Drawing.Color.FromName("Control");
            btnToday.ForeColor = Color.White;
            btnTomarow.ForeColor = Color.Black;
              witchDay = 0;
            MenuTop4ToolStripMenuItem.Checked= MenuTop4ToolStripMenuItem.Enabled= todaySMS;
            MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled=todaytelephon;
            MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = todayagainConnect;
            MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled=todayfinalyTry;
          
            if(todaySMS)
           MenuTop4ToolStripMenuItem_Click(null, null);
          
            if(todaytelephon)
                MenuTop3ToolStripMenuItem_Click(null, null);
      
            if(todayagainConnect)
                MenuTop1ToolStripMenuItem_Click(null, null);
        
            if (todayfinalyTry)
                MenuTop2ToolStripMenuItem_Click(null, null);

          FillGrid();
       
          
        }

        private void button7_Click(object sender, EventArgs e)//  فردا
        {
            lblDate1.Text = "";
            lblDate1.Text = string.Format("{0}", FarsiDateHelper.GetLongFarsiDate(DateTime.Now.AddDays(1)));
            
            btnToday.BackColor = System.Drawing.Color.FromName("Control");  btnTomarow.BackColor = color;

            btnTomarow.ForeColor = Color.White;
            btnToday.ForeColor = Color.Black;
           
             witchDay = 1;
              MenuTop4ToolStripMenuItem.Checked = tomarowSMS; MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled = tomarowSMS;
              MenuTop3ToolStripMenuItem.Checked = tomarowtelephon; MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon;
              MenuTop1ToolStripMenuItem.Checked =tomarowagainConnect; MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect;
              MenuTop2ToolStripMenuItem.Checked =tomarowfinalyTry; MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry;

            if ( tomarowSMS)// اگر تب پیامک کلیک شده 
                 MenuTop4ToolStripMenuItem_Click(null, null);
            if ( tomarowtelephon)// اگر تب تلفن ثابت کلیک شده 
                 MenuTop3ToolStripMenuItem_Click(null, null);
            if ( tomarowagainConnect)// اگر تب ارتباط دوباره کلیک شده
                 MenuTop1ToolStripMenuItem_Click(null, null);
             if (tomarowfinalyTry)// اگر تب قطعی کردن نهایی کلیک شده
                 MenuTop2ToolStripMenuItem_Click(null, null);

         FillGrid();// پر کردن گرید کارتابل منشی
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckSentSms();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SMSDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SMSDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4 && !(Convert.ToBoolean(SMSDataGridView.CurrentCell.Value)))
            //{
               
            //}
        }

        private void MenuItem1ToolStripMenuItem_MouseEnter_1(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;//دیزاین
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DepartmentID = Convert.ToInt16(e.ClickedItem.Tag);// get the ID of Clicked Tab
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            string eventlog = "Get Department info by DepartmentID=" + DepartmentID;
            try
            {
                if (DepartmentSelected != null)
                    if (DepartmentSelected != DepartmentID)
                    {
                        param[index++] = new SqlParameter("@DepartementId", DepartmentID);
                        DepartementInfo = da.ExecuteCommand("GetDepartementInfo", DepartmentID);// get Clicke Department Information From DB
                        if (DepartementInfo.Tables[0].Rows.Count > 0)
                        {
                            //startime = DepartementInfo.Tables[0].Rows[0]["StartTime"].ToString() != "" ? Convert.ToInt16(DepartementInfo.Tables[0].Rows[0]["StartTime"].ToString()) : 0;
                            //endtime = DepartementInfo.Tables[0].Rows[0]["EndTime"].ToString() != "" ? Convert.ToInt16(DepartementInfo.Tables[0].Rows[0]["EndTime"].ToString()) : 0;
                        }

                        FillGrid();// Fill Secretary Kartable Grid


                        DepartmentSelected = DepartmentID;//save selected Depertment ID as A Public Variable
                    }
                SelectMenuRight(e.ClickedItem);
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15008);
                throw;
            }

        }

        private void gridMesbah2_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void colorBox1_Load(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuRightPanelWithBorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RightPanelWithBorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SendSMSPanelWithBorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSmsProgress_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void colorProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void SendSMSColorProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void DeliveredSmsProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BottomPanelWithBorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void TopPanelWithBorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDate1_Click(object sender, EventArgs e)
        {

        } 
   
    }
}
