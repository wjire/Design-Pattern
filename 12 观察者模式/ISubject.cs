using System.Collections.Generic;

namespace _12_观察者模式
{
    public interface ISubject
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObserver();
    }


    public interface IObserver
    {
        void Update(float temp, float hum, float pre);
    }


    public class WeatherData : ISubject
    {
        //这是多用组合,少用继承的体现
        private readonly List<IObserver> _observers = new List<IObserver>();
        private float _temp;
        private float _hum;
        private float _pre;


        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObserver()
        {
            _observers.ForEach(f => f.Update(_temp, _hum, _pre));
        }


        public void DataChanged()
        {
            NotifyObserver();
        }
    }


    public class Observer1 : IObserver
    {
        //这是多用组合,少用继承的体现
        private readonly ISubject _sub;

        public Observer1(ISubject sub)
        {
            _sub = sub;
            _sub.AddObserver(this);
        }


        public void UnRegister()
        {
            _sub.RemoveObserver(this);
        }


        public void Update(float temp, float hum, float pre)
        {
            throw new System.NotImplementedException();
        }
    }
}
