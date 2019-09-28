using System.Collections.Generic;

namespace 联系多个模式的组合
{
    /// <summary>
    /// 鸭子可观察
    /// </summary>
    public interface IQuackObservable
    {
        void RegisterObserver(IObserver observer);
        void NotifyObserver();
    }


    /// <summary>
    /// 
    /// </summary>
    public class QuackObservable : IQuackObservable
    {
        private List<IObserver> _observers;

        private IQuackObservable _duck;

        public QuackObservable(IQuackObservable duck)
        {
            _duck = duck;
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObserver()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(_duck);
            }
        }
    }
}
