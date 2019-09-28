using System;
using _07_原型模式;

namespace _07_适配器模式
{
    internal class Program
    {
        /*
         * 所谓适配器模式,就是用一个中间件来对接两个不同的接口;
         * 既然是对接,就涉及到主动的一方和被动的一方.
         * 被动的一方通常叫做被适配的一方,
         * 既然主动方要"配合"被动方,那就得伪装一下,
         * 正所谓,能用技术办法解决的问题,都可以通过包一层解决.
         * 所以,我们可以将主动方包装在一个适配器里面,让适配器去实现被动方的行为.
         * 当然了,在具体的行为实现里面,实际干的是自己的行为.只是被动方不知道而已.
         *
         * 在 简单点说就是,将主动方封装成一个继承自被动方的适配器.
         *
         * 缺点:
         * 被动方有多少行为,适配器就必须实现多少行为.
         * 
         */

        private static void Main(string[] args)
        {
            //双向适配器测试
            Test.TestTwoAdapter();

            Console.ReadKey();
        }
    }


    public interface IA
    {
        void MethodA();
    }

    public interface IB
    {
        void MethodB();
    }

    //对象的适配器,利用组合
    public class ObjectAdapter : IA
    {
        private readonly IB _b;//由于采用的是组合的方式,所以这个适配器可用适配所有IB的实现类,灵活性大增

        public ObjectAdapter(IB b)
        {
            _b = b;
        }

        public void MethodA()
        {
            _b.MethodB();
        }
    }
}
