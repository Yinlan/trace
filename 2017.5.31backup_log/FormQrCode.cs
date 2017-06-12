using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Collections;
using System.Net;
using Newtonsoft.Json;
using Trace.entity;
using Trace.util;
using System.Threading;

namespace Trace
{
    public partial class FormQrCode : Form
    {
        OleDbConnection mycon;
        FileInfo sysConfig;
        SysConfig baseConfig;
        string directory;
        string port;
        int maxPrintNum;
        string labelSize;
        int uploadOkNum = 0; //成功上传的记录数
        int productCount = 0;

        string pid = ""; //产品ID，用在一标右侧二维码上

        string[] pids;

        public FormQrCode()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            openDataBase();
            getSysConfig(); //是从数据库取的
        }

        private void FormQrCode_Load(object sender, EventArgs e)
        {
            directory = Environment.CurrentDirectory.ToString();
            //MessageBox.Show(directory);
            sysConfig = new FileInfo(directory + "/cfg_sys.txt");
            if (!sysConfig.Exists)
            {
                sysConfig.Create();
            }

            StreamReader reader = new StreamReader(sysConfig.FullName);
            port = reader.ReadLine();
            maxPrintNum = int.Parse(reader.ReadLine());
            labelSize = reader.ReadLine();
            reader.Close();

            try
            {
                serialPort1.PortName = port;
                serialPort1.BaudRate = 9600;
                serialPort1.Encoding = System.Text.Encoding.GetEncoding("GB2312");// 将打印机的字符集设置为端口的字符集(否则中文乱码)
                serialPort1.Open();
                labelPortStatus.Text += "已连接";
                serialPort1.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("串口未连接！");
                labelPortStatus.Text += "未连接";
                //test
                btnPrint.Enabled = false;
            }

            dtpPickTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtpDetectTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directory + "/ncpzs.mdb;Jet OLEDB:Database Password=52586668";
                mycon = new OleDbConnection(connStr);
                mycon.Open();
                labelDBStatus.Text += "已连接";

                //初始化相关数据
                //1. 产品列表
                string sql = "select * from PRODUCT order by SORT asc";

                OleDbCommand cmd = new OleDbCommand(sql, mycon);
                OleDbDataReader dataReader = cmd.ExecuteReader();
                DataSet dateset = new DataSet();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                cmd.Dispose();
                int top = 0;
                pids = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    /*
                    CheckBox chkBox = new CheckBox();
                    chkBox.Text = dt.Rows[i][1].ToString();
                    chkBox.Top = top;
                    chkBox.BackColor = Color.Beige;
                    chkBox.Padding = new Padding(5, 2, 2, 2);
                    chkBox.FlatStyle = FlatStyle.Popup;
                    tip.SetToolTip(chkBox, chkBox.Text);
                    panelProducts.Controls.Add(chkBox);
                    top = chkBox.Top + 20;
                    */
                    //改用单选按钮
                    RadioButton radio = new RadioButton();
                    radio.Text = dt.Rows[i][1].ToString();
                    radio.Top = top;
                    radio.BackColor = Color.Beige;
                    radio.Padding = new Padding(5, 2, 2, 2);
                    radio.FlatStyle = FlatStyle.Popup;
                    radio.Width = panelProducts.Width - 10;
                    tip.SetToolTip(radio, radio.Text);
                    panelProducts.Controls.Add(radio);
                    top = radio.Top + 20;

                    pids[i] = dt.Rows[i][3].ToString();

                }
                
                productCount = dt.Rows.Count;

                //2. 基地列表与对应负责人

                sql = "select * from SOURCE order by SORT asc";

