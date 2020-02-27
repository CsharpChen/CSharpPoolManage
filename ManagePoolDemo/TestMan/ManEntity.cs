using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePoolDemo
{
    /// <summary>
    /// 工人实体类
    /// </summary>
    public class ManEntity
    {
        /// <summary>
        /// 工人名字
        /// </summary>
        public string Name { get; set; } = "工人 : " + Guid.NewGuid().ToString();
        /// <summary>
        /// 工人年龄
        /// </summary>
        public int Age { get; set; } = new Random().Next(18, 60);
    }
}
