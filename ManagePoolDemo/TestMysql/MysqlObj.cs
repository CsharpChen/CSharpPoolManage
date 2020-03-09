using ManagePool;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePoolDemo.TestMysql
{
    public class MysqlObj : IObjRealization<MySqlConnection>
    {
        /// <summary>
        /// 创建 数据库连接
        /// </summary>
        /// <returns></returns>
        public MySqlConnection RealizationObj()
        {
            string ConnectionStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //string ConnectionStr = "server=localhost;port=3306;user id=root;password=goodluck;database=mysql;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(ConnectionStr);
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="t"></param>
        public void ObjClose(MySqlConnection t)
        {
            t.Close();
        }
        /// <summary>
        /// 对象回收时 需要执行的操作
        /// </summary>
        /// <param name="t"></param>
        public void ObjRecovery(MySqlConnection t)
        {
            // 什么都不做
        }
    }
}
