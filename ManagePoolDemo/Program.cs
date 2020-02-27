using ManagePool;
using ManagePoolDemo.TestMan;
using ManagePoolDemo.TestMysql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagePoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ManDemo.Start();
            MysqlDemo.Start();
            Console.Read();
        }
    }
}
