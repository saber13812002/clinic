using MesbahComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using USBDriveSerialNumber;

namespace ClinicMesbah
{
    public partial class DoctorKartable : Form
    {
        public DoctorKartable()
        {
            InitializeComponent();
            tabControl1.TabPages[0].Controls.Add(pictureBox1);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
        }
        #region Variables
        private PictureBox pictureBox1 = new PictureBox();
        bool draw = false;
        private string PATH = Application.StartupPath + @"\setting.xml";
        private Point? _Previous = null;
        private DataTable DoctDT = new DataTable();
        private DataTable DocumentDT = new DataTable();
        SolidBrush myBrush = new SolidBrush(Color.Black);
        int pX = -1;
        int pY = -1;
        private bool  clear=false;
        private Bitmap drawing;
        private DataAccess da = new DataAccess();
        private DataTable dt = new DataTable();
        private DataTable dtDoc = new DataTable();
        private DataTable smsDt = new DataTable();
        private string  Id;
        private Color color;
        public DataSet GridDataSourceDS;
        private bool IntOrChar;
        #endregion
        private void DoctorKartable_Load(object sender, EventArgs e)
        {  
            Lock();
            this.Hide();
            ConnectionString logon = new ConnectionString();

            if (TestConnection())
                this.Show();
            else if (logon.ShowDialog() != DialogResult.OK)
            {
                this.Show();
            }
            WindowState = FormWindowState.Maximized;
            setLook();
            GridSet();
            GridDataSourceDS = da.ExecuteCommand("GetTodayIntermittences");
            FillGrid(GridDataSourceDS.Tables[0]);
            GridDocumentsSet();
            SetColor();
            grdIntermittenc_CellClick(null, null);
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
        private void Lock()
        {
            string serial = "A110000000028845";
            USBSerialNumber usb = new USBSerialNumber();
            if (usb.getSerialNumberFromDriveLetter("a:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("a:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("b:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("c:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("d:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("e:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("f:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("g:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("h:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("i:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("j:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("k:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("l:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("m:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("n:") == serial)
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
                if (usb.getSerialNumberFromDriveLetter("o:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else
            {
                var msg = "لطفا قفل را وارد کنید."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);

                //this.Close();
                //System.Environment.Exit(1);

            }
        }
        private void SetColor()
        {
            color = Properties.Settings.Default.Color;
            SendSMSPanelWithBorder.BorderColor = color;
            button1.BackColor = color;
            button2.BackColor = color;
            //grdDocuments.ColumnHeadersDefaultCellStyle.BackColor = color;
            //grdDocuments.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            //grdDocuments.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            grdIntermittenc.ColumnHeadersDefaultCellStyle.BackColor = color;
            grdIntermittenc.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            grdIntermittenc.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            
        }
        private void setLook()
        {
            pictureBox1.Size=tabPage1.Size;
    
            
            drawing = new Bitmap(pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
            tabControl1.TabPages[0].Controls.Add(pictureBox1);
            WindowState = FormWindowState.Maximized;
             color = Properties.Settings.Default.Color;
           // grdDocuments.BackgroundColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
             pictureBox1.Enabled = false;

        
        }

        private void GridSet()// 
        {
            //grdIntermittenc.DataSource = null;
            dt = new DataTable();

            dt.Columns.Add(IDIntermittence.Name);//شناسه
            dt.Columns.Add(CodeCol.Name);// تاریخ نوبت
            dt.Columns.Add(CustomerCol.Name);// کد ملی بیمار
            grdIntermittenc.DataSource = dt;

        }

        private void GridDocumentsSet()// 
        {
            grdDocuments.DataSource = null;
            dtDoc = new DataTable();

            DataGridViewTextBoxColumn IDImage = new DataGridViewTextBoxColumn();
            IDImage.Name = "ID";
            IDImage.HeaderText = "ID";
          //  dtDoc.Columns.Add(IDImage.Name);
            IDImage.DataPropertyName = "ID";
            IDImage.Visible = false;
            IDImage.Width = 5;

            DataGridViewTextBoxColumn DocumentType = new DataGridViewTextBoxColumn();
            DocumentType.Name = "DocumentType";
            DocumentType.HeaderText = "DocumentType";
            //dtDoc.Columns.Add(DocumentType.Name);
            DocumentType.Visible = false;
            DocumentType.Width = 5;
            DocumentType.DataPropertyName = "DocumentType";

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "image";
            //imgColumn.HeaderText = "image";
            imgColumn.DataPropertyName = "image";
            imgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            imgColumn.MinimumWidth = 500;
            imgColumn.Width = 700;

            //DataGridViewButtonColumn ReportErrorColumn = new DataGridViewButtonColumn();
            //ReportErrorColumn.Name = "ReportError";
            //ReportErrorColumn.HeaderText = "ReportError";
            //ReportErrorColumn.DataPropertyName = "ReportError";
            //ReportErrorColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //ReportErrorColumn.MinimumWidth =100;
            //ReportErrorColumn.Width = 100;
            //grdDocuments.Columns.Add(ReportErrorColumn);
            //ReportErrorColumn.UseColumnTextForButtonValue = true;


            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.HeaderText = "SelectData";
            //cmb.Name = "SelectData";
            //cmb.MaxDropDownItems = 4;
            //cmb.Items.Add("True");
            //cmb.Items.Add("False");
            //grdDocuments.Columns.Add(cmb);


            grdDocuments.DataSource = dtDoc;


        }


        private void FillGrid(DataTable GridDataSourceDS
            )
        {
           
            smsDt.Rows.Clear();
            if (grdIntermittenc.Rows.Count > 0)
                grdIntermittenc.Rows.Clear();
            if (grdIntermittenc.DataSource != null)
                smsDt = (DataTable)grdIntermittenc.DataSource;// پاک کردن داده های قبلی گرید

            foreach (DataRow row in GridDataSourceDS.Rows)
            {

                    DataRow dr = smsDt.Rows.Add();
                    dr["IDIntermittence"] = (row["ID"]);
                    dr["CodeCol"] = row["NationalityCode"];
                    dr["CustomerCol"] = row["Name"];
                    Int32 index = grdIntermittenc.Rows.Count - 1;
                    grdIntermittenc.Rows[index].Tag = row;
                

            }
            grdIntermittenc.DataSource = smsDt;

            grdIntermittenc.Columns["IDIntermittence"].Visible = false;// در هر حالتی ستون آی دی نمایش داده نشود
           this.grdIntermittenc.Columns["CustomerCol"].DefaultCellStyle.Alignment = this.grdIntermittenc.Columns["CodeCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
               //     grdIntermittenc.Rows[0].DefaultCellStyle.BackColor = Color.LightGreen;
            
          
        }
        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();

        }
        private void FillDocumentsGrid()
        {
            Id = (grdIntermittenc.CurrentRow.Cells[1].Value).ToString();
            if (Id == "0")
            { Id = (grdIntermittenc.Rows[0].Cells[1].Value).ToString(); }
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            param[index++] = new SqlParameter("@NationalityCode", Id);
          
            DocumentDT = da.ExecuteSP("GetDocumentInfo", param).Tables[0];
                DoctDT.Rows.Clear();
            if (grdDocuments.Rows.Count > 0)
                grdDocuments.DataSource=null;
            if (grdDocuments.DataSource != null)
                DoctDT = (DataTable)grdDocuments.DataSource;// پاک کردن داده های قبلی گرید

            foreach (DataRow row in DocumentDT.Rows)
            {


                    DataRow dr = DoctDT.Rows.Add();
                  //dr["ID"] =Convert.ToInt32 (row["ID"]);
                  //dr["image"] = row["image"];
                 //MemoryStream ms = new MemoryStream(ObjectToByteArray(row["image"]));
                //    Image returnImage = Image.FromStream(ms);
                    Bitmap bmp;
                    using (var ms = new MemoryStream(ObjectToByteArray(row["image"])))
                    {
                       // bmp = new Bitmap(ms);
                    }
                   //_ dr["ImageCol"] = GetString(ObjectToByteArray(row["image"]));// (Bitmap)((new ImageConverter()).ConvertFrom(row["image"]));  //returnImage;//
                  //  dr["ImageCol"] = Convert.ToString(row["image"]);// (Bitmap)((new ImageConverter()).ConvertFrom(row["image"]));  //returnImage;//
                   
                    //Int32 index = grdDocuments.Rows.Count - 1;
                    //grdDocuments.Rows[index].Tag = row;
                    //grdDocuments.Rows[0].Cells["ImageCol"].Value = (Bitmap)((new ImageConverter()).ConvertFrom(row["image"]));

            }
            if (DocumentDT.Rows.Count > 0)
            {
                grdDocuments.DataSource = DocumentDT;
                //grdDocuments.Columns[0].Visible = false;

                grdDocuments.Columns["ID"].Visible = false;
                grdDocuments.Columns["DocumentType"].Visible = false;
                grdDocuments.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.grdDocuments.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                grdDocuments.FirstDisplayedScrollingRowIndex = grdDocuments.RowCount - 1;
            }
        }
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length-1);
            return new string(chars);
        }
        
        private void grdIntermittenc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            pictureBox1.Enabled = true;

            if (pictureBox1.Image != null)
            {
             
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate();
            
             Byte[] imageData = new Byte[0]; 
            FillDocumentsGrid();
            if (DocumentDT.Rows.Count > 0)
            {
             

              imageData = (Byte[])(DocumentDT.Rows[DocumentDT.Rows.Count-1]["image"]);
              short documentType = Convert.ToInt16(DocumentDT.Rows[DocumentDT.Rows.Count - 1]["DocumentType"]);
                switch (documentType)
                { case 1: 
                        tabControl1.SelectedIndex=documentType-1;
                        break;
                case 2:
                        tabControl1.SelectedIndex = documentType - 1;
                        break;
                case 3:
                        tabControl1.SelectedIndex = documentType - 1;
                        break;
                }
              if (imageData != null)
              {
                  MemoryStream stream = new MemoryStream(imageData);
                 pictureBox1.Image = Image.FromStream(stream);
              }
              clear = false;
              return;
             }
          else
          {

              pictureBox1.Invalidate();
              tabControl1.SelectedIndex = 0;
          }
        }
       
        
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics panel = Graphics.FromImage(drawing);
                Pen pen = new Pen(Color.Black,1);
                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.Round;
                panel.DrawLine(pen, pX, pY, e.X, e.Y);
                pictureBox1.CreateGraphics().DrawImageUnscaled(drawing, new Point(0, 0));
            }

            pX = e.X;
            pY = e.Y;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            pX = e.X;
            pY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (clear == false)
                e.Graphics.DrawImageUnscaled(drawing, new Point(0, 0));
            
            //}
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
         }
        private void Insert()
        {
            int width = pictureBox1.Size.Width;
            int height = pictureBox1.Size.Height;

            using (Bitmap bmp = new Bitmap(width, height))
            {
                pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));

                ImageConverter converter = new ImageConverter();
                SqlParameter[] param;
                param = new SqlParameter[4];
                int index = 0;

                //  param[index++] = new SqlParameter("@ID", Id);
                param[index++] = new SqlParameter("@Image", (byte[])converter.ConvertTo(bmp, typeof(byte[])));
                param[index++] = new SqlParameter("@NationalityCode", Id);
                param[index++] = new SqlParameter("@DateModified", DateTime.Now);
                param[index++]= new SqlParameter ("@DocumentType",tabControl1.SelectedTab.Tag);
                if (Convert.ToInt32(da.ExecuteScalarSP("SetPrescription", param)) == 1)
                {
                    var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    //  MessageBox.Show("ثبت با موفقیت انجام شد."); 
                    FillDocumentsGrid();
                    //cmbDayOfWeek.Enabled = false; cmbShift.Enabled = false;
                }
                else
                {
                    var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                    //  MessageBox.Show("در روند ثبت خطایی رخ داده است.");
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = new Point(e.X, e.Y);
            pictureBox1_MouseMove(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Pen _Pen = new Pen(myBrush, 2);
            _Pen.EndCap = LineCap.Round;
            _Pen.StartCap = LineCap.Round;

            if (_Previous != null)
            {
                if (pictureBox1.Image == null)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(pictureBox1.BackColor);
                    }
                    pictureBox1.Image = bmp;
                }
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.DrawLine(_Pen, _Previous.Value.X, _Previous.Value.Y, e.X, e.Y);
                }
                pictureBox1.Invalidate();
                _Previous = new Point(e.X, e.Y);
            }
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insert();
            if (pictureBox1.Image != null)
            {

                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {


            int currentRow =
            grdIntermittenc.CurrentRow.Index;
        //    grdIntermittenc.Rows[currentRow ].Selected = false;
            if (-1 < currentRow + 1 && currentRow + 1 < grdIntermittenc.Rows.Count)
            {
                grdIntermittenc.CurrentCell = grdIntermittenc.Rows[currentRow + 1].Cells[1];
                grdIntermittenc.Rows[currentRow + 1].Selected = true;
                grdIntermittenc_CellClick(null, null);
            }
        }

        private void grdDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
            }
        }

        private void grdIntermittenc_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridView dv = (DataGridView)sender;
            //grdIntermittenc_CellClick(dv, new DataGridViewCellEventArgs(dv.CurrentCell.ColumnIndex, dv.CurrentCell.RowIndex));
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Controls.SetChildIndex(pictureBox1, 0);

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.TabPage.Controls.Add(pictureBox1);
            e.TabPage.Controls.SetChildIndex(pictureBox1, 0);
            pictureBox1.BackColor= e.TabPage.BackColor;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void grdDocuments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 )
               
            {
 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {    
            //DataTable dtSearch = new DataTable(); 
            //dtSearch = GridDataSourceDS.Tables[0];
            //DataTable dtSearched = new DataTable();
            //if (!(textBox1.Text.Trim() == "" || textBox1.Text == string.Empty) )
            //{
            //    DataRow[] resultss1 = dtSearch.AsEnumerable().Where(row => row.Field<string>("NationalityCode").Contains(textBox1.Text.Trim())).Select(row => row).ToArray<DataRow>();
               
            //    //dtSearched = dtSearch.Select("Name like '" + textBox1.Text.Trim() + "%'"+"OR NationalityCode LIKE '" + textBox1.Text.Trim() + "%'"
            //    //     ).CopyToDataTable();

              
                
            //}
            //else
            //{ FillGrid(GridDataSourceDS.Tables[0]); }
            DataTable dtSearch = new DataTable();
            dtSearch = GridDataSourceDS.Tables[0].Copy();
            DataTable dtSearched = new DataTable();

            if (!(textBox1.Text.Trim() == "" || textBox1.Text == string.Empty))
            {
                if (IntOrChar)
                {
                    DataRow[] resultss = dtSearch.AsEnumerable().Where(row => row.Field<string>("NationalityCode").Contains(textBox1.Text.Trim())).Select(row => row).ToArray<DataRow>();
                    dtSearched = dtSearch.Copy();
                    dtSearched.Rows.Clear();

                    foreach (DataRow row in resultss)
                    {
                        dtSearched.ImportRow(row);
                    }
                    FillGrid(dtSearched);
                }
                else
                {
                    DataRow[] resultss = dtSearch.AsEnumerable().Where(row => row.Field<string>("Name").Contains(textBox1.Text.Trim())).Select(row => row).ToArray<DataRow>();
                    dtSearched = dtSearch.Copy();
                    dtSearched.Rows.Clear();

                    foreach (DataRow row in resultss)
                    { 
                        dtSearched.ImportRow(row); }
                    FillGrid(dtSearched);
                }
 
            }
            else
            { FillGrid(GridDataSourceDS.Tables[0]); }     }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                IntOrChar = true;
            }
            else { IntOrChar = false; }
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
           
           
        }
    }
}
