using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public interface Food
    {
         void Print();
    }


    public class Ou : Food
    {
        public void Print()
        {
            Console.WriteLine("一份藕片");
        }
    }

    public class Tudou : Food
    {
        public void Print()
        {
            Console.WriteLine("一份土豆");
        }
    }
}
