using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ManagePool
{
    public static class OptionManagePool<T, T2> where T : class, new() where T2 : IObjRealization<T>, new()
    {
        /// <summary>
        /// 启动定时器的时间
        /// </summary>
        public static int StartTimerTime = 1000 * 20 * 1;
        /// <summary>
        /// 删除老的对象的时间
        /// </summary>
        public static int RemoveObjectTime = 30;
        /// <summary>
        /// 池保存的集合
        /// </summary>
        public static ArrayList AllObj { get; set; } = new ArrayList();
        /// <summary>
        /// 构造函数
        /// </summary>
        static OptionManagePool()
        {
            // 这里只执行一次
            if (StartTimerTime != 0)
            {
                Timer aTimer = new Timer();
                aTimer.Elapsed += new ElapsedEventHandler(theout); //到达时间的时候执行事件；                      
                aTimer.Interval = StartTimerTime; // 设置引发时间的时间间隔 此处设置为1秒（1000毫秒） 
                aTimer.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
                aTimer.Enabled = true; //是否执行System.Timers.Timer.Elapsed事件
            }
        }
        /// <summary>
        /// 定时器执行的东西
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static void theout(object source, ElapsedEventArgs e)
        {
            ArrayList RemoveObj = new ArrayList();
            lock (AllObj)
            {
                if (RemoveObjectTime != 0)
                {
                    foreach (var a in AllObj)
                    {
                        TempEntity TEY = a as TempEntity;
                        if (TEY != null)
                        {
                            if (TEY.CreateTime < DateTime.UtcNow.AddSeconds(-1 * RemoveObjectTime))
                            {
                                RemoveObj.Add(a);
                            }
                        }

                    }
                    foreach (var a in RemoveObj)
                    {
                        AllObj.Remove(a);
                        if(a != null)
                        {
                            (new T2()).ObjClose((a as TempEntity).ObjT); 
                        }
                    }
                    AllObj.Remove(null);
                }

            }
        }
        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="t"></param>
        public static void Recovery(T t)
        {
            TempEntity TE = new TempEntity()
            {
                ObjT = t,
                IsUse = false
            };
            AllObj.Add(TE);
        }

        /// <summary>
        /// 获取一个目前不在 工作/使用 的对象
        /// </summary>
        /// <returns></returns>
        public static T GetOneObj()
        {
            if (AllObj.Count <= 0)
            {
                lock (AllObj)
                {
                    var TE = CreateNewObj();
                    var ObjT = TE.ObjT;
                    AllObj.Remove(TE);
                    return ObjT;
                }
            }
            else
            {
                lock (AllObj)
                {
                    try
                    {
                        var TE = AllObj[0] as TempEntity;
                        var ObjT = TE.ObjT;
                        AllObj.Remove(TE);
                        return ObjT;
                    }
                    catch
                    {
                        var TE = CreateNewObj();
                        var ObjT = TE.ObjT;
                        AllObj.Remove(TE);
                        return ObjT;
                    }

                }
            }
        }
        /// <summary>
        /// 创建一个新的对象
        /// </summary>
        /// <returns></returns>
        private static TempEntity CreateNewObj()
        {
            T2 t2 = new T2();
            TempEntity TE = new TempEntity()
            {
                ObjT = t2.RealizationObj(),
                IsUse = true
            };
            AllObj.Add(TE);
            return TE;
        }
        /// <summary>
        /// 管理对象
        /// </summary>
        private class TempEntity
        {
            /// <summary>
            /// 需要添加到池里面的对象
            /// </summary>
            public T ObjT { get; set; }
            /// <summary>
            /// 对象创建时间
            /// </summary>
            public DateTime CreateTime { get; set; } = DateTime.UtcNow;
            /// <summary>
            /// 对象是否现在在 工作/使用
            /// </summary>
            public bool IsUse { get; set; } = false;
        }
        /// <summary>
        /// 创建 传入参数数量的对象到池里面
        /// </summary>
        /// <param name="num"></param>
        public static void CreateObject(int num)
        {
            if (num <= 0)
            {
                throw new Exception("创建对象个数不能是小于0的数");
            }
            lock (AllObj)
            {
                for (int i = 0; i < num; i++)
                {
                    CreateNewObj();
                }
            }
        }
    }

}
