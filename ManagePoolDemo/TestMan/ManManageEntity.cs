using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagePoolDemo
{
    public class ManManageEntity
    {
        /// <summary>
        /// 是否初始化
        /// </summary>
        public bool IsInit0 { get; set; } = false;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.UtcNow.AddHours(8);
        /// <summary>
        /// 创建的工人
        /// </summary>
        public ManEntity OneMan { get; set; } = new ManEntity();
        /// <summary>
        /// 工人是否在工作 默认没有
        /// </summary>
        public bool IsUse = false;
        /// <summary>
        /// 工人开始工作
        /// </summary>
        public void MakeWork()
        {
            IsUse = true;
            int Make = new Random().Next(1000, 3000);
            Console.WriteLine(OneMan.Age + " 岁的 " + OneMan.Name + " 开始工作");
            Thread.Sleep(Make);
            Console.WriteLine(OneMan.Age + " 岁的 " + OneMan.Name + " 工作完成");
            Console.WriteLine("本次工作耗时" + Make + "毫秒");
            IsUse = false;
        }
    }
}
