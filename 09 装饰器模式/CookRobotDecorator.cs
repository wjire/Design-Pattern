using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_装饰器模式
{
    /// <summary>
    /// 做饭装饰器
    /// </summary>
    public class CookRobotDecorator : BaseRobotDecorator
    {
        public CookRobotDecorator(BaseRobot robot) : base(robot)
        {
        }
        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine("我是一个机器人,我现在可以 做好吃的 了!");
        }
    }
}
