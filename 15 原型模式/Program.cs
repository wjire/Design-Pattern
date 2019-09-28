using System;

namespace _15_原型模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 原型模式

            Prototype pro1 = Prototype.CreatePrototype();
            Prototype pro2 = Prototype.CreatePrototype();
            Console.WriteLine($"pro1.Id={pro1.Id}");
            Console.WriteLine($"pro1.Name={pro1.Name}");
            Console.WriteLine($"{pro1.Student.Id}");

            Console.WriteLine($"pro2.Id={pro2.Id}");
            Console.WriteLine($"pro2.Name={pro2.Name}");
            Console.WriteLine($"{pro2.Student.Id}");

            pro1.Id = 666;
            pro1.Name = "xxxxxxxxxxx";
            pro1.Student.Id = 222;

            Console.WriteLine($"pro1.Id={pro1.Id}");
            Console.WriteLine($"pro1.Name={pro1.Name}");
            Console.WriteLine($"{pro1.Student.Id}");

            Console.WriteLine($"pro2.Id={pro2.Id}");
            Console.WriteLine($"pro2.Name={pro2.Name}");
            Console.WriteLine($"{pro2.Student.Id}"); //这里 显示的和 pro1 一样,证明了原型模式(MemberwiseClone()方法)是浅拷贝.pro1.Id和Name 不变是因为,一个是值类型,一个是字符串(字符串虽然是引用类型,但是比较特殊,它是不可变的)

            #endregion
            ;
            Console.ReadKey();
        }
    }
}
