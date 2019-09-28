using System.Collections.Generic;

namespace _17_中介者模式
{
    /// <summary>
    /// 中介者抽象类
    /// </summary>
    internal abstract class BaseMediator
    {
        public List<BasePlayer> PlayerList = new List<BasePlayer>();

        public void AddPlayer(BasePlayer basePlayer)
        {
            if (!PlayerList.Contains(basePlayer))
            {
                PlayerList.Add(basePlayer);
            }
        }

        public void RemovePlayer(BasePlayer basePlayer)
        {
            PlayerList.Remove(basePlayer);
        }

        public abstract void Win(decimal money, BasePlayer basePlayer);
    }

    /// <summary>
    /// 具体中介者
    /// </summary>
    internal class ConcreteBaseMediator : BaseMediator
    {

        public override void Win(decimal money, BasePlayer basePlayer)
        {
            int count = PlayerList.Count;

            foreach (BasePlayer item in PlayerList)
            {
                if (item.Equals(basePlayer))
                {
                    item.Money += money;
                }
                else
                {
                    item.Money -= money / (count - 1);
                }
            }
        }
    }
}
