using System;

namespace 联系多个模式的组合
{
    public interface IQuackable : IQuackObservable
    {
        void Quack();
    }


    public class MallardDuck : IQuackable
    {
        private readonly IQuackObservable _quackObservable;
        public MallardDuck()
        {
            _quackObservable = new QuackObservable(this);
        }

        public void Quack()
        {
            Console.WriteLine("quack");
            NotifyObserver();
        }

        public void RegisterObserver(IObserver observer)
        {
            _quackObservable.RegisterObserver(observer);
        }

        public void NotifyObserver()
        {
            _quackObservable.NotifyObserver();
        }
    }

    public class RedheadDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("quack");
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void NotifyObserver()
        {
            throw new NotImplementedException();
        }
    }


    public class DuckCall : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("kwak");
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void NotifyObserver()
        {
            throw new NotImplementedException();
        }
    }

    public class RubberDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("squeak");
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void NotifyObserver()
        {
            throw new NotImplementedException();
        }
    }
}
