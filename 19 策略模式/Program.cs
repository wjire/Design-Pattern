using System;

namespace _19_策略模式
{

    /*
     * 所谓策略模式,就是针对策略的模式,那策略是什么?
     * 按照日常生活中的解释,策略就是规则,算法,处理方法等.
     * 用OO思想解释,策略就是行为.
     *
     * 日常生活中,策略往往会有很多,而我们需要在众多的策略中选择一种来执行,
     * 并且不同的环境下,我们选择的策略往往不一样,
     * 也就是说,我们选择的策略是会变的.
     * 而根据OO思想,我们需要将变化的地方独立出来,不能和那些不需要变化的代码混在一起.
     * 因此我们需要把策略,即变化的行为抽象出来.
     *
     *
     */
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TODO:这种简单的策略模式不够好,因为
            //1.客户端需要知道两个类,1)Context  2)ConcreteStrategyA
            //2.客户端依然需要选择是用 策略A 还是 策略B ,这种选择不应该让客户端去做.应该用工厂模式 策略类 的创建
            //Context context = new Context(new ConcreteStrategyA());


            //工厂+策略 的模式下,客户端只需要知道 Context 类,完全封装了算法类.但是依然不够完美
            //因为在 Context 类的构造函数中,使用了 switch ,这意味着如果增加了 策略是具体实现类,则需要修改代码,违反了开闭原则.
            //所以,最完美的是利用 抽象工厂(反射) + 策略.
            Context context = new Context(1);

            context.Calculate();
            Console.ReadKey();
        }
    }

    public class Context
    {
        private readonly IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public Context(int type)
        {
            switch (type)
            {
                case 1:
                    _strategy = new ConcreteStrategyA();
                    return;
                case 2:
                    _strategy = new ConcreteStrategyB();
                    return;
            }
        }


        public void Calculate()
        {
            _strategy.Execute();
        }
    }

    public interface IStrategy
    {
        void Execute();
    }


    public class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("算法A");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("算法B");
        }
    }
}