                cmd = new OleDbCommand(sql, mycon);
                dataReader = cmd.ExecuteReader();
                dateset = new DataSet();
                dt = new DataTable();
                dt.Load(dataReader);
                cmd.Dispose();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbxSource.Items.Add(dt.Rows[i][1]);
                    cbxPIC.Items.Add(dt.Rows[i][2]);
                }
                cbxSource.SelectedIndex = 0;
                cbxPIC.SelectedIndex = 0;

            }
            catch (Exception)
            {
                labelDBStatus.Text += "未连接";
            }



        }

        private void labelNC_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("1");
            string copSign = baseConfig.companyCode; //公司标识

            string tempSign = "temp"; //临时标记

            string enter = System.Environment.NewLine;
            //获取品名，可能是一个包装里面多种产品
            //string name = cbxName.SelectedItem.ToString();
            string name = "";

            /*
            for(int i = 0; i < productCount; i++){
                CheckBox chkBox = (CheckBox)panelProducts.Controls[i];
                if (chkBox.Checked == true) 
                { 
                    name += (chkBox.Text + "  "); 
                }
            }
            */

            for (int i = 0; i < productCount; i++)
            {
                RadioButton radio = (RadioButton)panelProducts.Controls[i];
                if (radio.Checked == true)
                {
                    name += (radio.Text + "  ");
                    pid = pids[i];
                }
            }
            
            if(name.Trim().Length == 0){
                MessageBox.Show("请选择产品！");
                return;
            }

            string no = tbxNo.Text;
            /*
            if (no.Trim().Length == 0)
            {
                MessageBox.Show("请填写编号（编号与检测编号一致）！");
                return;
            }
            */
            string time = dtpPickTime.Text;
           
            string source = cbxSource.SelectedItem.ToString();
            string detectTime = dtpDetectTime.Text + " " + DateTime.Now.ToString("HH:mm"); ;
            string nc = "合格";
            string pic = cbxPIC.SelectedItem.ToString();
        
            int count = int.Parse(tbxLabelNum.Text); 

            if(count > maxPrintNum){
                MessageBox.Show("本次打印的标签数超过了一次最多打印数量！");
                return;
            }

            //return;
            /* netid 总体操作步骤：
             * 1. 存入本地数据库
             * 2. 打印
             * 3. 上传
             * 理由：
             *  netid 已存而纸未打：可以接受，下次再打不影响；
             *  标签已打，netid未存，则标签无效，被浪费，不可接受；
             *  netid 已存，标签已打，而未上传，可以接受，可事后再传；
             */

            try
            {
                //同时存入数据库，最后一个字段不能用NO，在C#中可能是保留字，报错，因此改为T_NO
                string printTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");        // 2008-09-04
                string sql = "insert into QRCODE (NAME, PICK_TIME, SOURCE, PIC, DETECT_TIME, NC, PRINT_TIME, NET_ID, T_NO, PRODUCT_ID)" +
                " values(\"" + name + 
                "\",\"" + time + 
                "\",\"" + source + 
                "\",\"" + pic +
                "\",\"" + detectTime + 
                "\",\"" + nc + 
                "\",\"" + printTime + 
                "\",\"" + tempSign + 
                "\",\"" + no +
                 "\",\"" + pid + "\")";

                OleDbCommand cmd;
             
                for (int i = 0; i < count; i++)
                {
                    tempSign = (i == 0 ? "temp" : "temp" + i);
                    sql = sql.Replace(tempSign, "temp" + ( i + 1 ));
                    cmd = new OleDbCommand(sql, mycon);
                   // MessageBox.Show(sql);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                string currentTime = DateTime.Now.ToString("yyMMddHHmmss");
                string traceSign = baseConfig.companyCode + baseConfig.workstationNo + currentTime; //用来替换temp的公司与时间标记
            
                sql = "update qrcode set net_id =  '" + traceSign + "' & right( net_id, ( len(net_id) - 4 ))   where net_id like '%temp%';";
                cmd = new OleDbCommand(sql, mycon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //同时上传到平台
                sql = "select top " + count + " * from qrcode order by id desc";
                cmd = new OleDbCommand(sql, mycon);
                OleDbDataReader dataReader = cmd.ExecuteReader();
                DataSet dateset = new DataSet();
                DataTable dt = new DataTable();
                dt.Load(dataReader);

                //打印
                //根据配置文件设定若干打印参数(Qx:二维码x起始点; Qy:二维码y起始点; Qwidth:二维码大小; Tx:溯源码x起始点; Ty:溯源码y起始点;)
                Hashtable ht = new Hashtable();
                if (StringUtil.isEmpty(labelSize)) { MessageBox.Show("未设置标签规格，无法打印"); return; }
                if (labelSize.Equals("5CM * 4CM")) //慧康默认形式
                {
                    ht.Add("Qx", "25");
                    ht.Add("Qy", "20");
                    ht.Add("Qwidth", "5");
                    ht.Add("Tx", "25");
                    ht.Add("Ty", "240");
                }

                if (labelSize.Equals("5CM * 4CM YB")) //一标公司的形式，两个二维码
                {
                    ht.Add("Q1x", "25");
                    ht.Add("Q1y", "20");
                    ht.Add("Q1width", "5");
                    ht.Add("Q2x", "220");
                    ht.Add("Q2y", "20");
                    ht.Add("Q2width", "5");

                    ht.Add("TLx", "25"); //"食安溯源 x"
                    ht.Add("TLy", "195"); //"食安溯源 y"

                    ht.Add("TRx", "225"); //"一标企业 x"
                    ht.Add("TRy", "195"); //"一标企业 y"

                    ht.Add("Tx", "25");
                    ht.Add("Ty", "260");

                    ht.Add("Telx", "25");
                    ht.Add("Tely", "290");
                }

                if (labelSize.Equals("2.5CM * 1.5CM YB")) //一标公司的形式，小尺寸标签
                {
                    ht.Add("Q1x", "20");
                    ht.Add("Q1y", "5");
                    ht.Add("Q1width", "2");

                    ht.Add("Q2x", "120");
                    ht.Add("Q2y", "5");
                    ht.Add("Q2width", "2");

                    ht.Add("TL1x", "90"); //"溯 x"
                    ht.Add("TL1y", "10"); //"溯 y"
                    ht.Add("TL2x", "90"); //"源 x"
                    ht.Add("TL2y", "40"); //"源 y"

                    ht.Add("TR1x", "182"); //"一 x"
                    ht.Add("TR1y", "10"); //"一 y"
                    ht.Add("TR2x", "182"); //"标 x"
                    ht.Add("TR2y", "40"); //"标 y"

                    ht.Add("Px", "20"); //"品名 x"
                    ht.Add("Py", "75"); //"品名 y"

                    ht.Add("Tx", "20");
                    ht.Add("Ty", "105");

                }

                if (labelSize.Equals("6CM * 9CM")) //慧康默认形式
                {
                    ht.Add("Qx", "100"); //二维码X
                    ht.Add("Qy", "150"); //二维码y
                    ht.Add("Qwidth", "7"); //二维码大小
                    ht.Add("I1x", "40"); //出产日期x
                    ht.Add("I1y", "470"); //出产日期y
                    ht.Add("I2x", "40"); //来源x
                    ht.Add("I2y", "500"); //来源y
                    ht.Add("T1x", "32"); //溯源码文字x
                    ht.Add("T1y", "596"); //溯源码文字y
                    ht.Add("T2x", "120"); //溯源码x
                    ht.Add("T2y", "596"); //溯源码y
                }

                if (labelSize.Equals("6CM * 9CM YB")) //慧康默认形式
                {

                    ht.Add("TLx", "65"); //"食安溯源 x"
                    ht.Add("TLy", "165"); //"食安溯源 y"
                    ht.Add("TRx", "285"); //"一标企业 x"
                    ht.Add("TRy", "165"); //"一标企业 y"

                    ht.Add("Q1x", "25");
                    ht.Add("Q1y", "220");
                    ht.Add("Q1width", "5");
                    ht.Add("Q2x", "245");
                    ht.Add("Q2y", "220");
                    ht.Add("Q2width", "5");

                    ht.Add("I1x", "40"); //出产日期x
                    ht.Add("I1y", "470"); //出产日期y
                    ht.Add("I2x", "40"); //来源x
                    ht.Add("I2y", "500"); //来源y
                    ht.Add("T1x", "32"); //溯源码文字x
                    ht.Add("T1y", "596"); //溯源码文字y
                    ht.Add("T2x", "120"); //溯源码x
                    ht.Add("T2y", "596"); //溯源码y
                }

                if (labelSize.Equals("5CM * 4CM YB 2017-1")) //一标2017-1，马云杰版 17.05
                {
                    ht.Add("Q1x", "25");
                    ht.Add("Q1y", "20");
                    ht.Add("Q1width", "5");
                    ht.Add("LOGOx", "220"); //一标logo
                    ht.Add("LOGOy", "20");
                    ht.Add("LOGOwidth", "5");

                    ht.Add("TLx", "25"); //"食安溯源 x"
                    ht.Add("TLy", "195"); //"食安溯源 y"

                    ht.Add("TRx", "225"); //"一标企业 x"
                    ht.Add("TRy", "195"); //"一标企业 y"

                    ht.Add("Tx", "25");
                    ht.Add("Ty", "260");

                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Qrcode qrcode = new Qrcode();
                    qrcode.pickTime = dt.Rows[i][2].ToString();
                    qrcode.source = dt.Rows[i][3].ToString();
                    qrcode.netId = dt.Rows[i][8].ToString(); //因为打印的url只需要netId这个字段

                    //先打印（打印是必须保证成功的，上传可以报错，catch掉即可）
                    try
                    {
                        string order = "";
                        // 5*4的指令 慧康默认形式
                        if (labelSize.Equals("5CM * 4CM"))
                        {
                            order =
                            "SIZE 50 mm, 40 mm" + enter +
                            "GAP 3 mm, 0" + enter +
                            "DIRECTION 0,0" + enter + //方向视情况而定
                            "CLS" + enter +
                            "DENSITY 10" + enter +
                            "QRCODE " + (string)ht["Qx"] + "," + (string)ht["Qy"] + ",H," + (string)ht["Qwidth"] + ",A,0, \"" + baseConfig.traceUrl + qrcode.netId + "\"" + enter +

                            "TEXT " + (string)ht["Tx"] + "," + (string)ht["Ty"] + ",\"3\",0,1,1,\"" + qrcode.netId + "\"" + enter +

                            "PRINT 1,1" + enter;
                        }

                        // 5*4的指令 一标公司形式
                        if (labelSize.Equals("5CM * 4CM YB"))
                        {
                            string ybUrl = "http://trace.victtec.com/trace/yb/t.htm?pid=" + pid;
                            string tLeft = "食 安 溯 源";
                            string tRight = "一 标 企 业";
                            //string tel = "客户电话： *******" + tbxTel.Text; //已放弃
                            string product = "品名： " + name;

                            order =
                            "SIZE 50 mm, 40 mm" + enter +
                            "GAP 3 mm, 0" + enter +
                            "DIRECTION 0,0" + enter + //方向视情况而定
                            "CLS" + enter +
                            "DENSITY 10" + enter +
                            "QRCODE " + (string)ht["Q1x"] + "," + (string)ht["Q1y"] + ",H," + (string)ht["Q1width"] + ",A,0, \"" + baseConfig.traceUrl + qrcode.netId + "\"" + enter +
                            "QRCODE " + (string)ht["Q2x"] + "," + (string)ht["Q2y"] + ",H," + (string)ht["Q2width"] + ",A,0, \"" + ybUrl + "\"" + enter +

                            "TEXT " + (string)ht["TLx"] + "," + (string)ht["TLy"] + ",\"TSS24.BF2\",0,1,2,\"" + tLeft + "\"" + enter +
                            "TEXT " + (string)ht["TRx"] + "," + (string)ht["TRy"] + ",\"TSS24.BF2\",0,1,2,\"" + tRight + "\"" + enter +

                            "TEXT " + (string)ht["Tx"] + "," + (string)ht["Ty"] + ",\"3\",0,1,1,\"" + qrcode.netId  + "\"" + enter +

                          //"TEXT " + (string)ht["Telx"] + "," + (string)ht["Tely"] + ",\"TSS24.BF2\",0,1,1,\"" + tel + "\"" + enter +
                            "TEXT " + (string)ht["Telx"] + "," + (string)ht["Tely"] + ",\"TSS24.BF2\",0,1,1,\"" + product + "\"" + enter +

                            "PRINT 1,1" + enter;
                        }

                        // 2.5*2的指令 一标公司形式 小尺寸标签
                        if (labelSize.Equals("2.5CM * 1.5CM YB"))
                        {
                            string ybUrl = "http://trace.victtec.com/trace/yb/t.htm?pid=" + pid;
                            string tLeft1 = "溯", tLeft2 = "源";
                            string tRight1 = "一", tRight2 = "标";
                            string product = name;

                            order =
                            "SIZE 25 mm, 15 mm" + enter +
                            "GAP 2 mm, 0" + enter +
                            "DIRECTION 0,0" + enter + //方向视情况而定
                            "CLS" + enter +
                            "DENSITY 10" + enter +
                            "QRCODE " + (string)ht["Q1x"] + "," + (string)ht["Q1y"] + ",H," + (string)ht["Q1width"] + ",A,0, \"" + baseConfig.traceUrl + qrcode.netId + "\"" + enter +
                            "QRCODE " + (string)ht["Q2x"] + "," + (string)ht["Q2y"] + ",H," + (string)ht["Q2width"] + ",A,0, \"" + ybUrl + "\"" + enter +

                            "TEXT " + (string)ht["TL1x"] + "," + (string)ht["TL1y"] + ",\"TSS24.BF2\",0,1,1,\"" + tLeft1 + "\"" + enter +
                            "TEXT " + (string)ht["TL2x"] + "," + (string)ht["TL2y"] + ",\"TSS24.BF2\",0,1,1,\"" + tLeft2 + "\"" + enter +

                            "TEXT " + (string)ht["TR1x"] + "," + (string)ht["TR1y"] + ",\"TSS24.BF2\",0,1,1,\"" + tRight1 + "\"" + enter +
                            "TEXT " + (string)ht["TR2x"] + "," + (string)ht["TR2y"] + ",\"TSS24.BF2\",0,1,1,\"" + tRight2 + "\"" + enter +
                            
                            //"TEXT " + (string)ht["TRx"] + "," + (string)ht["TRy"] + ",\"TSS24.BF2\",0,1,1,\"" + tRight + "\"" + enter +

                            "TEXT " + (string)ht["Px"] + "," + (string)ht["Py"] + ",\"TSS24.BF2\",0,1,1,\"" + product + "\"" + enter +

                            "TEXT " + (string)ht["Tx"] + "," + (string)ht["Ty"] + ",\"1\",0,1,1,\"" + qrcode.netId + "\"" + enter +

                          //"TEXT " + (string)ht["Telx"] + "," + (string)ht["Tely"] + ",\"TSS24.BF2\",0,1,1,\"" + tel + "\"" + enter +
                          //  "TEXT " + (string)ht["Telx"] + "," + (string)ht["Tely"] + ",\"TSS24.BF2\",0,1,1,\"" + product + "\"" + enter +

                            "PRINT 1,1" + enter;
                        }

                        // 6*9的指令 慧康默认形式
                        if (labelSize.Equals("6CM * 9CM"))
                        {
                            order =
                            "SIZE 60 mm, 90 mm" + enter +
                            "GAP 3 mm, 0" + enter +
                            "DIRECTION 1,0" + enter +
                            "CLS" + enter +
                            "DENSITY 10" + enter +
                            "QRCODE " + (string)ht["Qx"] + "," + (string)ht["Qy"] + ",H," + (string)ht["Qwidth"] + ",A,0, \"" + baseConfig.traceUrl + qrcode.netId + "\"" + enter +

                            "TEXT " + (string)ht["I1x"] + "," + (string)ht["I1y"] + ",\"TSS24.BF2\",0,1,1,\"出产日期：" + qrcode.pickTime + "\"" + enter +
                            "TEXT " + (string)ht["I2x"] + "," + (string)ht["I2y"] + ",\"TSS24.BF2\",0,1,1,\"产品来源：" + qrcode.source + "\"" + enter +

                            "TEXT " + (string)ht["T1x"] + "," + (string)ht["T1y"] + ",\"TSS24.BF2\",0,1,1,\"溯源码：\"" + enter +
                            "TEXT " + (string)ht["T2x"] + "," + (string)ht["T2y"] + ",\"3\",0,1,1,\"" + qrcode.netId + "\"" + enter +

                            "PRINT 1,1" + enter;
                        }

                         // 6*9的指令 慧康默认形式
                        if (labelSize.Equals("6CM * 9CM YB"))
                        {
                            string ybUrl = "http://trace.victtec.com/trace/yb/t.htm?pid=" + pid;
                            string tLeft = "食 安 溯 源";
                            string tRight = "一 标 企 业";

                            order =
                            "SIZE 60 mm, 90 mm" + enter +
                            "GAP 3 mm, 0" + enter +
                            "DIRECTION 1,0" + enter +
                            "CLS" + enter +
                            "DENSITY 10" + enter +

                            "QRCODE " + (string)ht["Q1x"] + "," + (string)ht["Q1y"] + ",H," + (string)ht["Q1width"] + ",A,0, \"" + baseConfig.traceUrl + qrcode.netId + "\"" + enter +
                            "QRCODE " + (string)ht["Q2x"] + "," + (string)ht["Q2y"] + ",H," + (string)ht["Q2width"] + ",A,0, \"" + ybUrl + "\"" + enter +

                            "TEXT " + (string)ht["TLx"] + "," + (string)ht["TLy"] + ",\"TSS24.BF2\",0,1,2,\"" + tLeft + "\"" + enter +
                            "TEXT " + (string)ht["TRx"] + "," + (string)ht["TRy"] + ",\"TSS24.BF2\",0,1,2,\"" + tRight + "\"" + enter +


                            "TEXT " + (string)ht["I1x"] + "," + (string)ht["I1y"] + ",\"TSS24.BF2\",0,1,1,\"出产日期：" + qrcode.pickTime + "\"" + enter +
                            "TEXT " + (string)ht["I2x"] + "," + (string)ht["I2y"] + ",\"TSS24.BF2\",0,1,1,\"产品来源：" + qrcode.source + "\"" + enter +

                            "TEXT " + (string)ht["T1x"] + "," + (string)ht["T1y"] + ",\"TSS24.BF2\",0,1,1,\"溯源码：\"" + enter +
                            "TEXT " + (string)ht["T2x"] + "," + (string)ht["T2y"] + ",\"3\",0,1,1,\"" + qrcode.netId + "\"" + enter +

                            "PRINT 1,1" + enter;
                        }

                        // 5*4的指令 一标2017-1，马云杰版 17.05
                        if (labelSize.Equals("5CM * 4CM YB 2017-1"))
                        {
                            string ybUrl = "http://trace.victtec.com/trace/yb/t.htm?pid=" + pid;
                            string tLeft = "食 安 溯 源";
                            string tRight = "有机";
                            //string tel = "客户电话： *******" + tbxTel.Text; //已放弃
                            string product = "品名： " + name;

                            order =
                            "SIZE 50 mm, 40 mm" + enter +
                            "GAP 3 mm, 0" + enter +
                            "DIRECTION 0,0" + enter + //方向视情况而定
                            "CLS" + enter +
                            "DENSITY 10" + enter +
                            "QRCODE " + (string)ht["Q1x"] + "," + (string)ht["Q1y"] + ",H," + (string)ht["Q1width"] + ",A,0, \"" + baseConfig.traceUrl + qrcode.netId + "\"" + enter +
                           //Q2换成图片（一标logo)
                            "QRCODE " + (string)ht["Q2x"] + "," + (string)ht["Q2y"] + ",H," + (string)ht["Q2width"] + ",A,0, \"" + ybUrl + "\"" + enter +

                            "TEXT " + (string)ht["TLx"] + "," + (string)ht["TLy"] + ",\"TSS24.BF2\",0,1,2,\"" + tLeft + "\"" + enter +
                           //换成是否有机（要进行判断）
                            "TEXT " + (string)ht["TRx"] + "," + (string)ht["TRy"] + ",\"TSS24.BF2\",0,1,2,\"" + "有机" + "\"" + enter +

                            "TEXT " + (string)ht["Tx"] + "," + (string)ht["Ty"] + ",\"3\",0,1,1,\"" + qrcode.netId + "\"" + enter +
                            "TEXT " + (string)ht["Telx"] + "," + (string)ht["Tely"] + ",\"TSS24.BF2\",0,1,1,\"" + product + "\"" + enter +

                            "PRINT 1,1" + enter;
                        }

                        serialPort1.Open();
                        serialPort1.Write(order);
                        Thread.Sleep(100); //此处必须停顿，否则，实测除了最后一次的循环外，前面循环的最后一句都打不出来

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("打印出错！" + ex.Message);
                        return;
                    }
                    finally
                    {
                        serialPort1.Close();
                    }

                }
                
                //为保险起见，打印与上传两个操作先分开
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
                    qrcode.no = dt.Rows[i][10].ToString();
                    qrcode.productId = dt.Rows[i][11].ToString();
                    //MessageBox.Show(qrcode.no);
                    qrcodes.Add(qrcode);
                }

                upload(qrcodes);
                uploadOkNum = 0; //归零，准备下一次计数

            }
            catch(Exception ex){
                labelUploadResult.Text = "上传出错，" + ex.Message;
            }
            
        }

        //上传到网络平台（发送List 形式的json格式的数据）
        public void upload(ArrayList qrcodes)
        {
            string postData = ""; //要POST的数据
            string json = JsonConvert.SerializeObject(qrcodes);
            postData += json;
            string result = HttpUtil.post(baseConfig.uploadUrl, postData);

            if (result.Equals("OK"))
            {
                labelUploadResult.Text = "上传了 " + qrcodes.Count + " 条二维码记录";
                //更新一下库里的记录
                string netIds = "";
                foreach (Qrcode qrcode in qrcodes){
                    netIds += "'" + qrcode.netId + "',"; 
                }
                netIds = netIds.Substring(0, netIds.Length - 1);

                OleDbCommand cmd;
                string sql = "update qrcode set upload = '已上传' where net_id in (" + netIds + ") ";
                cmd = new OleDbCommand(sql, mycon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

        }
       

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxPIC.SelectedIndex = cbxSource.SelectedIndex;
        }

        

        //产品复选框的单击事件
        private void productCheckedChange(CheckBox chkbox)
        {
            if (chkbox.Checked == true) { chkbox.BackColor = Color.Navy; }
            else { chkbox.BackColor = panelProducts.BackColor; }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开数据库失败：" + ex.Message);
                return;
            }

        }

        //取出配置列表
        public void getSysConfig()
        {
            baseConfig = new SysConfig();
            string sql = "select * from SYS_CONFIG";
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, mycon);
                OleDbDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                baseConfig.companyName = dt.Rows[0][1].ToString();
                baseConfig.companyCode = dt.Rows[0][2].ToString();
                baseConfig.workstationNo = dt.Rows[0][3].ToString();
                baseConfig.mainBg = dt.Rows[0][4].ToString();
                baseConfig.traceUrl = dt.Rows[0][5].ToString();
                baseConfig.uploadUrl = dt.Rows[0][6].ToString();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法加载系统配置：" + ex.Message);
                return;
            }

        }

        private void panelProducts_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
