using System;

namespace _08_桥接模式
{
    public static class Test
    {
        public static void TestBridge()
        {
            Color color = new Blue();
            Bag bag = new PlasticBag();
            bag.SetColor(color);
            bag.GetName();

        }
    }



    /*
     * 模拟女性买包,包可以按颜色分,可以按材质分
     * 比如,有红色,蓝色;有牛皮,塑料.
     * 那么现在尝试买一个 红色的塑料 包.
     * 将来还有可能增加 黄色包,鳄鱼皮包
     */

    public abstract class Color
    {
        public abstract string GetColor();
    }

    public abstract class Bag
    {
        protected Color Color;

        public virtual void SetColor(Color color)
        {
            Color = color;
        }

        public abstract void GetName();
    }


    public class Red : Color
    {
        public override string GetColor()
        {
            return "red";
        }
    }

    public class Blue : Color
    {
        public override string GetColor()
        {
            return "blue";
        }
    }

    public class CowBag : Bag
    {
        public override void GetName()
        {
            Console.WriteLine($"{Color.GetColor()}牛皮包");
        }
    }

    public class PlasticBag : Bag
    {
        public override void GetName()
        {
            Console.WriteLine($"{Color.GetColor()}塑料包");
        }
    }
}
