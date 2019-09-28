using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_装饰器模式
{
    //具体的机器人类
    public class Robot : BaseRobot
    {
        public override void DoSomething()
        {
            Console.WriteLine("我是一个机器人,我现在什么都不会做!");
        }
    }
}
