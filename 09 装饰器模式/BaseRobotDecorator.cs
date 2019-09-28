namespace _09_装饰器模式
{



  
    public abstract class BaseRobotDecorator : BaseRobot
    {
        private readonly BaseRobot _robot;

        protected BaseRobotDecorator(BaseRobot robot)
        {
            _robot = robot;
        }

        public override void DoSomething()
        {
            _robot.DoSomething();
        }
    }
}
