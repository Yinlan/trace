using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace WindowsForms.func
{
    class Database
    {
        string directory;
        OleDbConnection conn;

        DataSet dataSetSource;
        DataTable dataTableSource;

        public Database() {
            directory = Environment.CurrentDirectory.ToString();
            //Step2: 连接数据库
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directory + "/fsd.mdb;";
            conn = new OleDbConnection(connStr);
           
        }

        public ArrayList query()
        {

            string sql = "select * from t_item";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            Console.WriteLine("数量：" + dt.Rows.Count);
           
            ArrayList list = new ArrayList();
            foreach(DataRow row in dt.Rows){
                Item item = new Item();
                item.id = (int)row[0];
                item.name1 = (string)row[1];
                list.Add(item);
            }

            reader.Dispose();
            reader.Close();
            conn.Dispose();
            conn.Close();

            return list;

        }


    }

    

}
