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
        public MySqlConnection RealizationObj()
        {
            string ConnectionStr =ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //string ConnectionStr = "server=localhost;port=3306;user id=root;password=goodluck;database=mysql;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(ConnectionStr);
            conn.Open();
            return conn;
        }
    }
}
