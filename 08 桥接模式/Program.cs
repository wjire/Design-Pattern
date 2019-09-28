using System;

namespace _08_桥接模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            /*
             *桥接模式的应用场景
            桥接模式通常适用于以下场景。
            当一个类存在两个独立变化的维度，且这两个维度都需要进行扩展时。
            当一个系统不希望使用继承或因为多层次继承导致系统类的个数急剧增加时。
            当一个系统需要在构件的抽象化角色和具体化角色之间增加更多的灵活性时。
             *
             */




            ////将抽象部分与实现部分解耦
            //Cup large = new Large();
            //Coffee coffee = new BlackCoffee(){ Cup = large};
            //coffee.MakeCoffee();

            //测试
            Test.TestBridge();


            Console.ReadKey();
        }
    }


    public abstract class Cup
    {
        public abstract void GetCup();
    }


    public abstract class Coffee
    {
        public Cup Cup { get; set; }

        public virtual void MakeCoffee()
        {
            Cup.GetCup();
            Making();
        }

        protected abstract void Making();
    }


    public class BlackCoffee : Coffee
    {
        protected override void Making()
        {
            Console.WriteLine("原味咖啡");
        }
    }

    public class BananaCoffee : Coffee
    {
        protected override void Making()
        {
            Console.WriteLine("香蕉咖啡");
        }
    }

    public class Large : Cup
    {
        public override void GetCup()
        {
            Console.WriteLine("大杯");
        }
    }

    public class Small : Cup
    {
        public override void GetCup()
        {
            Console.WriteLine("小杯");
        }
    }
}
