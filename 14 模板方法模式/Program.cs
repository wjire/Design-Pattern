using System;

namespace _14_模板方法模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* 模板方法模式是在一个抽象类中定义一个操作中的算法骨架（对应于生活中大家下载的模板），而将一些步骤延迟到子类中去实现（对应于我们根据自己的情况向模板填充内容）。
             * 模板方法使得子类可以不改变一个算法的结构前提下，重新定义算法的某些特定步骤，模板方法模式把不变行为搬到超类中，从而去除了子类中的重复代码。
             */

            Meat m = new PigMeat();
            m.CookMeat();
            Console.WriteLine("---------------");
            m = new CowMeat();
            m.CookMeat();
            Console.ReadKey();
        }
    }
}
