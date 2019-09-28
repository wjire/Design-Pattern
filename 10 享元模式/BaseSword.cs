using System;

namespace _10_享元模式
{

    /// <summary>
    /// 抽象享元角色
    /// </summary>
    public abstract class BaseSword
    {
        public abstract void Hit(UnShare unShare);
    }

    public class WoodSword : BaseSword
    {
        public WoodSword()
        {
            Console.WriteLine("制造了一把木剑");
        }

        public override void Hit(UnShare unShare)
        {
            Console.WriteLine(unShare.GetInfo());
        }
    }

    public class IronSword : BaseSword
    {
        public IronSword()
        {
            Console.WriteLine("制造了一把铁剑");
        }
        public override void Hit(UnShare unShare)
        {
            Console.WriteLine(unShare.GetInfo());
        }
    }

    public class MagicSword : BaseSword
    {
        public MagicSword()
        {
            Console.WriteLine("制造了一把魔剑");
        }
        public override void Hit(UnShare unShare)
        {
            Console.WriteLine(unShare.GetInfo());
        }
    }
}
