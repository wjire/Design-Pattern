using System;

namespace _04_抽象工厂
{
    public abstract class Animal
    {
        public abstract void Show();
    }

    public class Cow : Animal
    {
        public override void Show()
        {
            Console.WriteLine("牛牛");
        }
    }

    public class Horse : Animal
    {
        public override void Show()
        {
            Console.WriteLine("马儿");
        }
    }
    
}