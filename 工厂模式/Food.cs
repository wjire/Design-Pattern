using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法模式
{
    public abstract class Food
    {
        public abstract void Print();
    }


    public class Ou : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份藕片");
        }
    }

    public class Tudou : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份土豆");
        }
    }
}
