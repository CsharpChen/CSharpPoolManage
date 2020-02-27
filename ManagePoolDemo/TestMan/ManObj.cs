using ManagePool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePoolDemo
{
    public class ManObj : IObjRealization<ManManageEntity>
    {
        /// <summary>
        /// 关闭工人对象
        /// </summary>
        /// <param name="t"></param>
        public void ObjClose(ManManageEntity t)
        {
            // 无需关闭
        }
        /// <summary>
        /// 创建工人对象
        /// </summary>
        /// <returns></returns>
        public ManManageEntity RealizationObj()
        {
            ManManageEntity MME = new ManManageEntity();
            MME.IsInit0 = true;
            return MME;
        }
    }
}
