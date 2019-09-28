using System;

namespace _07_原型模式
{
    /// <summary>
    /// 测试双向适配器
    /// </summary>
    public static class Test
    {

        public static void TestTwoAdapter()
        {
            TwoWayAdapter twoWayAdapter = new TwoWayAdapter(new Adapter());
            twoWayAdapter.TargetMethod();
            twoWayAdapter = new TwoWayAdapter(new Target());
            twoWayAdapter.AdapterMethod();
        }
    }

    //目标接口
    public interface ITarget
    {
        void TargetMethod();
    }

    //被适配者接口
    public interface IAdapter
    {
        void AdapterMethod();
    }

    //目标实现
    public class Target : ITarget
    {
        public void TargetMethod()
        {
            Console.WriteLine("目标实现被调用");
        }
    }


    //被适配者实现
    public class Adapter : IAdapter
    {
        public void AdapterMethod()
        {
            Console.WriteLine("被适配者被调用");
        }
    }

    //双向适配器
    public class TwoWayAdapter : IAdapter, ITarget
    {
        private readonly IAdapter _adapter;
        private readonly ITarget _target;

        public TwoWayAdapter(IAdapter ada)
        {
            _adapter = ada;
        }

        public TwoWayAdapter(ITarget tar)
        {
            _target = tar;
        }


        public void AdapterMethod()
        {
            _target?.TargetMethod();
        }

        public void TargetMethod()
        {
            _adapter?.AdapterMethod();
        }
    }
}
