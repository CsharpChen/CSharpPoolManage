using ManagePool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagePoolDemo.TestMan
{
    public static class ManDemo
    {
        public static void Start() 
        {
            //OptionManagePool<ManManageEntity, ManObj>.RemoveObjectTime = 0; // 关闭移除对象
            //OptionManagePool<ManManageEntity, ManObj>.StartTimerTime = 0; //关闭定时器

            OptionManagePool<ManManageEntity, ManObj>.CreateObject(50); //初始化创建 50个工人
            int num = 0;
            while (true)
            {
                Console.WriteLine(" 当前池里面一共有 : " + OptionManagePool<ManManageEntity, ManObj>.AllObj.Count + " 个对象");
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
                var OB = OptionManagePool<ManManageEntity, ManObj>.GetOneObj();
                OB.MakeWork();
                OptionManagePool<ManManageEntity, ManObj>.Recovery(OB);
            }

        }
    }
}
