using System;

namespace _04_抽象工厂
{
    public abstract class Plant
    {
        public abstract void Show();
    }


    public class Vegetables : Plant
    {
        public override void Show()
        {
            Console.WriteLine("蔬菜");
        }
    }


    public class Fruit : Plant
    {
        public override void Show()
        {
            Console.WriteLine("水果");
        }
    }
}