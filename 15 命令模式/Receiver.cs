using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_命令模式
{
    /// <summary>
    /// 接受命令者的基类
    /// </summary>
    public abstract class Receiver
    {
        //每一位接受者,收到不同命令,需要做不同的事
        public abstract void DoSomething();
    }

    /// <summary>
    /// 接受命令者
    /// </summary>
    public class Student : Receiver
    {
        public override void DoSomething()
        {
            Console.WriteLine("学生收到命令,开始长跑10000");
        }
    }

    /// <summary>
    /// 接收命令者
    /// </summary>
    public class Teacher : Receiver
    {
        public override void DoSomething()
        {
            Console.WriteLine("老师收到命令,开始备课");
        }
    }
}
