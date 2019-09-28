using System;

namespace _05_建造者模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //建造者模式强调 复杂对象由其多个子对象按照一定的步骤组合而成
            //将一个复杂对象的构造与他们的表示分离,使得同样的构建过程可以创建不同的表示

            Boss boss = new Boss(new Builder1());
            Computer computer = boss.BuildComputer();
            computer.Show();
            Console.ReadKey();
        }
    }
}
