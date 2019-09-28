using System;
using System.Collections.Generic;

namespace _15_命令模式
{
    /// <summary>
    /// 命令模式 与 组合模式 结合 实现宏命令
    /// </summary>
    public class Test
    {
        public static void TestCommand_Component()
        {
            PingPan pp = new PingPan();
            pp.Add(new Baozi());
            pp.Add(new LiangFen());
            pp.Cooking();
        }
    }

    public abstract class Food
    {
        public abstract void Cooking();
    }

    public class LiangFen : Food
    {
        private ChuSi chusi = new LiangFenChuSi();

        public override void Cooking()
        {
            chusi.Cooking();
        }
    }

    public class Baozi : Food
    {
        private ChuSi chusi = new BaoziChuSi();

        public override void Cooking()
        {
            chusi.Cooking();
        }
    }

    public abstract class ChuSi
    {
        public abstract void Cooking();
    }


    public class LiangFenChuSi : ChuSi
    {
        public override void Cooking()
        {
            Console.WriteLine("做凉粉");
        }
    }

    public class BaoziChuSi : ChuSi
    {
        public override void Cooking()
        {
            Console.WriteLine("做包子");
        }
    }



    public class PingPan : Food
    {
        private List<Food> foods = new List<Food>();

        public void Add(Food food)
        {
            foods.Add(food);
        }

        public override void Cooking()
        {
            foreach (Food food in foods)
            {
                food.Cooking();
            }
        }
    }
}
