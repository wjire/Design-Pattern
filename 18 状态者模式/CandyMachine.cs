using System;

namespace _18_状态者模式
{
    public class CandyMachine
    {
        //设计模式书上是将所有的状态都提前创建了出来
        //private IState _noQuarterState;
        //private IState _hasQuarterState;
        //private IState _soldState;
        //private IState _soldOutState;

        private IState _state;

        private IState _currentStatus;

        public int _count;

        public CandyMachine(int count)
        {
            //_noQuarterState = new NoQuarterState(this);
            //_hasQuarterState = new HasQuarterState(this);
            //_soldState = new SoldState(this);
            //_soldOutState = new SoldOutState(this);
            //_currentStatus = _soldOutState;

            _currentStatus = new SoldOutState(this);
            if (count > 0)
            {
                _count = count;
                _currentStatus = new NoQuarterState(this);
            }
        }

        public void SetCurrentState(IState state)
        {
            _currentStatus = state;
        }

        public void InsertQuarter()
        {
            _currentStatus.InsertQuarter();
        }

        public void EjectQuarter()
        {
            _currentStatus.EjectQuarter();
        }

        public void TurnCrank()
        {
            _currentStatus.TurnCrank();
        }

        public void Dispense()
        {
            _currentStatus.Dispense();
        }


        public interface IState
        {
            void InsertQuarter();
            void EjectQuarter();
            void TurnCrank();
            void Dispense();
        }


        public class NoQuarterState : IState
        {
            private readonly CandyMachine _candyMachine;

            public NoQuarterState(CandyMachine machine)
            {
                _candyMachine = machine;
            }

            public void InsertQuarter()
            {
                Console.WriteLine("你投入了钱");
                _candyMachine.SetCurrentState(new HasQuarterState(_candyMachine));

            }

            public void EjectQuarter()
            {
                Console.WriteLine("你还没投钱");
            }

            public void TurnCrank()
            {
                Console.WriteLine("你还没投钱");
            }

            public void Dispense()
            {
                Console.WriteLine("你还没投钱");
            }
        }


        public class SoldOutState : IState
        {

            private readonly CandyMachine _candyMachine;

            public SoldOutState(CandyMachine machine)
            {
                _candyMachine = machine;
            }

            public void InsertQuarter()
            {
                Console.WriteLine("糖果卖完啦");
            }

            public void EjectQuarter()
            {
                Console.WriteLine("糖果卖完啦");
            }

            public void TurnCrank()
            {
                Console.WriteLine("糖果卖完啦");
            }

            public void Dispense()
            {
                Console.WriteLine("糖果卖完啦");
            }
        }


        public class HasQuarterState : IState
        {

            private readonly CandyMachine _candyMachine;

            public HasQuarterState(CandyMachine machine)
            {
                _candyMachine = machine;
            }

            public void InsertQuarter()
            {
                Console.WriteLine("你已经投过钱了");
            }

            public void EjectQuarter()
            {
                Console.WriteLine("马上退款");
                _candyMachine.SetCurrentState(new NoQuarterState(_candyMachine));
            }

            public void TurnCrank()
            {
                Console.WriteLine("转动把手,马上给你糖果");
                _candyMachine.SetCurrentState(new SoldState(_candyMachine));
            }

            public void Dispense()
            {
                Console.WriteLine("请转动把手");
            }
        }


        public class SoldState : IState
        {

            private readonly CandyMachine _candyMachine;

            public SoldState(CandyMachine machine)
            {
                _candyMachine = machine;
            }

            public void InsertQuarter()
            {
                throw new NotImplementedException();
            }

            public void EjectQuarter()
            {
                throw new NotImplementedException();
            }

            public void TurnCrank()
            {
                throw new NotImplementedException();
            }

            public void Dispense()
            {
                throw new NotImplementedException();
            }
        }
    }
}
