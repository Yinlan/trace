using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using Trace.entity;
using Trace.util;
using Newtonsoft.Json;

namespace Trace
{
    public partial class FormQrCodeQuery : Form
    {
        OleDbConnection mycon;
        string directory;
        SysConfig sysConfig;

        public FormQrCodeQuery()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void dgvQrCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormQrCodeQuery_Load(object sender, EventArgs e)
        {
            openDataBase();
            getSysConfig();

            directory = Environment.CurrentDirectory.ToString();
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directory + "/ncpzs.mdb;Jet OLEDB:Database Password=52586668";
            mycon = new OleDbConnection(connStr);
            mycon.Open();

            dtpEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtpStart.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
           
            queryQrCode();
  
        }

        private void queryQrCode()
        {
            
            string sql = "select NAME as 品名, PICK_TIME as 出产日期, SOURCE as 基地, PIC as 负责人, NC as 检测报告, PRINT_TIME as 打印时间, NET_ID as 溯源码, UPLOAD as 上传 " +
                "from QRCODE " +
                "where Left(PRINT_TIME, 10) >= \"" + dtpStart.Text + "\" and Left(PRINT_TIME, 10) <= \"" + dtpEnd.Text + "\" " +    
                "order by PRINT_TIME desc";

            try
            {
                 OleDbCommand cmd = new OleDbCommand(sql, mycon);
                 OleDbDataReader reader = cmd.ExecuteReader();
                 DataSet dateset = new DataSet();
                 DataTable dt = new DataTable();
                 dt.Load(reader);
                 dgvQrCode.DataSource = dt;
            }catch(Exception ex){
                MessageBox.Show("未能连接数据库：" + ex.Message);
                return;
            }
           
            dgvQrCode.Columns[2].Width = 150;
            dgvQrCode.Columns[3].Width = 80;
            dgvQrCode.Columns[4].Width = 80;
            dgvQrCode.Columns[5].Width = 150;
            dgvQrCode.Columns[6].Width = 150;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            queryQrCode();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            queryQrCode();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            queryQrCode();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 把没有上传的信息全部上传
        /// </summary>
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            string sql = "select * from qrcode where upload is null " + 
               "and Left(PRINT_TIME, 10) >= \"" + dtpStart.Text + "\" and Left(PRINT_TIME, 10) <= \"" + dtpEnd.Text + "\" ";

            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, mycon);
                OleDbDataReader reader = cmd.ExecuteReader();
                DataSet dateset = new DataSet();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    ArrayList qrcodes = new ArrayList();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Qrcode qrcode = new Qrcode();

                        qrcode.name = dt.Rows[i][1].ToString();
                        qrcode.pickTime = dt.Rows[i][2].ToString();
                        qrcode.source = dt.Rows[i][3].ToString();
                        qrcode.pic = dt.Rows[i][4].ToString();
                        qrcode.detectTime = dt.Rows[i][5].ToString();
                        qrcode.nc = dt.Rows[i][6].ToString();
                        qrcode.printTime = dt.Rows[i][7].ToString();
                        qrcode.netId = dt.Rows[i][8].ToString();

                        qrcodes.Add(qrcode);
                    }

                    upload(qrcodes);
                }
                else
                {
                    MessageBox.Show("没有需要上传的溯源码");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("未能连接数据库：" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 上传到网络平台（发送List 形式的json格式的数据）
        /// </summary>
        public void upload(ArrayList qrcodes)
        {
            //MessageBox.Show("start upload");
            string postData = ""; //要POST的数据
            string json = JsonConvert.SerializeObject(qrcodes);
            postData += json;
            string result = HttpUtil.post(sysConfig.uploadUrl, postData);

            if (result.Equals("OK"))
            {
                MessageBox.Show("上传成功！");
                labelUploadResult.Text = "上传了 " + qrcodes.Count + " 条二维码记录";
                //更新一下库里的记录
                string netIds = "";
                foreach (Qrcode qrcode in qrcodes)
                {
                    netIds += "'" + qrcode.netId + "',";
                }
                netIds = netIds.Substring(0, netIds.Length - 1);

                OleDbCommand cmd;
                string sql = "update qrcode set upload = '已上传' where net_id in (" + netIds + ") ";
                cmd = new OleDbCommand(sql, mycon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                queryQrCode();

            }

        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        public void openDataBase()
        {
            try
            {
                directory = Environment.CurrentDirectory.ToString();
                string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directory + "/ncpzs.mdb;Jet OLEDB:Database Password=52586668";
                mycon = new OleDbConnection(connStr);
                mycon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开数据库失败：" + ex.Message);
                return;
            }

        }

        /// <summary>
        /// 获取系统设置，包括url等
        /// </summary>
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
                sysConfig.uploadUrl = dt.Rows[0][6].ToString();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法加载系统配置：" + ex.Message);
                return;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
