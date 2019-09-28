using System;
using System.Threading;

namespace 单例模式
{
    public class SingletonSecond
    {
        private static readonly SingletonSecond Singleton;
        private SingletonSecond()
        {

        }


        static SingletonSecond()
        {
            Singleton = new SingletonSecond();
            Console.WriteLine($"创造了一个 SingletonSecond 的实例,the thread_id is {Thread.CurrentThread.ManagedThreadId}");
        }


        public static SingletonSecond CreateSingletonSecond()
        {
            Console.WriteLine($" the thread_id is {Thread.CurrentThread.ManagedThreadId}  调用 CreateSingletonSecond 方法");
            return Singleton;
        }
    }
}
