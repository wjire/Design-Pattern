using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_中介者模式
{
    /// <summary>
    /// 玩家抽象类
    /// </summary>
    abstract class BasePlayer
    {
        public decimal Money { get; set; }

        public abstract void Win(decimal money, BaseMediator baseMediator);
    }

    /// <summary>
    /// 玩家A
    /// </summary>
    class BasePlayerA : BasePlayer
    {
        public BasePlayerA(decimal money)
        {
            this.Money = money;
        }
        public override void Win(decimal money, BaseMediator baseMediator)
        {
            baseMediator.Win(money, this);
        }
    }


    /// <summary>
    /// 玩家B
    /// </summary>
    class BasePlayerB : BasePlayer
    {
        public BasePlayerB(decimal money)
        {
            this.Money = money;
        }
        public override void Win(decimal money, BaseMediator baseMediator)
        {
            baseMediator.Win(money, this);
        }
    }


    /// <summary>
    /// 玩家C
    /// </summary>
    class BasePlayerC : BasePlayer
    {
        public BasePlayerC(decimal money)
        {
            this.Money = money;
        }
        public override void Win(decimal money, BaseMediator baseMediator)
        {
            baseMediator.Win(money, this);
        }
    }
}
