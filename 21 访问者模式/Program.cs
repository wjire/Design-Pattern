using System;
using System.Collections.Generic;

namespace _21_访问者模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            /*
             * 访问者模式通常适用于 数据结构 稳定的场景.
             * 比如下面的示例,Shape 类就两个子类.
             * 如果增加一个,那么意味着所有的访问者都要新增 Visit 方法的重载.
             * 因为 visit 方法的入参是实现类,而不是接口类.当然,这一点违背了依赖倒置原则
             * 所以需要数据结构稳定才行.
             */




            List<Shape> list = new List<Shape>();
            list.Add(new Rectangle());
            list.Add(new Circle());
            Visitor1 virtor = new Visitor1();
            foreach (Shape shape in list)
            {
                shape.Accept(virtor);
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

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    public class Circle : Shape
    {
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
            Console.WriteLine("访问者1针对Rectangle的操作！");
        }

        public override void Visit(Circle shape)
        {
            Console.WriteLine("访问者1针对Circle的操作！");
        }
    }

    public sealed class Visitor2 : ShapeVisitor
    {
        public override void Visit(Rectangle shape)
        {
            Console.WriteLine("访问者2针对Rectangle的操作！");
        }

        public override void Visit(Circle shape)
        {
            Console.WriteLine("访问者2针对Circle的操作！");
        }
    }
}
