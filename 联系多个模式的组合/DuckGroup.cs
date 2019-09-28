using System.Collections.Generic;

namespace 联系多个模式的组合
{

    /// <summary>
    /// 鸭子的组合模式+迭代器
    /// </summary>
    public class DuckGroup : IQuackable
    {

        private List<IQuackable> _ducks;

        public void AddDuck(IQuackable quackable)
        {
            _ducks.Add(quackable);
        }
        
        public void Quack()
        {
            foreach (IQuackable duck in _ducks)
            {
                duck.Quack();
            }
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
