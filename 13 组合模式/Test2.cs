using System;
using System.Collections.Generic;
using System.Linq;

namespace _13_组合模式
{
    /// <summary>
    /// 用购物车来测试 透明的 组合模式
    /// </summary>
    public class Test2
    {
        public static void TestCom()
        {
            Article bigBag = new Bag("大袋子");
            Article midBag = new Bag("中袋子");
            Article smaBag = new Bag("小袋子");

            bigBag.Add(new Goods("苹果", 10, 1));
            bigBag.Add(new Goods("葡萄", 4, 3));

            midBag.Add(new Goods("手机", 1770, 1));
            midBag.Add(new Goods("ipad", 4000, 1));

            smaBag.Add(new Goods("烟", 200, 1));

            bigBag.Add(midBag);
            bigBag.Add(smaBag);
            bigBag.Show();
            Console.WriteLine(bigBag.Calculate());
        }
    }



    /// <summary>
    /// 物品
    /// </summary>
    public abstract class Article
    {
        public string Name { get; set; }

        protected Article(string name)
        {
            Name = name;
        }

        public abstract void Show();

        public abstract decimal Calculate();

        public abstract void Add(Article article);

        public abstract void Remove(Article article);

        public abstract Article GetArticle(string name);
    }


    public class Goods : Article, IEquatable<Goods>
    {

        public decimal Price { get; set; }

        public int Count { get; set; }

        public Goods(string name, decimal price, int count) : base(name)
        {
            Price = price;
            Count = count;
        }

        public override void Show()
        {
            Console.WriteLine($"{Price} 买了 {Count} 个 {Name}");
        }

        public override decimal Calculate()
        {
            return Price * Count;
        }

        public override void Add(Article article)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Article article)
        {
            throw new NotImplementedException();
        }

        public override Article GetArticle(string name)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Goods other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Goods)obj);
        }

        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }
    }



    public class Bag : Article
    {
        private List<Article> goodsList = new List<Article>();


        public Bag(string name) : base(name)
        {
        }


        public override void Add(Article goods)
        {
            goodsList.Add(goods);
        }

        public override void Remove(Article goods)
        {
            goodsList.Remove(goods);
        }

        public override Article GetArticle(string name)
        {
            return goodsList.Find(f => f.Name == name);
        }

        public override void Show()
        {
            goodsList.ForEach(f=>f.Show());
        }

        public override decimal Calculate()
        {
            decimal sum = goodsList.Sum(s => s.Calculate());
            return sum;
        }
    }
}
