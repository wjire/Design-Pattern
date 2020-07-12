using System;
using System.Collections.Generic;

namespace _21_访问者模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            /*
             * 访问者模式是一种将数据操作和数据结构分离的设计模式.
             * 那么为什么要分离?
             * 我觉得,当不同情况下,对多种数据有不同的操作时,就可以分离.不分离的话,可能就需要些很多if-else
             * 这个设计模式的思想感觉和策略模式很相似,目的都是一样的,就是消除if-else,方便扩展.             *
             * 策略模式是封装策略,或者说封装算法,针对不同的情况采用不同的算法,但是,虽然算法(策略)不同,但是他们针对的是同一种数据.比如不同时期,商品A有不同的打折策略,那么这就是针对的是商品A这种数据.那如果在同一个时期,商品A和商品B的打折策略不一样呢?
             * 这种情况下,策略模式就没法应对了,当然,也可以解决,那就是在策略的具体行为中,if-else 来判断商品的具体实现是 A 还是 B.  
             * 当出现这种情况的时候,就该用访问者模式了.
             * 简单总结就是,不同时期,不同商品有不同的策略.
             *
             * 访问者模式通常适用于 数据结构 稳定的场景.不然,如果数据结构变了,都会引起每一个访问者的变化
               
             *
             * 比如下面的示例,Shape 类就两个子类.
             * 如果增加一个,那么意味着所有的访问者都要新增 Visit 方法的重载.
             * 因为 visit 方法的入参是实现类,而不是接口类.当然,这一点违背了依赖倒置原则
             * 所以需要数据结构稳定才行.
             */




            List<Shape> list = new List<Shape> { new Rectangle(2), new Circle(2) };
            Visitor1 v1 = new Visitor1();
            foreach (Shape shape in list)
            {
                shape.Accept(v1);
            }

            var v2 = new Visitor2();
            foreach (Shape shape in list)
            {
                shape.Accept(v2);
            }

            Console.ReadKey();
        }
    }



    public abstract class Shape
    {
        public abstract void Accept(ShapeVisitor visitor);
    }


    public class Rectangle : Shape
    {
        public double Width { get; set; }

        public Rectangle(double width)
        {
            Width = width;
        }

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    //抽象访问者 Visitor
    public abstract class ShapeVisitor
    {
        public abstract void Visit(Rectangle shape);

        public abstract void Visit(Circle shape);



        //这里有一点要说：Visit方法的参数可以写成Shape吗？就是这样 Visit(Shape shape)，当然可以，但是ShapeVisitor子类Visit方法就需要判断当前的Shape是什么类型，是Rectangle类型，是Circle类型，或者是Line类型。
    }


    //具体访问者 ConcreteVisitor
    public sealed class Visitor1 : ShapeVisitor
    {
        public override void Visit(Rectangle shape)
        {
            Console.WriteLine($"{shape.GetType().Name} 的周长是:" + shape.Width * 4);
        }

        public override void Visit(Circle shape)
        {
            Console.WriteLine($"{shape.GetType().Name} 的周长是:" + Math.PI * 2 * shape.Radius);
        }
    }

    public sealed class Visitor2 : ShapeVisitor
    {
        public override void Visit(Rectangle shape)
        {
            Console.WriteLine($"{shape.GetType().Name} 的面积是:" + shape.Width * shape.Width);
        }

        public override void Visit(Circle shape)
        {
            Console.WriteLine($"{shape.GetType().Name} 的面积是:" + Math.PI * shape.Radius * shape.Radius);
        }
    }
}
