using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using Trace.entity;

namespace Trace
{
    public partial class FormConfig : Form
    {
        String directory;
        OleDbConnection mycon;
        FileInfo sysConfig;

        DataSet dataSetSource;
        DataTable dataTableSource;

        public FormConfig()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            directory = Environment.CurrentDirectory.ToString();
            //MessageBox.Show(directory);
            //Step2: 连接数据库
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directory + "/ncpzs.mdb;Jet OLEDB:Database Password=52586668";
            mycon = new OleDbConnection(connStr);
            mycon.Open();

            //MessageBox.Show("数据打开成功！");
            queryProduct();
            querySource();

            //tbxMaxLabelNum.Text = "18";
            sysConfig = new FileInfo(directory + "/cfg_sys.txt");
            if (!sysConfig.Exists)
            {
                sysConfig.Create();
            }

            StreamReader reader = new StreamReader(sysConfig.FullName);
            cbxPort.SelectedItem = reader.ReadLine();
            tbxMaxLabelNum.Text = reader.ReadLine();
            cbxLabelSize.SelectedItem = reader.ReadLine();
            //tbxCopFullName.Text = reader.ReadLine();
            //tbxCopShortName.Text = reader.ReadLine();
            //tbxCopNetAddress.Text = reader.ReadLine();
            reader.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabProduct_Click(object sender, EventArgs e)
        {
            
        }

        //取出产品列表
        public void queryProduct()
        {
            string sql = "select SORT as 序号, NAME as 品名, ID as 编号 " +
                         "from PRODUCT order by SORT asc";

            OleDbCommand cmd = new OleDbCommand(sql, mycon);
            OleDbDataReader reader = cmd.ExecuteReader();
            DataSet dateset = new DataSet();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgvProduct.DataSource = dt;
            dgvProduct.Columns[0].Width = 60;
            dgvProduct.Columns[1].Width = 200;
            dgvProduct.Columns[2].Visible = false;
        }

        //取出基地列表
        public void querySource()
        {
            string sql = "select SORT as 序号, NAME as 基地名称, ADDRESS as 地址, PIC as 负责人, ID as 编号 " +
                         "from SOURCE order by SORT asc";

            OleDbCommand cmd = new OleDbCommand(sql, mycon);
            OleDbDataReader reader = cmd.ExecuteReader();
            dataSetSource = new DataSet();
            dataTableSource = new DataTable();
            dataTableSource.Load(reader);
            dgvSource.DataSource = dataTableSource;
           
            dgvSource.Columns[0].Width = 60;
            dgvSource.Columns[1].Width = 200;
            dgvSource.Columns[2].Width = 200;
            dgvSource.Columns[3].Visible = false;
           
        }

        private void tabsConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void tabBase_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSavePrintConfig_Click(object sender, EventArgs e)
        {
            if (!sysConfig.Exists)
            {
                sysConfig.Create();
            }
            StreamWriter writer = new StreamWriter(sysConfig.FullName);
            writer.WriteLine(cbxPort.SelectedItem.ToString());
            writer.WriteLine(tbxMaxLabelNum.Text);
            writer.WriteLine(cbxLabelSize.SelectedItem.ToString());
            writer.Close();
            MessageBox.Show("设置成功！");
        }

        private void btnSaveCopConfig_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveSource_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(dgvSource.NewRowIndex.ToString());
            DataRow dr = dataTableSource.NewRow();
            //MessageBox.Show(dr.);
            dgvSource.Update();

            MessageBox.Show("保存成功");
        }

        private void btnAddSource_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormAddSource"];  //查找是否打开过Form1窗体  
            if (f == null)
            {
                FormAddSource formAddSource = new FormAddSource("add", mycon, this, new Source());
                formAddSource.Show();
            }
            else
            {
                f.Focus();
            }  
            
            
        }

        private void btnDeleteSource_Click(object sender, EventArgs e)
        {
            string id = dgvSource.SelectedRows[0].Cells[4].Value.ToString();
            string sql = "delete from SOURCE where ID = " + id;
            OleDbCommand cmd = new OleDbCommand(sql, mycon);
            cmd.ExecuteNonQuery();
            querySource();
        }

        private void btnEditSource_Click(object sender, EventArgs e)
        {
            Source source = new Source();
            source.id = int.Parse(dgvSource.SelectedRows[0].Cells[4].Value.ToString());
            source.name = dgvSource.SelectedRows[0].Cells[1].Value.ToString();
            source.address = dgvSource.SelectedRows[0].Cells[2].Value.ToString();
            source.pic = dgvSource.SelectedRows[0].Cells[3].Value.ToString();
            source.sort = int.Parse(dgvSource.SelectedRows[0].Cells[0].Value.ToString());

            Form f = Application.OpenForms["FormAddSource"];  //查找是否打开过Form1窗体  
            if (f == null)
            {
                FormAddSource formAddSource = new FormAddSource("edit", mycon, this, source);
                formAddSource.Show();
            }
            else
            {
                f.Focus();
            }  

            
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormAddProduct"];  //查找是否打开过Form1窗体  
            if (f == null)
            {
                FormAddProduct formAddProduct = new FormAddProduct("add", mycon, this, new Product());
                formAddProduct.Show();
            }
            else
            {
                f.Focus();
            }  

            
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.id = int.Parse(dgvProduct.SelectedRows[0].Cells[2].Value.ToString());
            product.name = dgvProduct.SelectedRows[0].Cells[1].Value.ToString();
            product.sort = int.Parse(dgvProduct.SelectedRows[0].Cells[0].Value.ToString());

            Form f = Application.OpenForms["FormAddProduct"];  //查找是否打开过Form1窗体  
            if (f == null)
            {
                FormAddProduct formAddSource = new FormAddProduct("edit", mycon, this, product);
                formAddSource.Show();
            }
            else
            {
                f.Focus();
            }  

           
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string id = dgvProduct.SelectedRows[0].Cells[2].Value.ToString();
            string sql = "delete from PRODUCT where ID = " + id;
            OleDbCommand cmd = new OleDbCommand(sql, mycon);
            cmd.ExecuteNonQuery();
            queryProduct();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPageCompanyInfo_Click(object sender, EventArgs e)
        {

        }

        private void dgvSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        
       
    }
}
