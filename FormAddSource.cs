using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Trace.entity;
using Trace.util;

namespace Trace
{
    public partial class FormAddSource : Form
    {
        OleDbConnection mycon;
        FormConfig formConfig;
        string opType;
        Source source;

        public FormAddSource(string type, OleDbConnection con, FormConfig config, Source src)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            mycon = con;
            formConfig = config;
            opType = type;
            source = src;
        }

        private void FormAddSource_Load(object sender, EventArgs e)
        {
            if(opType.Equals("add")){
                this.Text = "添加基地";
            }
            if(opType.Equals("edit")){
                this.Text = "修改基地信息";
                tbxName.Text = source.name;
                tbxAddress.Text = source.address;
                tbxPIC.Text = source.pic;
                tbxSort.Text = source.sort.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = tbxName.Text;
            string address = tbxAddress.Text;
            string pic = tbxPIC.Text;
            string sort = tbxSort.Text;

            if (StringUtil.isEmpty(name))
            {
                MessageBox.Show("请填写名称");
                return;
            }

            if (StringUtil.isEmpty(address))
            {
                MessageBox.Show("请填写地址");
                return;
            }

            if (StringUtil.isEmpty(pic))
            {
                MessageBox.Show("请填写负责人");
                return;
            }

            if (StringUtil.isEmpty(sort))
            {
                MessageBox.Show("请填写排序");
                return;
            }

            string sql = "";
            if(opType.Equals("add")){
                sql = "insert into SOURCE (NAME, PIC, SORT, ADDRESS) values (\"" + name + "\",\""+ pic + "\",\"" + sort + "\",\"" + address+  "\")";
            }
            if (opType.Equals("edit"))
            {
                sql = "update SOURCE set NAME = \"" + name + "\", PIC = \"" + pic + "\", SORT = " + sort +  ", ADDRESS = \"" + address + "\" where ID = " + source.id;
            }
            Console.WriteLine("sql: " + sql);
            OleDbCommand cmd = new OleDbCommand(sql, mycon);
            cmd.ExecuteNonQuery();
            formConfig.querySource();
            this.Close();
        }
    }
}
