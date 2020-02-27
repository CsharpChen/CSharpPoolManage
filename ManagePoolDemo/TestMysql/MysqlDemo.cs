using ManagePool;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagePoolDemo.TestMysql
{
    public static class MysqlDemo
    {
        public static void Start() 
        {
            // OptionManagePool<MySqlConnection, MysqlObj>.CreateObject(50); // 初始化创建50个连接池
            int num = 0;
            while (true)
            {
                Console.WriteLine(" 当前池里面一共有 : " + OptionManagePool<MySqlConnection, MysqlObj>.AllObj.Count + " 个对象");
                if (num <= 50)
                {
                    Thread thread = new Thread(Recv);
                    thread.IsBackground = true;
                    thread.Start();
                }
                else if (num >= 200) { /*num = 40;*/ }
                num++;

            }
        }
        private static void Recv()
        {
            for (int i = 0; i < 10; i++)
            {
                var OB = OptionManagePool<MySqlConnection, MysqlObj>.GetOneObj();
                string SqlQue = "select 1 ";
                MySqlCommand cmd = new MySqlCommand(SqlQue, OB);
                try
                {
                    Console.WriteLine(cmd.ExecuteScalar().ToString());
                }
                catch(Exception E)
                {
                    Console.WriteLine(E.Message);
                }
                OptionManagePool<MySqlConnection, MysqlObj>.Recovery(OB);
            }

        }
    }
}
