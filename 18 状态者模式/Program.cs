using System;

namespace _18_状态者模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * 每个对象都有其对应的状态,而每个状态都有一些相应的行为,如果某个对象有多种状态,那么就会对应很多行为,因此,对这些状态和行为的判断,会导致多重条件语句,并且,如果要添加一种状态,则需要更改之前的代码,这显然违背了开闭原则
             * 
             * 状态者模式就是来解决这种问题的
             * 它将每种状态对应的行为抽象出来成为单独的新的对象
             * 这样状态的变化不再依赖于对象内部的行为    
             * 
             * 简单说,就是允许一个对象在其状态发生变化时,自动改变其行为
             * 该模式强调"动态"二字,即状态变化时,行为会跟着变化,不需要调用者手动修改.
             *
             * 所以,该设计模式需要一个上下文环境来保存状态.
             * 另外,关于状态的变化逻辑,则属于状态的具体行为,不属于上下文.
             * 那么,当状态变换时,就需要修改当前上下文环境中保存的状态,因此,状态对象里面还需要保存当前上下文环境.
             * 所以,状态和上下文环境的关系是"互相聚合".
             * 这里要注意一个点:
             * 环境是永远不变的,变的是状态,但引起状态变化的逻辑和条件都保存在状态对象里面,
             * 所以当构造新状态时,需要将旧状态对象传给新状态.----这里非常重要
             *
             *
             */

            //{
            //    Account account = new Account("wjire");
            //    account.Deposit(100);
            //    Console.WriteLine("***********************");
            //    account.WithDraw(200);
            //    Console.WriteLine("***********************");
            //    account.Deposit(1000000);
            //    Console.WriteLine("***********************");
            //}

            {
                Test.TestState();
            }


            Console.ReadKey();

        }
    }

    internal class Account
    {
        public State State { get; set; }
        public string Owner { get; set; }

        public Account(string owner)
        {
            Owner = owner;
            State = new SilverState(0, this);
        }

        public decimal Balance => State.Balance;

        public void Deposit(decimal money)
        {
            State.Deposit(money);
            Console.WriteLine($"本次存入金额 : {money} 元");
            Console.WriteLine($"账户余额为 : {Balance} 元");
            Console.WriteLine($"账户状态为 : {State.GetType().Name}");

        }

        public void WithDraw(decimal money)
        {
            State.Withdraw(money);
            Console.WriteLine($"本次取款金额 : {money} 元");
            Console.WriteLine($"账户余额为 : {Balance} 元");
            Console.WriteLine($"账户状态为 : {State.GetType().Name}");
        }
    }

    internal abstract class State
    {
        public Account Account { get; set; }//当前账户
        public decimal Balance { get; set; }//余额

        public decimal LowerLimit { get; set; }//每种状态的下限
        public decimal UpperLimit { get; set; }//每种状态的上限

        //TODO:最开始我写了一个通用的判断状态的方法,放在父类,每次取钱,存钱都调用这个方法,后来发现这样不好.
        //TODO:这样写,并没有简化逻辑判断,而只是挪了个位置而已,正确做法应该是将状态的逻辑判断拆散,放在每个状态里面
        //TODO:但是,写完了,发现貌似还是写在父类好一些.

        /// <summary>
        /// 动态改变账户状态
        /// </summary>
        //public void ChangeState()
        //{
        //    if (Balance < 0)
        //    {
        //        Account.State = new RedState(Balance, Account);
        //    }
        //    else if (Balance > UpperLimit)
        //    {
        //        Account.State = new GoldState(Balance, Account);
        //    }
        //    else
        //    {
        //        Account.State = new SilverState(Balance, Account);
        //    }
        //}


        /// <summary>
        /// 不管状态是什么,都可以存钱,所以放在父类
        /// </summary>
        /// <param name="money"></param>
        public void Deposit(decimal money)
        {
            Balance += money;
            ChangeState();
        }

        public abstract void ChangeState();//改变状态


        public abstract void Withdraw(decimal money); // 取钱
    }

    /// <summary>
    /// 新开账户 0 - 1000
    /// </summary>
    internal class SilverState : State
    {
        public SilverState(State state) : this(state.Balance, state.Account)
        {

        }

        public SilverState(decimal money, Account account)
        {
            Balance = money;
            Account = account;
            LowerLimit = 0;
            UpperLimit = 1000;
        }


        public override void ChangeState()
        {
            if (Balance < LowerLimit)
            {
                Account.State = new RedState(this);
            }
            else if (Balance > UpperLimit)
            {
                Account.State = new GoldState(this);
            }
        }

        public override void Withdraw(decimal money)
        {
            Balance -= money;
            ChangeState();
        }
    }

    /// <summary>
    /// 标准账户    1000 - 10000
    /// </summary>
    internal class GoldState : State
    {
        public GoldState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            LowerLimit = 1000;
            UpperLimit = 10000;
        }

        public override void ChangeState()
        {
            if (Balance < 0)
            {
                Account.State = new RedState(this);
            }
            else if (Balance < LowerLimit)
            {
                Account.State = new SilverState(this);
            }
        }

        public override void Withdraw(decimal money)
        {
            Balance -= money;
            ChangeState();
        }
    }

    /// <summary>
    /// 透支账户   小于 0 
    /// </summary>
    internal class RedState : State
    {
        public RedState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            UpperLimit = 0;
        }

        public override void ChangeState()
        {
            if (Balance > UpperLimit)
            {
                Account.State = new SilverState(this);//这里有BUG,如果一次性存入 1000000,应该 new GoldState(this)
            }
        }

        public override void Withdraw(decimal money)
        {
            Console.WriteLine("余额不足,无法取款");
        }
    }
}
