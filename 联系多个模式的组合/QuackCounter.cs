namespace 联系多个模式的组合
{

    /// <summary>
    /// 鸭子的装饰器,目的增加一个记录 叫了多少次 的功能,而不用修改鸭子类
    /// </summary>
    public class QuackCounter : IQuackable
    {
        public static int Count { get; private set; }

        private readonly IQuackable _quackable;

        public QuackCounter(IQuackable quackable)
        {
            _quackable = quackable;
        }

        public void Quack()
        {
            _quackable.Quack();
            Count++;
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyObserver()
        {
            throw new System.NotImplementedException();
        }
    }
}
