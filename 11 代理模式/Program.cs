using System;

namespace _11_代理模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            /*
             *
             * 代理模式的应用场景
远程代理，这种方式通常是为了隐藏目标对象存在于不同地址空间的事实，方便客户端访问。例如，用户申请某些网盘空间时，会在用户的文件系统中建立一个虚拟的硬盘，用户访问虚拟硬盘时实际访问的是网盘空间。
虚拟代理，这种方式通常用于要创建的目标对象开销很大时。例如，下载一幅很大的图像需要很长时间，因某种计算比较复杂而短时间无法完成，这时可以先用小比例的虚拟代理替换真实的对象，消除用户对服务器慢的感觉。
安全代理，这种方式通常用于控制不同种类客户对真实对象的访问权限。
智能指引，主要用于调用目标对象时，代理附加一些额外的处理功能。例如，增加计算真实对象的引用次数的功能，这样当该对象没有被引用时，就可以自动释放它。
延迟加载，指为了提高系统的性能，延迟对目标的加载。例如，Hibernate 中就存在属性的延迟加载和关联表的延时加载。
             */


            /* 
             * 核心是:代理类和真实类继承同一个基类
             * 只要是技术问题,都可以通过加一层来解决;如果解决不了,那就再加一层:)
             * 代理模式隐藏了真实类,并且利用延迟加载思想.
             * 业务逻辑写在真实类中,代理类里面可以扩展一些额外的功能,比如日志代理,缓存代理,延迟代理,权限代理等.
             */

            //Person proxyPerson = new ProxyPerson();
            //proxyPerson.BuyTicket();

            var proxy = new ProxyImage();
            proxy.Paint();
            Console.ReadKey();
        }
    }

    //抽象类
    public abstract class Person
    {
        public abstract void BuyTicket();
    }

    //真实类
    public class BuyerPerson : Person
    {
        public override void BuyTicket()
        {
            Console.WriteLine("买票!");
        }
    }

    //代理类
    public class ProxyPerson : Person
    {
        /// <summary>
        /// 被代理的真实类(这里是和装饰器模式最大的区别,装饰器组合的是接口类,而不是真实类,所以这也意味着真实类和代理类一一对应,并且真实类必须提前存在,才可能会有代理类)
        /// </summary>
        private BuyerPerson _buyerPerson;

        public override void BuyTicket()
        {
            if (_buyerPerson == null)
            {
                _buyerPerson = new BuyerPerson();
            }
            PreBuy();
            _buyerPerson.BuyTicket();
            AfterBuy();
        }

        //在主业务逻辑之外扩展的功能
        public void PreBuy()
        {
            Console.WriteLine("买票前的准备工作");
        }
        public void AfterBuy()
        {

            Console.WriteLine("买完票后干的事");
        }
    }
}
