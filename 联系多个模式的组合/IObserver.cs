using System;

namespace 联系多个模式的组合
{
    //观察者
    public interface IObserver
    {
        void Update(IQuackObservable duck);
    }


    public class Quackologist : IObserver
    {
        public void Update(IQuackObservable duck)
        {
            Console.WriteLine("Quackologist : " + duck + "just quacked");
        }
    }
}
