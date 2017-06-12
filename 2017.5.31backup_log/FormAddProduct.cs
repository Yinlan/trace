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
    public partial class FormAddProduct : Form
    {
        OleDbConnection mycon;
        FormConfig formConfig;
        string opType;
        Product product;

        public FormAddProduct(string type, OleDbConnection con, FormConfig config, Product pdt)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            mycon = con;
            formConfig = config;
            opType = type;
            product = pdt;
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            if (opType.Equals("add"))
            {
                this.Text = "添加产品";
            }
            if (opType.Equals("edit"))
            {
                this.Text = "修改产品信息";
                tbxName.Text = product.name;
                tbxSort.Text = product.sort.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = tbxName.Text;
            string sort = tbxSort.Text;

            if(StringUtil.isEmpty(name)){
                MessageBox.Show("请填写名称");
                return;
            }

            if (StringUtil.isEmpty(sort))
            {
                MessageBox.Show("请填写排序");
                return;
            }

            string sql = "";
            if (opType.Equals("add"))
            {
                sql = "insert into PRODUCT (NAME, SORT) values (\"" + name + "\"," + sort + ")";
            }
            if (opType.Equals("edit"))
            {
                sql = "update PRODUCT set NAME = \"" + name + "\", SORT = " + sort + " where ID = " + product.id;
            }
            OleDbCommand cmd = new OleDbCommand(sql, mycon);
            cmd.ExecuteNonQuery();
            formConfig.queryProduct();
            
            this.Close();
        }
    }
}
