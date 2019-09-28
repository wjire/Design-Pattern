using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_装饰器模式
{
    /// <summary>
    /// 发邮件装饰器
    /// </summary>
    public class EmailRobotDecorator : BaseRobotDecorator
    {
        public EmailRobotDecorator(BaseRobot robot) : base(robot)
        {
        }
        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine("我是一个机器人,我现在可以 发邮件 了!");
        }
    }
}
