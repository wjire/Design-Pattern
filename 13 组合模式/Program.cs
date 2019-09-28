using System;
using System.Collections.Generic;

namespace _13_组合模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //安全的组合模式
            //Test.TestCom();

            //透明的组合模式
            Test2.TestCom();


            //学习
            //           {
            //               /*   
            //* 组合模式的核心是:简单对象和复杂对象必须实现统一的接口
            //* 组合模式有两种分支:
            //* 1.透明的组合模式 : 方法全部公开,但在简单对象实际不支持的方法中,主动抛出异常
            //* 2.安全的组合模式 : 只公开各自支持的方法 
            //*/

            //               Graphics line1 = new Line("直线1");
            //               Graphics circle1 = new Circle("圆1");

            //               Graphics line2 = new Line("直线2");
            //               Graphics circle2 = new Circle("圆2");

            //               //透明的组合模式构造复杂图形
            //               //Graphics complexGraphics = new Complex("复杂图形");
            //               //complexGraphics.Add(line2);
            //               //complexGraphics.Add(circle2);
            //               //complexGraphics.Add(new Line("直线3"));
            //               //complexGraphics.Remove(line2);

            //               //安全的组合模式, 构造复杂图形就不能再用 基类了,因为Add Remove 方法是 子类 Complex 特有的,不是 基类 Graphics 的
            //               Complex complexGraphics = new Complex("复杂图形");
            //               complexGraphics.Add(line2);
            //               complexGraphics.Add(circle2);
            //               complexGraphics.Add(new Line("直线3"));
            //               complexGraphics.Remove(line2);


            //               line1.Draw();
            //               circle1.Draw();
            //               Console.WriteLine("*********复杂图形绘制方法********");
            //               complexGraphics.Draw();

            //               //调用 简单图形的 Add,Remove 方法 ,编译会报错,所以说是 安全的组合模式
            //               //line1.Add(new Line("直线4"));
            //           }

            Console.ReadKey();
        }


        /// <summary>
        /// 基类
        /// </summary>
        public abstract class Graphics
        {
            public string Name { get; set; }
            protected Graphics(string name)
            {
                Name = name;
            }
            public abstract void Draw();

            //从基类中移除 复杂图形 特有的方法
            //public abstract void Add(Graphics g);
            //public abstract void Remove(Graphics g);
        }


        /// <summary>
        /// 简单图形: 直线
        /// </summary>
        public class Line : Graphics
        {
            public Line(string name) : base(name)
            {
            }

            public override void Draw()
            {
                Console.WriteLine($"画了一个简单图形:{Name}");
            }

            //public override void Add(Graphics g)
            //{
            //    throw new Exception("无法向简单图形:直线中添加其他图形");
            //}

            //public override void Remove(Graphics g)
            //{
            //    throw new Exception("无法从简单图形:直线中移除其他图形");
            //}
        }

        /// <summary>
        /// 简单图形: 圆
        /// </summary>
        public class Circle : Graphics
        {
            public Circle(string name) : base(name)
            {
            }

            public override void Draw()
            {
                Console.WriteLine($"画了一个简单图形:{Name}");
            }

            //public override void Add(Graphics g)
            //{
            //    throw new Exception("无法向简单图形:圆中添加其他图形");
            //}

            //public override void Remove(Graphics g)
            //{
            //    throw new Exception("无法从简单图形:圆中移除其他图形");
            //}
        }

        /// <summary>
        /// 复杂图形
        /// </summary>
        public class Complex : Graphics
        {
            private List<Graphics> _graphicsList;
            public Complex(string name) : base(name)
            {
                _graphicsList = new List<Graphics>();
            }

            public override void Draw()
            {
                _graphicsList.ForEach(f => f.Draw());
            }

            public void Add(Graphics g)
            {
                _graphicsList.Add(g);
            }

            public void Remove(Graphics g)
            {
                _graphicsList.Remove(g);
            }

            //public override void Add(Graphics g)
            //{
            //    _graphicsList.Add(g);
            //}

            //public override void Remove(Graphics g)
            //{
            //    _graphicsList.Remove(g);
            //}
        }
    }
}
