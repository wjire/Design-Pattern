using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_中介者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //BasePlayer a = new BasePlayerA(50);
                //BasePlayer b = new BasePlayerB(100);
                //BaseMediator m = new ConcreteBaseMediator();
                //m.AddPlayer(a);
                //m.AddPlayer(b);
                //a.Win(20, m);
                //Console.WriteLine(a.Money);//70
                //Console.WriteLine(b.Money);//80

                ////c 加入进来
                //BasePlayer c = new BasePlayerC(200);
                //m.AddPlayer(c);

                //b.Win(140, m);
                //Console.WriteLine(a.Money);//0
                //Console.WriteLine(b.Money);//220
                //Console.WriteLine(c.Money);//130

                ////a 输完了,走了,b,c继续玩
                //m.RemovePlayer(a);

                //c.Win(220, m);
                //Console.WriteLine(b.Money);//0
                //Console.WriteLine(c.Money);//350
            }

            //测试2
            {
                Test.TestMediator();
            }

            Console.ReadKey();
        }
    }
    





}
