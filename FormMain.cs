using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.IO;
using Trace.entity;
using Trace.util;
using Newtonsoft.Json;

namespace Trace
{
    public partial class FormMain : Form
    {
        const string COP_VALID = "1", COP_INVALID = "0";
        SysConfig sysConfig;
        OleDbConnection mycon;
        string directory;

        public FormMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //做个任务，更新数据库，增加表
            new Task().DBAlterTableSourceAddColumnAddress()
                           .DBAlterTableQrCodeAddColumnAddress();
           
            openDataBase();
            getSysConfig();
            configInterface();
            checkPermission();
            downloadProducts(); 
        }
       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormConfig"];  //查找是否打开过Form1窗体  
            if (f == null)
            {
                FormConfig formConfig = new FormConfig();
                formConfig.Show();
            }
            else
            {
                f.Focus();
            }  

        }

        private void 二维码标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //查询软件许可试用期是否已过


            Form f = Application.OpenForms["FormQrCode"];  //查找是否打开过Form1窗体
            if (f == null)
            {
                FormQrCode formQrCode = new FormQrCode();
                formQrCode.Show();
            }
            else
            { 
                f.Focus();
            }  

        }

        private void 技术支持ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormTecSupport"];  //查找是否打开过Form1窗体  
            if (f == null)  
            {
                FormTecSupport formTecSupport = new FormTecSupport();
                formTecSupport.Show(); 
            }
            else
            {
                f.Focus();
            }  
        }

        private void 标签查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormQrCodeQuery"];  //查找是否打开过Form1窗体  
            if (f == null)
            {
                FormQrCodeQuery formQrCodeQuery = new FormQrCodeQuery();
                formQrCodeQuery.Show();
            }
            else
            {
                f.Focus();
            }  
        }

        //取出配置列表
        public void getSysConfig()
        {
            sysConfig = new SysConfig();
            string sql = "select * from SYS_CONFIG";
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, mycon);
                OleDbDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sysConfig.companyName = dt.Rows[0][1].ToString();
                sysConfig.companyCode = dt.Rows[0][2].ToString();
                sysConfig.workstationNo = dt.Rows[0][3].ToString();
                sysConfig.mainBg = dt.Rows[0][4].ToString();
                sysConfig.downloadProductsUrl = dt.Rows[0][7].ToString();
                sysConfig.checkPermissionUrl = dt.Rows[0][8].ToString();
            }catch(Exception ex){
                MessageBox.Show("无法加载系统配置：" + ex.Message);
               return;
            }
            
        }

        //打开数据库
        public void openDataBase()
        {
            try
            {
                directory = Environment.CurrentDirectory.ToString();
                string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directory + "/ncpzs.mdb;Jet OLEDB:Database Password=52586668";
                mycon = new OleDbConnection(connStr);
                mycon.Open();
            }catch(Exception ex){
                MessageBox.Show("打开数据库失败：" + ex.Message);
                return;
            }
           
        }

        //初始化主界面
        public void configInterface()
        {
            try
            {
                this.Text = sysConfig.companyName + "二维码溯源管理平台";
                this.BackgroundImage = Image.FromFile(directory + "\\img\\" + sysConfig.mainBg);
            }catch(Exception ex){
                MessageBox.Show("初始化界面失败：" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 从云平台检查客户端使用许可
        /// </summary>
        public void checkPermission()
        {
            string url = sysConfig.checkPermissionUrl.Replace("{code}", sysConfig.companyCode);

            string result = HttpUtil.get(url);
            if(!result.Equals(COP_VALID)){
                二维码标签ToolStripMenuItem.Enabled = false;
                MessageBox.Show("未获取许可或许可已过期，请重新申请");
            }

        }

        /// <summary>
        /// 从云平台下载产品信息
        /// </summary>
        public void downloadProducts()
        {
            string url = sysConfig.downloadProductsUrl.Replace("{code}", sysConfig.companyCode);
           
            string productsStr = HttpUtil.get(url);
           
            List<Product> products =  JsonConvert.DeserializeObject<List<Product>>(productsStr);

            if(products.Count() > 0){
                updateProductInfo(products);
            }

        }

        /// <summary>
        /// 更新本地数据库的产品信息
        /// </summary>
        public void updateProductInfo( List<Product> products )
        {

            string sql = "";

            sql = "delete from PRODUCT";
            OleDbCommand cmd = new OleDbCommand(sql, mycon);
            cmd.ExecuteNonQuery();

            foreach(Product product in products){
                sql = "insert into PRODUCT (NAME, SORT, PID) values (\"" + product.name + "\"," + products.IndexOf(product) + ","+ product.id +")";
                cmd = new OleDbCommand(sql, mycon);
                cmd.ExecuteNonQuery();
            }

            mycon.Close();

        }

        //for test
        private void 图像测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
