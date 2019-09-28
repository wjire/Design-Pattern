using System;

namespace _15_命令模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Receiver 命令的接受者:具体干活的角色
             * BaseCommand  命令角色:需要执行的命令类
             * Invoker  命令调用者
             * 
             * 优点:
             * 1.命令的发送者和命令的接受者实现了松耦合;
             * 2.命令可以随时扩展,只要继承 BaseCommand 即可;
             * 3.还可以撤销和恢复命令
             *
             *
             * 加入使用"聪明"的命令对象,也就是说没有命令接收者,而是在命令对象中,直接实现了请求,
             * 那么就和平时最常用的 Handler 一样了.
             */
             
            /*
             * 感觉是 调用者组合命令者
             * 命令者组合接受者
             * 从而实现调用者和接受者的解耦
             *
             * 感觉印证了那句话,能通过技术解决的问题,都可以通过包一层来解决.
             *
             *
             * 命令模式就好像是书记喊口号,他不管谁去做,怎么做,反正有人做就对了.
             * 
             */

            //Receiver student = new Student();
            //BaseCommand cmd1 = new ConcreteCommand1(student);
            //Invoker invoker = new Invoker(cmd1);
            //invoker.Action();

            //Receiver teacher = new Teacher();
            //BaseCommand cmd2 = new ConcreteCommand2(teacher);
            //invoker = new Invoker(cmd2);
            //invoker.Action();


            //用顾客点餐模拟 命令模式 + 组合模式
            //Test.TestCommand_Component();

            var cmdInvoker = new CommandInvoker(new Command1(new CommandReceiver1()));
            cmdInvoker.Do();

            Console.ReadKey();
        }
    }









}
