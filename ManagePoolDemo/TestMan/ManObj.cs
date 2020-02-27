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
        public ManManageEntity RealizationObj()
        {
            ManManageEntity MME = new ManManageEntity();
            MME.IsInit0 = true;
            return MME;
        }
    }
}
