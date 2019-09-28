using System;
using System.Collections.Generic;

namespace _12_观察者模式
{

    /*
     * 观察者模式定义了对象之间的一对多依赖关系.
     * 当一个对象改变状态时,它的所有依赖者都会收到通知并自动更新
     *
     */

    internal class Program
    {
        private static void Main(string[] args)
        {
            {
                Console.WriteLine("**************集合方式的观察者模式***************");

                Cat cat = new Cat();
                cat.AddObserver(new Dog());
                cat.AddObserver(new Father());
                cat.AddObserver(new Baby());
                cat.Miao();
            }

            {
                Console.WriteLine("**************事件方式的观察者模式***************");
                Cat cat = new Cat();
                cat.CatMiaoEvent += new Dog().Wang;
                cat.CatMiaoEvent += new Father().Paoxiao;
                cat.CatMiaoEvent += new Baby().Cry;
                cat.MiaoEvent();
            }

            Console.ReadKey();
        }
    }

    public class Cat
    {
        //集合方式
        private readonly List<ITestObserver> ObserverList = new List<ITestObserver>();

        //事件方式
        public event Action CatMiaoEvent;

        public void AddObserver(ITestObserver testObserver)
        {
            ObserverList.Add(testObserver);
        }

        public void RemoveObserver(ITestObserver testObserver)
        {
            ObserverList.Remove(testObserver);
        }

        public void Miao()
        {
            Console.WriteLine("猫咪喵了一声");
            ObserverList.ForEach(f => f.Action());
        }

        public void MiaoEvent()
        {
            Console.WriteLine("猫咪喵了一声");
            CatMiaoEvent?.Invoke();
        }
    }

    public interface ITestObserver
    {
        void Action();
    }

    public class Father : ITestObserver
    {
        public void Paoxiao()
        {
            Console.WriteLine("爸爸大吼一声");
        }

        public void Action()
        {
            Paoxiao();
        }
    }

    public class Baby : ITestObserver
    {
        public void Cry()
        {
            Console.WriteLine("小孩哭了");
        }

        public void Action()
        {
            Cry();
        }
    }

    public class Dog : ITestObserver
    {
        public void Wang()
        {
            Console.WriteLine("狗狗汪了一声");
        }

        public void Action()
        {
            Wang();
        }
    }
}

