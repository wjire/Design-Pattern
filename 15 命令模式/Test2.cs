using System;
using System.Collections.Generic;

namespace _15_命令模式
{

    public class CommandInvoker
    {
        private readonly ICommand _cmd;

        public CommandInvoker(ICommand cmd)
        {
            _cmd = cmd;
        }

        public void Do()
        {
            _cmd.Execute();
        }
    }




    public interface ICommand
    {
        void Execute();//执行
        void Undo();//撤销
    }


    public abstract class CommandReceiver
    {
        public abstract void DoSomething();
    }


    public class Command1 : ICommand
    {
        private readonly CommandReceiver _receiver;

        public Command1(CommandReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.DoSomething();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 宏命令,一次可以执行多个命令
    /// </summary>
    public class MultiCommand : ICommand
    {
        private readonly ICommand[] _commands;
        private readonly Stack<ICommand> _cmdStack = new Stack<ICommand>();
        public MultiCommand(ICommand[] commands)
        {
            _commands = commands;
        }

        public void Execute()
        {
            for (int i = 0; i < _commands.Length; i++)
            {
                ICommand cmd = _commands[i];
                cmd.Execute();
                _cmdStack.Push(cmd);
            }
        }

        public void Undo()
        {
            while (_cmdStack.Count > 0)
            {
                ICommand cmd = _cmdStack.Pop();
                cmd.Undo();
            }
        }
    }


    public class CommandReceiver1 : CommandReceiver
    {
        public override void DoSomething()
        {
            Console.WriteLine("我是接受者1");
        }
    }
}
