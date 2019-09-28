using System;

namespace _09_装饰器模式
{
    /// <summary>
    /// 扫地装饰器
    /// </summary>
    public class CleanRobotDecorator : BaseRobotDecorator
    {
        public CleanRobotDecorator(BaseRobot robot) : base(robot) { }

        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine("我是一个机器人,我现在可以 扫地 了!");
        }
    }
}
