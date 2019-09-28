using System;
using System.Threading;
using System.Threading.Tasks;
using 单例模式;

namespace _01_单例模式
{
    /*
     *
     * 什么情况下需要使用单例,我的理解是:
     * 当一个类没有任何字段或者属性的时候就可以使用单例.
     * 因为没有字段和属性,意味着每个实例其实都一样,它们没有状态的区别,都仅仅是拥有相同的行为而已.
     */
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => Singleton.Instance);
            }

            //Singleton singleton1 = Singleton.GetInstance();

            int x = 1;
            int y = Interlocked.Exchange(ref x, 123);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.ReadKey();
        }
    }
}
