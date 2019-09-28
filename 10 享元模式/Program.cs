using System;

namespace _10_享元模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             *
             *享元模式的应用场景
                前面分析了享元模式的结构与特点，下面分析它适用的应用场景。享元模式是通过减少内存中对象的数量来节省内存空间的，所以以下几种情形适合采用享元模式。
                系统中存在大量相同或相似的对象，这些对象耗费大量的内存资源。
                大部分的对象可以按照内部状态进行分组，且可将不同部分外部化，这样每一个组只需保存一个内部状态。
                由于享元模式需要额外维护一个保存享元的数据结构，所以应当在有足够多的享元实例时才值得使用享元模式。
             *
             *
             */
             

            /* 感觉享元模式就像是简单工厂+单例
             * 单例:在类的内部进行控制,实现唯一的实例,外部无法创建对象
             * 享元:在类的外部进行控制,如果想创建,依然可以new一个新的对象,扩展性更好
             *
             * 另外,不能共享的部分,则可以通过参数的方式注入到享元的相应方法中.
             */

            //{
            //    BaseSword sword = SwordFactory.CreateSword(SwordEnum.木剑);
            //    sword.Hit(new UnShare("敌人掉了5hp"));
            //}
            //{ BaseSword sword = SwordFactory.CreateSword(SwordEnum.木剑); }
            //{ BaseSword sword = SwordFactory.CreateSword(SwordEnum.木剑); }
            //{ BaseSword sword = SwordFactory.CreateSword(SwordEnum.木剑); }

            //{
            //    BaseSword sword = SwordFactory.CreateSword(SwordEnum.铁剑);
            //    sword.Hit(new UnShare("敌人掉了10hp"));

            //}
            //{ BaseSword sword = SwordFactory.CreateSword(SwordEnum.铁剑); }

            //测试 Lazy
            {
                BaseSword sword = SwordFactory.GetSword(SwordEnum.木剑);
                sword.Hit(new UnShare("敌人掉了5hp"));
            }
            { BaseSword sword = SwordFactory.GetSword(SwordEnum.木剑); }
            { BaseSword sword = SwordFactory.GetSword(SwordEnum.木剑); }
            { BaseSword sword = SwordFactory.GetSword(SwordEnum.木剑); }

            {
                BaseSword sword = SwordFactory.GetSword(SwordEnum.铁剑);
                sword.Hit(new UnShare("敌人掉了10hp"));

            }
            { BaseSword sword = SwordFactory.GetSword(SwordEnum.铁剑); }


            Console.ReadKey();
        }
    }
}
