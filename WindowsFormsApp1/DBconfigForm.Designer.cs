namespace WindowsFormsApp1
{
    partial class DBconfigForm
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
            this.radioButton1_useDB = new System.Windows.Forms.RadioButton();
            this.radioButton1_nouseDB = new System.Windows.Forms.RadioButton();
            this.groupBox1_DBconfig = new System.Windows.Forms.GroupBox();
            this.label4_DB = new System.Windows.Forms.Label();
            this.button1_no = new System.Windows.Forms.Button();
            this.textBox3_collection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1_yes = new System.Windows.Forms.Button();
            this.textBox2_database = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1_DBconfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1_useDB
            // 
            this.radioButton1_useDB.AutoSize = true;
            this.radioButton1_useDB.BackColor = System.Drawing.Color.White;
            this.radioButton1_useDB.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton1_useDB.Location = new System.Drawing.Point(71, 31);
            this.radioButton1_useDB.Name = "radioButton1_useDB";
            this.radioButton1_useDB.Size = new System.Drawing.Size(106, 20);
            this.radioButton1_useDB.TabIndex = 0;
            this.radioButton1_useDB.Text = "使用数据库";
            this.radioButton1_useDB.UseVisualStyleBackColor = false;
            this.radioButton1_useDB.CheckedChanged += new System.EventHandler(this.radioButton1_useDB_CheckedChanged);
            // 
            // radioButton1_nouseDB
            // 
            this.radioButton1_nouseDB.AutoSize = true;
            this.radioButton1_nouseDB.Checked = true;
            this.radioButton1_nouseDB.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton1_nouseDB.Location = new System.Drawing.Point(236, 31);
            this.radioButton1_nouseDB.Name = "radioButton1_nouseDB";
            this.radioButton1_nouseDB.Size = new System.Drawing.Size(122, 20);
            this.radioButton1_nouseDB.TabIndex = 0;
            this.radioButton1_nouseDB.TabStop = true;
            this.radioButton1_nouseDB.Text = "不使用数据库";
            this.radioButton1_nouseDB.UseVisualStyleBackColor = true;
            this.radioButton1_nouseDB.CheckedChanged += new System.EventHandler(this.radioButton1_nouseDB_CheckedChanged);
            // 
            // groupBox1_DBconfig
            // 
            this.groupBox1_DBconfig.Controls.Add(this.label4_DB);
            this.groupBox1_DBconfig.Controls.Add(this.button1_no);
            this.groupBox1_DBconfig.Controls.Add(this.textBox3_collection);
            this.groupBox1_DBconfig.Controls.Add(this.label3);
            this.groupBox1_DBconfig.Controls.Add(this.button1_yes);
            this.groupBox1_DBconfig.Controls.Add(this.textBox2_database);
            this.groupBox1_DBconfig.Controls.Add(this.label2);
            this.groupBox1_DBconfig.Controls.Add(this.textBox1_url);
            this.groupBox1_DBconfig.Controls.Add(this.label1);
            this.groupBox1_DBconfig.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox1_DBconfig.Location = new System.Drawing.Point(12, 98);
            this.groupBox1_DBconfig.Name = "groupBox1_DBconfig";
            this.groupBox1_DBconfig.Size = new System.Drawing.Size(407, 301);
            this.groupBox1_DBconfig.TabIndex = 3;
            this.groupBox1_DBconfig.TabStop = false;
            this.groupBox1_DBconfig.Text = "数据库参数设置";
            // 
            // label4_DB
            // 
            this.label4_DB.AutoSize = true;
            this.label4_DB.Location = new System.Drawing.Point(157, 204);
            this.label4_DB.Name = "label4_DB";
            this.label4_DB.Size = new System.Drawing.Size(49, 14);
            this.label4_DB.TabIndex = 8;
            this.label4_DB.Text = "label4";
            // 
            // button1_no
            // 
            this.button1_no.BackColor = System.Drawing.Color.White;
            this.button1_no.Location = new System.Drawing.Point(251, 238);
            this.button1_no.Name = "button1_no";
            this.button1_no.Size = new System.Drawing.Size(106, 38);
            this.button1_no.TabIndex = 7;
            this.button1_no.Text = "取消";
            this.button1_no.UseVisualStyleBackColor = false;
            this.button1_no.Click += new System.EventHandler(this.button1_no_Click);
            // 
            // textBox3_collection
            // 
            this.textBox3_collection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3_collection.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox3_collection.Location = new System.Drawing.Point(99, 159);
            this.textBox3_collection.Name = "textBox3_collection";
            this.textBox3_collection.Size = new System.Drawing.Size(258, 26);
            this.textBox3_collection.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(6, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Colloction";
            // 
            // button1_yes
            // 
            this.button1_yes.BackColor = System.Drawing.Color.White;
            this.button1_yes.Location = new System.Drawing.Point(42, 238);
            this.button1_yes.Name = "button1_yes";
            this.button1_yes.Size = new System.Drawing.Size(106, 38);
            this.button1_yes.TabIndex = 6;
            this.button1_yes.Text = "确定";
            this.button1_yes.UseVisualStyleBackColor = false;
            this.button1_yes.Click += new System.EventHandler(this.button1_yes_Click);
            // 
            // textBox2_database
            // 
            this.textBox2_database.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2_database.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox2_database.Location = new System.Drawing.Point(99, 100);
            this.textBox2_database.Name = "textBox2_database";
            this.textBox2_database.Size = new System.Drawing.Size(258, 26);
            this.textBox2_database.TabIndex = 3;
            this.textBox2_database.Text = "Vibration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(21, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "DataBase";
            // 
            // textBox1_url
            // 
            this.textBox1_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1_url.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1_url.Location = new System.Drawing.Point(99, 42);
            this.textBox1_url.Name = "textBox1_url";
            this.textBox1_url.Size = new System.Drawing.Size(258, 26);
            this.textBox1_url.TabIndex = 1;
            this.textBox1_url.Text = "mongodb://localhost:27017";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(61, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // DBconfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 406);
            this.Controls.Add(this.groupBox1_DBconfig);
            this.Controls.Add(this.radioButton1_nouseDB);
            this.Controls.Add(this.radioButton1_useDB);
            this.Name = "DBconfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBconfig";
            this.Load += new System.EventHandler(this.DBconfigForm_Load);
            this.groupBox1_DBconfig.ResumeLayout(false);
            this.groupBox1_DBconfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1_useDB;
        private System.Windows.Forms.RadioButton radioButton1_nouseDB;
        private System.Windows.Forms.GroupBox groupBox1_DBconfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1_url;
        private System.Windows.Forms.TextBox textBox2_database;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3_collection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1_no;
        private System.Windows.Forms.Button button1_yes;
        private System.Windows.Forms.Label label4_DB;
    }
}