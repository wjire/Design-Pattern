namespace 联系多个模式的组合
{

    /// <summary>
    /// 统计鸭子叫了多少次的装饰者的抽象工厂
    /// </summary>
    public abstract class AbstractDuckFactory
    {
        public abstract IQuackable CreateMallardDuck();
        public abstract IQuackable CreateRedheadDuck();

        public abstract IQuackable CreateDuckCall();

        public abstract IQuackable CreateRubberDuc();
    }



    public class CountingDuckFactory : AbstractDuckFactory
    {
        public override IQuackable CreateMallardDuck()
        {
            return new QuackCounter(new MallardDuck());
        }

        public override IQuackable CreateRedheadDuck()
        {
            return new QuackCounter(new RedheadDuck());
        }

        public override IQuackable CreateDuckCall()
        {
            return new QuackCounter(new DuckCall());
        }

        public override IQuackable CreateRubberDuc()
        {
            return new QuackCounter(new RubberDuck());
        }
    }
}
