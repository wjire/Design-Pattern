using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    /// <summary>
    /// 单例模式的实现
    /// </summary>
    public class Singleton
    {
        // 定义一个私有的静态变量来保存类的实例
        private static Singleton uniqueInstance;

        public static Singleton Instance => lazy.Value;

        private static Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());

        // 定义一个私有的标识确保线程同步
        private static readonly object locker = new object();

        // 定义私有构造函数，使外界不能创建该类实例
        private Singleton()
        {
            Console.WriteLine("create");
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            //经典的"双if+lock"
            // 加锁之前先判断一次是否为空,可以避免重复等待解锁,然后加锁,提高了性能
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
