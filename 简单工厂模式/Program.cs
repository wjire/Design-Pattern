using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 简单工厂 不属于 23种设计模式
             *
             */

            Food food = Factory.Cook();
            food?.Print();

            Console.ReadKey();
        }
    }
}
