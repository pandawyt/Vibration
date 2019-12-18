using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using System.Text.RegularExpressions;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using System.IO.Ports;
using static WindowsFormsApp1.Form1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // 数据库设置
        private string URL;                                                         // 数据库地址
        private string DATABASE;                                                    // 数据库名称
        private string COLLECTION;                                                  // 类似数据库中的一个表
        private MongoClient client;                                                 //
        private Thread thread_SaveDataToDB;                                         // 存数据库线程
        private List<BsonDocument> documentList = new List<BsonDocument>();         // 缓存将要存入数据库的数据
        private List<string> COLLECTION_NAMES = new List<string>();
        private const int MAX_INSERT = 1000;                                        // 每次存储到数据库的数据量
        private const int MAX_COLLECTION = 1000000;                                 // 一个collection最大的容量，超过则新建一个
        private int COLLECTION_INDEX = 1;                                           // collection名称自增
        private int COLLECTION_ALL = 0;                                             // 已存储到一个collection总量
        private long INSERT_ALL = 0;                                                // 已存储到数据库总量
        private long RECEIVE_ALL = 0;                                               // 已接收数据总量
        private bool is_DBthread_running = false;                                   // 存数据库线程状态

        private System.Timers.Timer timer_plot;                     // 定时更新图
        private System.Timers.Timer timer_time;                     // 状态栏显示时间
        private const int INTERVAL = 100;                           // timer_plot时间间隔（毫秒）
        private const int MAX_PLOT = 1000;                          // 图上的点数，按时间间隔INTERVALl每次从PLOT_DOT_BUFFER取数据
        private List<string> PLOT_DOT_BUFFER = new List<string>();  // 需要画的点，该buffer存储需要画的数据，始终保持一定数量的数据，方便画图
        private bool has_connSensor = false;                        // 表明是否已经连上传感器 

        private ChartArea areaX = new ChartArea() { Name = "LineX" };
        private Series seriesX = new Series();
        private ChartArea areaY = new ChartArea() { Name = "LineY" };
        private Series seriesY = new Series();
        private ChartArea areaZ = new ChartArea() { Name = "LineZ" };
        private Series seriesZ = new Series();
        private DataTable dt = new DataTable();

        private static SerialPort port;
        private static List<byte> Receive_Buffer = new List<byte>(8192);        // 接收缓冲区的内容 
        private static byte[] Receive_Bytes;                                    // 将Receive_Buffer 拷贝到里面
        private static List<byte> Data_Buff1 = new List<byte>(8192);            // 将Receive_Bytes Add到里面
        private static List<byte> Data_Buff2 = new List<byte>(8192);            // 将Data_Buff1 拷贝到里面
        private static byte[] DataTemp;
        private static int len_of_frame = 0;

        private Thread thread_SaveDataToCSV;                        // 存CSV线程
        private List<string> CSV_LIST = new List<string>();         // 缓存将要存入CSV的数据
        private int CSV_INDEX = 1;                                  // csv后缀名
        private int CSV_MAX = 1000000;                               // 单个csv最大行数，超过则新建
        private int CSV_LINE = 0;                                   // 单个csv行数
        private long CSV_ALL_LINE = 0;                              // csv总行数
        private int day1 = DateTime.Today.Day;                      // 当跨过一天后，CSV_INDEX 从1开始重新增加
        private int day2 = DateTime.Today.Day;
        private bool is_CSVthread_running = false;

        private StreamWriter stream;
        private long seconds = 0;
        private bool has_reveived = false;                          // 表面已经接收到数据

        public delegate void UpdateUI();        // 用于修改主线程UI
        public delegate void Log<in T>(T t);    // 用于调试时显示信息


        public Form1()
        {
            InitializeComponent();
            InitializeDataTable();
            InitializeChart();
            InitializeToolStripeItems();
        }


        public void log(string s)
        {
            toolStripStatusLabel6.Text = s;
        }

        #region 自定义函数
        //
        // 显示调试信息
        //
        public void infor(string s)
        {
            MessageBox.Show(s, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //
        // 判断是否跨天数
        //
        public bool DayChange()
        {
            day2 = DateTime.Today.Day;
            if (day2 != day1)                // 第二天了
            {
                return true;
            }
            return false;
        }
        //
        // 显示时间
        //
        public void InitializeTime()
        {
            timer_time = new System.Timers.Timer();
            timer_time.AutoReset = true;
            timer_time.Enabled = true;
            timer_time.Elapsed += Timer_time_Elapsed;
            timer_time.Interval = 1000;
        }
        private void Timer_time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateUI change = new UpdateUI(UpdateTime);
            Invoke(change);
        }
        public void UpdateTime()
        {
            if (port != null && port.IsOpen)
            {
                seconds++;
            }
            toolStripStatusLabel2_time.Text = DateTime.Now.ToString();
            toolStripStatusLabel3_receivedata.Text = RECEIVE_ALL.ToString();
            if(GlobalParameter.USE_DB)
            {
                toolStripStatusLabel3.Text = "写入数据库：";
                toolStripStatusLabel3_savaTodb.Text = INSERT_ALL.ToString();
            }
            else
            {
                toolStripStatusLabel3.Text = "写入表格：";
                toolStripStatusLabel3_savaTodb.Text = CSV_ALL_LINE.ToString();
            }
            toolStripStatusLabel5_plotbuffer.Text = PLOT_DOT_BUFFER.Count.ToString();
            toolStripStatusLabel6_v.Text = (RECEIVE_ALL / seconds).ToString() + " Byte/s";
        }
        #endregion


        #region 初始化toolstripeitems
        public void InitializeToolStripeItems()
        {
            // 串口
            for (int i = 1; i <= 15; i++)
            {
                toolStripComboBox_port.Items.Add("COM" + i.ToString());
            }
            toolStripComboBox_port.SelectedIndex = 2;
            // 数据位
            for (int i = 5; i <= 8; i++)
            {
                toolStripComboBox_databit.Items.Add(i);
            }
            toolStripComboBox_databit.SelectedIndex = 3;
            //波特率
            toolStripComboBox_baudrate.Items.Add("1200");
            toolStripComboBox_baudrate.Items.Add("2400");
            toolStripComboBox_baudrate.Items.Add("4800");
            toolStripComboBox_baudrate.Items.Add("9600");
            toolStripComboBox_baudrate.Items.Add("19200");
            toolStripComboBox_baudrate.Items.Add("38400");
            toolStripComboBox_baudrate.Items.Add("43000");
            toolStripComboBox_baudrate.Items.Add("56000");
            toolStripComboBox_baudrate.Items.Add("57600");
            toolStripComboBox_baudrate.Items.Add("115200");
            toolStripComboBox_baudrate.Items.Add("128000");
            toolStripComboBox_baudrate.Items.Add("230400");
            toolStripComboBox_baudrate.Items.Add("460800");
            toolStripComboBox_baudrate.Items.Add("512000");
            toolStripComboBox_baudrate.Items.Add("600000");
            toolStripComboBox_baudrate.Items.Add("750000");
            toolStripComboBox_baudrate.Items.Add("921600");
            toolStripComboBox_baudrate.Items.Add("1228800");
            toolStripComboBox_baudrate.Items.Add("2147483647");//the max baudrate of PC serial
            toolStripComboBox_baudrate.SelectedIndex = 16;
            // 奇偶校验位
            toolStripComboBox_parity.Items.Add("无");
            toolStripComboBox_parity.Items.Add("奇校验");
            toolStripComboBox_parity.Items.Add("偶校验");
            toolStripComboBox_parity.SelectedIndex = 0;
            // 停止位
            toolStripComboBox_stopbit.Items.Add("0");
            toolStripComboBox_stopbit.Items.Add("1");
            toolStripComboBox_stopbit.Items.Add("1.5");
            toolStripComboBox_stopbit.Items.Add("2");
            toolStripComboBox_stopbit.SelectedIndex = 1;
        }
        #endregion


        #region 初始化chart DataTable
        public void InitializeDataTable()
        {
            DataColumn col_time = new DataColumn("time", typeof(string));
            DataColumn col_X = new DataColumn("X", typeof(int));
            DataColumn col_Y = new DataColumn("Y", typeof(int));
            DataColumn col_Z = new DataColumn("Z", typeof(int));
            dt.Columns.Add(col_time);
            dt.Columns.Add(col_X);
            dt.Columns.Add(col_Y);
            dt.Columns.Add(col_Z);
        }
        public void InitializeChart()
        {
            //chart_plotXYZ.DataSource = dt;
            // ChartAreas
            chart_plotXYZ.ChartAreas.Add(areaX);
            chart_plotXYZ.ChartAreas.Add(areaY);
            chart_plotXYZ.ChartAreas.Add(areaZ);

            chart_plotXYZ.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chart_plotXYZ.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;

            for (int i = 0; i < 3; i++)
            {
                chart_plotXYZ.ChartAreas[i].AxisX.Enabled = AxisEnabled.True;
                chart_plotXYZ.ChartAreas[i].AxisY.Enabled = AxisEnabled.True;
                chart_plotXYZ.ChartAreas[i].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chart_plotXYZ.ChartAreas[i].AxisY.Title = ((char)(i + 88)).ToString() + "Axis";
                chart_plotXYZ.ChartAreas[i].AxisX.Title = "time";
                chart_plotXYZ.ChartAreas[i].AxisX.MajorGrid.Enabled = false;                      //X轴上网格
                chart_plotXYZ.ChartAreas[i].AxisY.MajorGrid.Enabled = false;                      //y轴上网格
                chart_plotXYZ.ChartAreas[i].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;  //网格类型 短横线
                chart_plotXYZ.ChartAreas[i].AxisX.MajorGrid.LineColor = Color.Gray;
                chart_plotXYZ.ChartAreas[i].AxisX.MajorTickMark.Enabled = true;                  // x轴上突出的小点
                chart_plotXYZ.ChartAreas[i].AxisY.MajorTickMark.Enabled = true;
                //chart_plotXYZ.ChartAreas[i].AxisY.IsInterlaced = true;                            //显示交错带
                chart_plotXYZ.ChartAreas[i].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;  //网格类型 短横线
                chart_plotXYZ.ChartAreas[i].BackColor = System.Drawing.Color.Transparent;           //设置区域内背景透明
            }
            // Series                              
            seriesX.ChartArea = "LineX";
            seriesY.ChartArea = "LineY";
            seriesZ.ChartArea = "LineZ";
            chart_plotXYZ.Series.Add(seriesX);
            chart_plotXYZ.Series.Add(seriesY);
            chart_plotXYZ.Series.Add(seriesZ);
            for (int i = 0; i < 3; i++)
            {
                chart_plotXYZ.Series[i].ChartType = SeriesChartType.FastLine;
                chart_plotXYZ.Series[i].Name = ((char)(i + 88)).ToString() + "Axis";
            }
        }
        #endregion


        #region 画图
        //
        // 定时器更新 画图
        //
        public void InitializePlotTimer()
        {
            timer_plot = new System.Timers.Timer();
            timer_plot.AutoReset = true;
            timer_plot.Enabled = true;
            timer_plot.Elapsed += new System.Timers.ElapsedEventHandler(PlotXYZDelegate);
            timer_plot.Interval = INTERVAL;
        }
        public void PlotXYZDelegate(object source, System.Timers.ElapsedEventArgs e)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            timer_plot.Enabled = false; // 一定要设置，防止当前程序没跑完，就到时间跑下一个了
            UpdateUI change = new UpdateUI(PlotXYZByChart);
            Invoke(change); 
            timer_plot.Enabled = true;
            //sw.Stop();
            //Log<string> l = new Log<string>(log);
            //Invoke(l, sw.ElapsedMilliseconds.ToString());
        }
        public void PlotXYZByChart()
        {
            if (PLOT_DOT_BUFFER.Count >= MAX_PLOT)
            {
                var documents = PLOT_DOT_BUFFER.GetRange(0, MAX_PLOT);
                PLOT_DOT_BUFFER.RemoveRange(0, MAX_PLOT);
                foreach (var document in documents)
                {
                    string doc = document.ToString();
                    try
                    {
                        string time = doc.Split(' ')[0];
                        int X = Convert.ToInt32(doc.Split(' ')[1]);
                        int Y = Convert.ToInt32(doc.Split(' ')[2]);
                        int Z = Convert.ToInt32(doc.Split(' ')[3]);
                        DataRow dr = dt.NewRow();
                        dr["time"] = time;
                        dr["X"] = X;
                        dr["Y"] = Y;
                        dr["Z"] = Z;
                        dt.Rows.Add(dr);
                        if (seriesX.Points.Count >= MAX_PLOT)
                        {
                            seriesX.Points.Clear();
                            seriesY.Points.Clear();
                            seriesZ.Points.Clear();
                        }
                        if (dt.Rows.Count >= MAX_PLOT)
                        {
                            seriesX.Points.DataBind(dt.AsEnumerable(), "time", "X", "");
                            seriesY.Points.DataBind(dt.AsEnumerable(), "time", "Y", "");
                            seriesZ.Points.DataBind(dt.AsEnumerable(), "time", "Z", "");
                            dt.Rows.Clear();
                        }
                    }
                    catch (Exception)
                    {
                        infor(doc);
                        continue;
                    }
                }
            }
        }
        #endregion


        #region 点击事件
        //
        // 点击另存为
        //
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择到文件夹";
            dialog.ShowNewFolderButton = true;
            if (dialog.ShowDialog() == DialogResult.OK)     // 移动文件到选定的文件夹
            {
                foreach(var name in COLLECTION_NAMES)
                {
                    string save_path = dialog.SelectedPath + "\\" + name + ".csv";
                    string cmd = string.Format(@"mongoexport -d {0} -c {1} -f time,X,Y,Z --type=csv -o {2}",
                                                DATABASE, name, save_path);
                    LaunchCommandLine(cmd);
                }
                COLLECTION_NAMES.Clear();
            }
        }
        public void LaunchCommandLine(string cmd)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.Arguments = cmd;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;            //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;       //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;      //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;       //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;              //不显示程序窗口 
                p.Start();                                      //启动程序    
                p.StandardInput.WriteLine(cmd + "&exit");
                p.StandardInput.AutoFlush = true;
                p.WaitForExit();                                //等待程序执行完退出进程
                p.Close();
            }
            catch
            {
                infor("保存文件异常");
            }
        }
        //
        // 关闭form1事件
        //
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close(); //只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，另外若有托管线程（非主线程），也无法干净地退出；
            //Application.Exit(); //强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出； 
            //Application.ExitThread(); //强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题；
            //System.Environment.Exit(0); //这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。 
            DialogResult result;
            result = MessageBox.Show("关闭窗口", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        //
        // 点击连接传感器
        //
        private void toolStripButton_connSensor_Click(object sender, EventArgs e)
        {
            if(GlobalParameter.USE_DB && !GlobalParameter.HAS_CONNDB)
            {
                infor("请先连接数据库！");
                return;
            }
            if (has_connSensor)        // 防止多次点击连接传感器
            {
                infor("传感器已连接");
                return;
            }
            else
            {
                ConnectSensor();
                toolStripButton_connSensor.Text = "正在连接......";
                while (!has_reveived) ;                                         // 等待连接成功，成功标志是接收到数据
                if (has_connSensor)
                {
                    toolStripButton_connSensor.BackColor = Color.Green;
                    toolStripButton_connSensor.Text = "传感器连接成功";
                    if (GlobalParameter.USE_DB && GlobalParameter.HAS_CONNDB)
                    {
                        URL = GlobalParameter.URL;
                        DATABASE = GlobalParameter.DATEBASE;
                        COLLECTION = GlobalParameter.COLLECTION;
                        if (is_DBthread_running == false)
                        {
                            InitializeTime();
                            SaveDataToDB();             // 使用数据库，则只保存到数据库
                            is_DBthread_running = true;
                        }
                    }
                    else
                    {
                        if(is_CSVthread_running == false)
                        {
                            InitializeTime();
                            SaveDataToCSV();            // 不使用数据库，则只保存到本地csv
                            is_CSVthread_running = true;
                        }
                    }
                    InitializePlotTimer();
                }
            }
        }
        // 
        // 点击关闭传感器连接
        //
        private void toolStripLabel_disconnectSensor_Click(object sender, EventArgs e)
        {
            if(port == null || !port.IsOpen)
            {
                infor("传感器未连接");
                return;
            }
            if (port.IsOpen)
            {
                port.Close();
                has_connSensor = false;
                toolStripButton_connSensor.Text = "连接传感器";
                toolStripButton_connSensor.BackColor = Color.Red;
            }
        }
        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBconfigForm form = new DBconfigForm();
            form.Show();
        }
        #endregion


        #region 存数据库
        //
        // 保存数据到数据库
        //
        public void SaveDataToDB()
        {
            thread_SaveDataToDB = new Thread(() => {
                client = new MongoClient(URL);
                var database = client.GetDatabase(DATABASE);
                COLLECTION = COLLECTION + "-" + COLLECTION_INDEX.ToString();
                var collection = database.GetCollection<BsonDocument>(COLLECTION);
                COLLECTION_NAMES.Add(COLLECTION);
                while (true)
                {
                    int cnt = documentList.Count;
                    if (cnt >= MAX_INSERT)
                    {
                        collection.InsertMany(documentList.GetRange(0, MAX_INSERT));
                        lock (documentList)
                        {
                            documentList.RemoveRange(0, MAX_INSERT);
                        }
                        INSERT_ALL += MAX_INSERT;
                        COLLECTION_ALL += MAX_INSERT;
                        // 一个collection存了足够多的数据，则新建一个collection
                        if (COLLECTION_ALL >= MAX_COLLECTION)
                        {
                            COLLECTION_ALL = 0;
                            COLLECTION_INDEX++;
                            COLLECTION = GlobalParameter.COLLECTION + "-" + COLLECTION_INDEX.ToString();
                            COLLECTION_NAMES.Add(COLLECTION);
                            collection = database.GetCollection<BsonDocument>(COLLECTION);
                        }
                        if(DayChange())
                        {
                            COLLECTION = DateTime.Now.ToString(@"\Yyyyy\MMM\Ddd");
                            COLLECTION_INDEX = 1;
                        }
                    }
                    Thread.Sleep(50);
                }
            });
            thread_SaveDataToDB.Start();
        }
        #endregion


        #region 存CSV
        public void SaveDataToCSV()
        {
            thread_SaveDataToCSV = new Thread(() =>
            {
                //string current_path = System.IO.Directory.GetCurrentDirectory();
                string current_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                if (System.IO.Directory.Exists(current_path + @"\data") == false)
                {
                    System.IO.Directory.CreateDirectory(current_path + @"\data");
                }
                while(true)
                {
                    int cnt = 1000;
                    if(CSV_LIST.Count > cnt)       // 避免频繁写入
                    {
                        string csv_name = DateTime.Today.ToString("yyyy-MM-dd-") + CSV_INDEX + ".csv";
                        string csv_path = current_path + @"\data\" + csv_name;
                        for (int i = 0; i < cnt; i++)    // 写入cnt条
                        {
                            StringBuilder column = new StringBuilder();
                            StringBuilder row = new StringBuilder();
                            column.Append("time,XAxis,YAxis,ZAxis");
                            var time = CSV_LIST[i].Split(' ')[0];
                            var XAxis = CSV_LIST[i].Split(' ')[1];
                            var YAxis = CSV_LIST[i].Split(' ')[2];
                            var ZAxis = CSV_LIST[i].Split(' ')[3];
                            row.Append(time + "," + XAxis + "," + YAxis + "," + ZAxis);
                            // 第一次写
                            if(System.IO.File.Exists(csv_path) == false)
                            {
                                stream = new StreamWriter(csv_path, false, Encoding.UTF8);     // 不追加写
                                stream.WriteLine(column);
                                stream.WriteLine(row);
                                stream.Flush();
                                stream.Close();
                                stream.Dispose();
                                stream = null;
                            }
                            else
                            {
                                if (stream == null)
                                {
                                    stream = new StreamWriter(csv_path, true, Encoding.UTF8);      // 追加写
                                }
                                stream.WriteLine(row);
                                //stream.Close();
                                //stream.Dispose();
                                //stream = null;
                            }
                            CSV_LINE++;
                            CSV_ALL_LINE++;
                        }
                        stream.Flush();
                        stream.Close();
                        stream.Dispose();
                        stream = null;
                        lock(CSV_LIST)
                        {
                            CSV_LIST.RemoveRange(0, cnt);
                        }
                        if (CSV_LINE >= CSV_MAX)     // 超过单个csv最大行数
                        {
                            CSV_LINE = 0;           // 行数清零
                            CSV_INDEX++;            // 后缀名加一
                        }
                        if(DayChange())
                        {
                            CSV_INDEX = 1;
                        }
                    }
                }
            });
            thread_SaveDataToCSV.Start();
        }
        #endregion


        #region 串口操作
        public void ConnectSensor()
        {
            port = new SerialPort
            {
                PortName = toolStripComboBox_port.SelectedItem.ToString(),
                BaudRate = Convert.ToInt32(toolStripComboBox_baudrate.SelectedItem.ToString()),
                DataBits = Convert.ToInt32(toolStripComboBox_databit.SelectedItem.ToString()),
                ReceivedBytesThreshold = 1,
                Handshake = Handshake.None,
                ReadTimeout = 100,
                WriteTimeout = 3000
            };
            if (toolStripComboBox_parity.SelectedIndex == 0) port.Parity = Parity.None;
            if (toolStripComboBox_parity.SelectedIndex == 1) port.Parity = Parity.Odd;
            if (toolStripComboBox_parity.SelectedIndex == 2) port.Parity = Parity.Even;
            if (toolStripComboBox_stopbit.SelectedIndex == 0) port.StopBits = StopBits.None;
            if (toolStripComboBox_stopbit.SelectedIndex == 1) port.StopBits = StopBits.One;
            if (toolStripComboBox_stopbit.SelectedIndex == 2) port.StopBits = StopBits.OnePointFive;
            if (toolStripComboBox_stopbit.SelectedIndex == 3) port.StopBits = StopBits.Two;
            try
            {
                if(port.IsOpen)     // 先关闭
                {
                    port.Close();
                }
                if (!port.IsOpen)
                {
                    port.Open();
                    has_connSensor = true;
                    port.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
                }
            }
            catch (IOException)
            {
                infor("串口打开异常");
            }
        }
        public void DataReceive(object sender, SerialDataReceivedEventArgs e)
        {
            has_reveived = true;
            int n = port.BytesToRead;
            byte[] receivebuf = new byte[n];
            port.Read(receivebuf, 0, n);
            Receive_Buffer.AddRange(receivebuf);

            while (Receive_Buffer.Count >= 228)
            {
                var head = Receive_Buffer[0];
                var CMD_TYPE = Receive_Buffer[1];
                if (head == 0x68 && CMD_TYPE == 0xF3)       // 找帧头
                {
                    len_of_frame = (UInt16)((Receive_Buffer[2] << 8) | Receive_Buffer[3]);
                    if (Receive_Buffer.Count < len_of_frame + 6)     // 数据接收不完整
                    {
                        break;
                    }
                    if (Receive_Buffer[len_of_frame + 5] != 0x6A)         // 帧尾校验失败
                    {
                        Receive_Buffer.RemoveRange(0, len_of_frame + 6);     // 移除该帧
                        continue;
                    }
                    Receive_Bytes = new byte[Receive_Buffer.Count];
                    Receive_Buffer.CopyTo(0, Receive_Bytes, 0, Receive_Buffer.Count);
                    Receive_Buffer.RemoveRange(0, len_of_frame + 6);

                    Data_Buff1.AddRange(Receive_Bytes);
                    DataTemp = new byte[len_of_frame + 6];

                    while (Data_Buff1.Count > (len_of_frame + 6))
                    {
                        Data_Buff2 = Data_Buff1.Take(len_of_frame + 6).ToList();
                        Data_Buff2.CopyTo(0, DataTemp, 0, len_of_frame + 6);
                        DataAnalysis();
                        Data_Buff1.RemoveRange(0, len_of_frame + 6);
                    }
                    Data_Buff1.Clear();
                }
                else
                {
                    Receive_Buffer.RemoveAt(0);
                }
                if(port.IsOpen)
                {
                    port.DiscardInBuffer();
                }
            }
        }
        public byte CheckXOR(byte[] data)
        {
            byte CheckCode = 0;
            int len = data.Length - 2;
            for (int i = 0; i < len; i++)
            {
                CheckCode ^= data[i];
            }
            return CheckCode;
        }
        public void DataAnalysis()
        {
            if (CheckXOR(DataTemp) == DataTemp[len_of_frame + 4])
            {
                UInt16 Data_Count = (UInt16)(len_of_frame / 9);
                Int32[] VER_DATA_Buffer = new Int32[3 * Data_Count];
                int x, y;
                for (int i = 0; i < Data_Count; i++)
                {
                    x = i * 9;
                    y = i * 3;
                    VER_DATA_Buffer[y + 0] = (Int32)(((DataTemp[x + 4] << 16) | (DataTemp[x + 5] << 8) | (DataTemp[x + 6] & 0xF0)));
                    VER_DATA_Buffer[y + 1] = (Int32)((DataTemp[x + 7] << 16) | (DataTemp[x + 8] << 8) | (DataTemp[x + 9] & 0xF0));
                    VER_DATA_Buffer[y + 2] = (Int32)((DataTemp[x + 10] << 16) | (DataTemp[x + 11] << 8) | (DataTemp[x + 12] & 0xF0));

                    if ((DataTemp[x + 4] & 0x80) == 0)
                    {
                        VER_DATA_Buffer[y + 0] = ((VER_DATA_Buffer[y + 0] << 8) >> 12) & 0x0007FFFF;
                    }
                    else
                    {
                        VER_DATA_Buffer[y + 0] = ((~(((VER_DATA_Buffer[y + 0] << 8) >> 12) & 0x0007FFFF)) & 0x0007FFFF) * (-1);
                    }

                    if ((DataTemp[x + 7] & 0x80) == 0)
                    {
                        VER_DATA_Buffer[y + 1] = ((VER_DATA_Buffer[y + 1] << 8) >> 12) & 0x0007FFFF;
                    }
                    else
                    {
                        VER_DATA_Buffer[y + 1] = ((~(((VER_DATA_Buffer[y + 1] << 8) >> 12) & 0x0007FFFF)) & 0x0007FFFF) * (-1);
                    }

                    if ((DataTemp[x + 10] & 0x80) == 0)
                    {
                        VER_DATA_Buffer[y + 2] = ((VER_DATA_Buffer[y + 2] << 8) >> 12) & 0x0007FFFF;
                    }
                    else
                    {
                        VER_DATA_Buffer[y + 2] = ((~(((VER_DATA_Buffer[y + 2] << 8) >> 12) & 0x0007FFFF)) & 0x0007FFFF) * (-1);
                    }
                    var k_range = 0.07629;
                    var XAxis = Convert.ToInt32(((Int32)VER_DATA_Buffer[y + 0] * k_range));
                    var YAxis = Convert.ToInt32(((Int32)VER_DATA_Buffer[y + 1] * k_range));
                    var ZAxis = Convert.ToInt32(((Int32)VER_DATA_Buffer[y + 2] * k_range));
                    var time = DateTime.Now.ToString("HH:mm:ss:fff");
                    RECEIVE_ALL++;
                    var document = new BsonDocument
                    {
                        { "time", time },
                        { "X", XAxis },
                        { "Y", YAxis },
                        { "Z", ZAxis }
                    };
                    string adata = time + " " + XAxis.ToString() + " " + YAxis.ToString() + " " + ZAxis.ToString();
                    lock (PLOT_DOT_BUFFER)
                    {
                        PLOT_DOT_BUFFER.Add(adata);
                    }
                    if (GlobalParameter.USE_DB)     // 使用数据库，则缓存到documentList
                    {
                        lock (documentList)
                        {
                            documentList.Add(document);
                        }
                    }
                    else  // 不使用数据库，则缓存到CSV_LIST
                    {
                        lock (CSV_LIST)
                        {
                            CSV_LIST.Add(adata);
                        }
                    }
                }
            }
        }
        #endregion

    }
}
