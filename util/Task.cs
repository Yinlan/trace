using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Trace.util
{
    /// <summary>
    /// 如果表多的话，可以考虑
    /// </summary>
    class Task
    {
        OleDbConnection conn;

        public Task()
        {
            string directory = Environment.CurrentDirectory.ToString();
            //Step2: 连接数据库
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directory + "/ncpzs.mdb;Jet OLEDB:Database Password=52586668";
            conn = new OleDbConnection(connStr);
            Console.WriteLine("构造：Conn：" + conn);
        }

       

        /// <summary>
        /// source表增加address字段 2017.6.1 马云杰的需求
        /// </summary>
        public Task DBAlterTableSourceAddColumnAddress()
        {

            string sql = "alter table source add COLUMN ADDRESS varchar";

            Console.WriteLine("SQL：" + sql);

            conn.Open();
            try
            {

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("列添加成功");
            }
            catch (Exception e)
            {
                Console.WriteLine("创建出错：" + e.Message);
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return this;

        }

        /// <summary>
        /// qrcode表增加address字段 2017.6.1 马云杰的需求
        /// </summary>
        public Task DBAlterTableQrCodeAddColumnAddress()
        {

            string sql = "alter table qrcode add COLUMN ADDRESS varchar";

            Console.WriteLine("SQL：" + sql);

            conn.Open();
            try
            {

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("列添加成功");
            }
            catch (Exception e)
            {
                Console.WriteLine("创建出错：" + e.Message);
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return this;

        }

    }    

}
