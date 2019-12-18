namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabpage_plotXYZ = new System.Windows.Forms.TabPage();
            this.chart_plotXYZ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpage_fanuc = new System.Windows.Forms.TabPage();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3_receivedata = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3_savaTodb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5_plotbuffer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6_v = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButton_connSensor = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_port = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_baudrate = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_databit = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_databit = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_stopbit = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_stopbit = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_parity = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_disconnSensor = new System.Windows.Forms.ToolStripButton();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabpage_plotXYZ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_plotXYZ)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabpage_fanuc.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabpage_plotXYZ
            // 
            this.tabpage_plotXYZ.BackColor = System.Drawing.Color.White;
            this.tabpage_plotXYZ.Controls.Add(this.chart_plotXYZ);
            this.tabpage_plotXYZ.Location = new System.Drawing.Point(4, 26);
            this.tabpage_plotXYZ.Margin = new System.Windows.Forms.Padding(0);
            this.tabpage_plotXYZ.Name = "tabpage_plotXYZ";
            this.tabpage_plotXYZ.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_plotXYZ.Size = new System.Drawing.Size(1147, 532);
            this.tabpage_plotXYZ.TabIndex = 1;
            this.tabpage_plotXYZ.Text = "PLOTXYZ";
            // 
            // chart_plotXYZ
            // 
            this.chart_plotXYZ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_plotXYZ.BackColor = System.Drawing.Color.Transparent;
            this.chart_plotXYZ.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart_plotXYZ.IsSoftShadows = false;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart_plotXYZ.Legends.Add(legend1);
            this.chart_plotXYZ.Location = new System.Drawing.Point(0, 0);
            this.chart_plotXYZ.Margin = new System.Windows.Forms.Padding(0);
            this.chart_plotXYZ.Name = "chart_plotXYZ";
            this.chart_plotXYZ.Size = new System.Drawing.Size(1147, 532);
            this.chart_plotXYZ.TabIndex = 8;
            this.chart_plotXYZ.Text = "chart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabpage_plotXYZ);
            this.tabControl1.Controls.Add(this.tabpage_fanuc);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tabControl1.ItemSize = new System.Drawing.Size(76, 22);
            this.tabControl1.Location = new System.Drawing.Point(9, 59);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1155, 562);
            this.tabControl1.TabIndex = 9;
            // 
            // tabpage_fanuc
            // 
            this.tabpage_fanuc.BackColor = System.Drawing.Color.White;
            this.tabpage_fanuc.Controls.Add(this.textBox_log);
            this.tabpage_fanuc.Location = new System.Drawing.Point(4, 26);
            this.tabpage_fanuc.Margin = new System.Windows.Forms.Padding(0);
            this.tabpage_fanuc.Name = "tabpage_fanuc";
            this.tabpage_fanuc.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_fanuc.Size = new System.Drawing.Size(1147, 532);
            this.tabpage_fanuc.TabIndex = 2;
            this.tabpage_fanuc.Text = "FANUC";
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(220, 19);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log.Size = new System.Drawing.Size(455, 407);
            this.textBox_log.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.另存为ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.另存为ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.数据库ToolStripMenuItem.Text = "数据库";
            this.数据库ToolStripMenuItem.Click += new System.EventHandler(this.数据库ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_time,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2_time,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3_receivedata,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel3_savaTodb,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5_plotbuffer,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6_v,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_time
            // 
            this.toolStripStatusLabel_time.Name = "toolStripStatusLabel_time";
            this.toolStripStatusLabel_time.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "时间：";
            // 
            // toolStripStatusLabel2_time
            // 
            this.toolStripStatusLabel2_time.Name = "toolStripStatusLabel2_time";
            this.toolStripStatusLabel2_time.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2_time.Text = "00:00:00";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel2.Text = "接收数据：";
            // 
            // toolStripStatusLabel3_receivedata
            // 
            this.toolStripStatusLabel3_receivedata.Name = "toolStripStatusLabel3_receivedata";
            this.toolStripStatusLabel3_receivedata.Size = new System.Drawing.Size(15, 17);
            this.toolStripStatusLabel3_receivedata.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel3.Text = "写入表格：";
            // 
            // toolStripStatusLabel3_savaTodb
            // 
            this.toolStripStatusLabel3_savaTodb.Name = "toolStripStatusLabel3_savaTodb";
            this.toolStripStatusLabel3_savaTodb.Size = new System.Drawing.Size(15, 17);
            this.toolStripStatusLabel3_savaTodb.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel4.Text = "待显示数据：";
            // 
            // toolStripStatusLabel5_plotbuffer
            // 
            this.toolStripStatusLabel5_plotbuffer.Name = "toolStripStatusLabel5_plotbuffer";
            this.toolStripStatusLabel5_plotbuffer.Size = new System.Drawing.Size(15, 17);
            this.toolStripStatusLabel5_plotbuffer.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel5.Text = "速率：";
            // 
            // toolStripStatusLabel6_v
            // 
            this.toolStripStatusLabel6_v.Name = "toolStripStatusLabel6_v";
            this.toolStripStatusLabel6_v.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel6_v.Text = "0 Bytes/s";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Margin = new System.Windows.Forms.Padding(100, 3, 0, 2);
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel6.Text = "hhhhhhhhhhhhhhhh";
            // 
            // toolStripButton_connSensor
            // 
            this.toolStripButton_connSensor.BackColor = System.Drawing.Color.Red;
            this.toolStripButton_connSensor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_connSensor.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton_connSensor.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_connSensor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_connSensor.Image")));
            this.toolStripButton_connSensor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_connSensor.Name = "toolStripButton_connSensor";
            this.toolStripButton_connSensor.Size = new System.Drawing.Size(86, 22);
            this.toolStripButton_connSensor.Text = "连接传感器";
            this.toolStripButton_connSensor.Click += new System.EventHandler(this.toolStripButton_connSensor_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox_port,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripComboBox_baudrate,
            this.toolStripSeparator2,
            this.toolStripLabel_databit,
            this.toolStripComboBox_databit,
            this.toolStripSeparator3,
            this.toolStripLabel_stopbit,
            this.toolStripComboBox_stopbit,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.toolStripComboBox_parity,
            this.toolStripSeparator5,
            this.toolStripButton_connSensor,
            this.toolStripSeparator7,
            this.toolStripLabel_disconnSensor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "Port";
            // 
            // toolStripComboBox_port
            // 
            this.toolStripComboBox_port.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox_port.Name = "toolStripComboBox_port";
            this.toolStripComboBox_port.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Red;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel2.Text = "BaudRate";
            // 
            // toolStripComboBox_baudrate
            // 
            this.toolStripComboBox_baudrate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox_baudrate.Name = "toolStripComboBox_baudrate";
            this.toolStripComboBox_baudrate.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_databit
            // 
            this.toolStripLabel_databit.Name = "toolStripLabel_databit";
            this.toolStripLabel_databit.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel_databit.Text = "DataBit";
            // 
            // toolStripComboBox_databit
            // 
            this.toolStripComboBox_databit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox_databit.Name = "toolStripComboBox_databit";
            this.toolStripComboBox_databit.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_stopbit
            // 
            this.toolStripLabel_stopbit.Name = "toolStripLabel_stopbit";
            this.toolStripLabel_stopbit.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel_stopbit.Text = "StopBit";
            // 
            // toolStripComboBox_stopbit
            // 
            this.toolStripComboBox_stopbit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox_stopbit.Name = "toolStripComboBox_stopbit";
            this.toolStripComboBox_stopbit.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel3.Text = "Parity";
            // 
            // toolStripComboBox_parity
            // 
            this.toolStripComboBox_parity.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox_parity.Name = "toolStripComboBox_parity";
            this.toolStripComboBox_parity.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_disconnSensor
            // 
            this.toolStripLabel_disconnSensor.BackColor = System.Drawing.Color.Red;
            this.toolStripLabel_disconnSensor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel_disconnSensor.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel_disconnSensor.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel_disconnSensor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel_disconnSensor.Image")));
            this.toolStripLabel_disconnSensor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel_disconnSensor.Name = "toolStripLabel_disconnSensor";
            this.toolStripLabel_disconnSensor.Size = new System.Drawing.Size(116, 22);
            this.toolStripLabel_disconnSensor.Text = "关闭传感器连接";
            this.toolStripLabel_disconnSensor.Click += new System.EventHandler(this.toolStripLabel_disconnectSensor_Click);
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel7.Text = "gjghjgghjghjgh ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1184, 662);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabpage_plotXYZ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_plotXYZ)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabpage_fanuc.ResumeLayout(false);
            this.tabpage_fanuc.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabpage_plotXYZ;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpage_fanuc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_plotXYZ;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_time;
        private System.Windows.Forms.ToolStripButton toolStripButton_connSensor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_port;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_baudrate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_databit;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_databit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_stopbit;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_stopbit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_parity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2_time;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3_receivedata;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3_savaTodb;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5_plotbuffer;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripLabel_disconnSensor;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6_v;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
    }
}

