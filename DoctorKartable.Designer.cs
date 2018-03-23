namespace ClinicMesbah
{
    partial class DoctorKartable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorKartable));
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdDocuments = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RightPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.grdIntermittenc = new System.Windows.Forms.DataGridView();
            this.CustomerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDIntermittence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendSMSPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).BeginInit();
            this.RightPanelWithBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntermittenc)).BeginInit();
            this.SendSMSPanelWithBorder.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.miniToolStrip.Location = new System.Drawing.Point(111, 2);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.miniToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.miniToolStrip.Size = new System.Drawing.Size(330, 26);
            this.miniToolStrip.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.tabControl1);
            this.panel5.Controls.Add(this.grdDocuments);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.RightPanelWithBorder);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1231, 733);
            this.panel5.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.tabControl1.Location = new System.Drawing.Point(341, 411);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 319);
            this.tabControl1.TabIndex = 25;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "1";
            this.tabPage1.Text = "دارو";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FloralWhite;
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "2";
            this.tabPage2.Text = "آزمایش";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Azure;
            this.tabPage3.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage3.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(772, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "3";
            this.tabPage3.Text = "سایر";
            // 
            // grdDocuments
            // 
            this.grdDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdDocuments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdDocuments.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocuments.ColumnHeadersVisible = false;
            this.grdDocuments.Location = new System.Drawing.Point(342, 12);
            this.grdDocuments.MultiSelect = false;
            this.grdDocuments.Name = "grdDocuments";
            this.grdDocuments.RowHeadersVisible = false;
            this.grdDocuments.Size = new System.Drawing.Size(881, 396);
            this.grdDocuments.TabIndex = 24;
            this.grdDocuments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocuments_CellClick);
            this.grdDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocuments_CellContentClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1124, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 38);
            this.button2.TabIndex = 21;
            this.button2.Text = "بیمار بعدی";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1124, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 38);
            this.button1.TabIndex = 20;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RightPanelWithBorder
            // 
            this.RightPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.RightPanelWithBorder.BorderSize = 1;
            this.RightPanelWithBorder.Controls.Add(this.grdIntermittenc);
            this.RightPanelWithBorder.Controls.Add(this.SendSMSPanelWithBorder);
            this.RightPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.RightPanelWithBorder.Location = new System.Drawing.Point(1, 0);
            this.RightPanelWithBorder.Name = "RightPanelWithBorder";
            this.RightPanelWithBorder.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.RightPanelWithBorder.Size = new System.Drawing.Size(331, 733);
            this.RightPanelWithBorder.TabIndex = 19;
            // 
            // grdIntermittenc
            // 
            this.grdIntermittenc.AllowUserToAddRows = false;
            this.grdIntermittenc.AllowUserToDeleteRows = false;
            this.grdIntermittenc.AllowUserToResizeColumns = false;
            this.grdIntermittenc.AllowUserToResizeRows = false;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdIntermittenc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            this.grdIntermittenc.BackgroundColor = System.Drawing.Color.White;
            this.grdIntermittenc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdIntermittenc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdIntermittenc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("B Nazanin", 12.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdIntermittenc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.grdIntermittenc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIntermittenc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerCol,
            this.IDIntermittence,
            this.CodeCol});
            this.grdIntermittenc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIntermittenc.EnableHeadersVisualStyles = false;
            this.grdIntermittenc.Location = new System.Drawing.Point(1, 77);
            this.grdIntermittenc.Name = "grdIntermittenc";
            this.grdIntermittenc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdIntermittenc.RowHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.grdIntermittenc.RowHeadersVisible = false;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("B Nazanin", 12.25F);
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black;
            this.grdIntermittenc.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.grdIntermittenc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIntermittenc.Size = new System.Drawing.Size(330, 656);
            this.grdIntermittenc.TabIndex = 4;
            this.grdIntermittenc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdIntermittenc_CellClick);
            this.grdIntermittenc.SelectionChanged += new System.EventHandler(this.grdIntermittenc_SelectionChanged);
            // 
            // CustomerCol
            // 
            this.CustomerCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CustomerCol.DataPropertyName = "CustomerCol";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CustomerCol.DefaultCellStyle = dataGridViewCellStyle28;
            this.CustomerCol.HeaderText = " بیمار";
            this.CustomerCol.MinimumWidth = 10;
            this.CustomerCol.Name = "CustomerCol";
            this.CustomerCol.ReadOnly = true;
            this.CustomerCol.Width = 210;
            // 
            // IDIntermittence
            // 
            this.IDIntermittence.DataPropertyName = "IDIntermittence";
            this.IDIntermittence.FillWeight = 5F;
            this.IDIntermittence.HeaderText = "IDIntermittence";
            this.IDIntermittence.Name = "IDIntermittence";
            this.IDIntermittence.Visible = false;
            this.IDIntermittence.Width = 5;
            // 
            // CodeCol
            // 
            this.CodeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodeCol.DataPropertyName = "CodeCol";
            this.CodeCol.HeaderText = "کد ملی";
            this.CodeCol.MinimumWidth = 40;
            this.CodeCol.Name = "CodeCol";
            this.CodeCol.ReadOnly = true;
            this.CodeCol.Width = 120;
            // 
            // SendSMSPanelWithBorder
            // 
            this.SendSMSPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.SendSMSPanelWithBorder.BorderSize = 1;
            this.SendSMSPanelWithBorder.Controls.Add(this.panel2);
            this.SendSMSPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.SendSMSPanelWithBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.SendSMSPanelWithBorder.Location = new System.Drawing.Point(1, 0);
            this.SendSMSPanelWithBorder.Name = "SendSMSPanelWithBorder";
            this.SendSMSPanelWithBorder.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.SendSMSPanelWithBorder.Size = new System.Drawing.Size(330, 77);
            this.SendSMSPanelWithBorder.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("B Nazanin", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox1.Location = new System.Drawing.Point(30, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 36);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(330, 76);
            this.panel2.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(282, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 36);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // DoctorKartable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 733);
            this.Controls.Add(this.panel5);
            this.Name = "DoctorKartable";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "پنل پزشک";
            this.Load += new System.EventHandler(this.DoctorKartable_Load);
            this.panel5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).EndInit();
            this.RightPanelWithBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIntermittenc)).EndInit();
            this.SendSMSPanelWithBorder.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Timer timer1;
        private MesbahComponent.PanelWithBorder RightPanelWithBorder;
        private MesbahComponent.PanelWithBorder SendSMSPanelWithBorder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grdDocuments;
        private System.Windows.Forms.DataGridView grdIntermittenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDIntermittence;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeCol;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        //private System.Windows.Forms.PictureBox pictureBox1;

    }
}