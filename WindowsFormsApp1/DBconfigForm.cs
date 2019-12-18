using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DBconfigForm : Form
    {
        public DBconfigForm()
        {
            InitializeComponent();

            radioButton1_nouseDB.Checked = true;        // 默认不使用数据库
            radioButton1_useDB.Checked = false;
            textBox1_url.Enabled = false;
            textBox2_database.Enabled = false;
            textBox3_collection.Enabled = false;
            button1_yes.BackColor = Color.White;
            button1_no.BackColor = Color.White;
            label4_DB.Visible = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void radioButton1_useDB_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_url.Enabled = true;
            textBox2_database.Enabled = true;
            textBox3_collection.Enabled = false;
        }

        private void radioButton1_nouseDB_CheckedChanged(object sender, EventArgs e)
        {
            textBox1_url.Enabled = false;
            textBox2_database.Enabled = false;
            textBox3_collection.Enabled = false;
        }

        private void DBconfigForm_Load(object sender, EventArgs e)
        {
            textBox3_collection.Text = DateTime.Today.ToString(@"\Yyyyy\MMM\Ddd");
        }

        private void button1_no_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void button1_yes_Click(object sender, EventArgs e)
        {
            if (radioButton1_nouseDB.Checked)
            {
                GlobalParameter.USE_DB = false;
                GlobalParameter.HAS_CONNDB = false;
                this.Close();
            }
            else
            {
                // 连接数据库
                try
                {
                    MongoUrl url = new MongoUrl(textBox1_url.Text);
                    MongoClientSettings settings = MongoClientSettings.FromUrl(url);
                    settings.ServerSelectionTimeout = new TimeSpan(0, 0, 1);   // 尝试连接秒数
                    var client = new MongoClient(settings);
                    client.ListDatabaseNames();     // 获取所有数据库名，如果没连接成功则被catch
                                                    // 连接成功
                    GlobalParameter.USE_DB = true;
                    GlobalParameter.HAS_CONNDB = true;
                    GlobalParameter.URL = textBox1_url.Text;
                    GlobalParameter.DATEBASE = textBox2_database.Text;
                    GlobalParameter.COLLECTION = textBox3_collection.Text;
                    label4_DB.Visible = true;
                    label4_DB.Text = "数据库连接成功！";
                    MessageBox.Show("数据库连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    GlobalParameter.HAS_CONNDB = false;
                    GlobalParameter.USE_DB = false;
                    label4_DB.Visible = true;
                    label4_DB.Text = "数据库连接失败！";
                }
            }
        }
    }
}
