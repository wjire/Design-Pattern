using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_命令模式
{
    /// <summary>
    /// 命令的基类
    /// </summary>
    public abstract class BaseCommand
    {
        public abstract void Execute();
    }

    /// <summary>
    /// 具体命令类
    /// </summary>
    public class ConcreteCommand1 : BaseCommand
    {
        private readonly Receiver _receiver;

        public ConcreteCommand1(Receiver receiver)
        {
            this._receiver = receiver;
        }

        public override void Execute()
        {
            this._receiver.DoSomething();
        }
    }

    /// <summary>
    /// 具体命令类
    /// </summary>
    public class ConcreteCommand2 : BaseCommand
    {
        private readonly Receiver _receiver;

        public ConcreteCommand2(Receiver receiver)
        {
            this._receiver = receiver;
        }

        public override void Execute()
        {
            this._receiver.DoSomething();
        }
    }

}
