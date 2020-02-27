using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePool
{
    /// <summary>
    /// 对象的实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjRealization<T> where T: class,new()
    {
        T RealizationObj();
    }
}
