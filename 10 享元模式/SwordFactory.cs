using System;
using System.Collections.Generic;

namespace _10_享元模式
{
    public class SwordFactory
    {
        private static readonly Dictionary<SwordEnum, BaseSword> Dic = new Dictionary<SwordEnum, BaseSword>();
        private static readonly Dictionary<SwordEnum, Lazy<BaseSword>> LazyDic = new Dictionary<SwordEnum, Lazy<BaseSword>>();

        static SwordFactory()
        {
            LazyDic.Add(SwordEnum.木剑, new Lazy<BaseSword>(()=>new WoodSword()));
            LazyDic.Add(SwordEnum.铁剑, new Lazy<BaseSword>(()=>new IronSword()));
            LazyDic.Add(SwordEnum.魔剑, new Lazy<BaseSword>(()=>new MagicSword()));
        }
        public static BaseSword GetSword(SwordEnum type)
        {
            Lazy<BaseSword> lazy = null;
            if (LazyDic.TryGetValue(type, out lazy)) return lazy.Value;
            throw new Exception("没有该 type");
        }


        private static readonly object Locker = new object();

        public static BaseSword CreateSword(SwordEnum type)
        {
            if (Dic.ContainsKey(type))
            {
                return Dic[type];
            }
            lock (Locker)
            {
                if (Dic.ContainsKey(type))
                {
                    return Dic[type];
                }
                BaseSword sword;
                switch (type)
                {
                    case SwordEnum.木剑:
                        sword = new WoodSword(); break;
                    case SwordEnum.铁剑:
                        sword = new IronSword(); break;
                    case SwordEnum.魔剑:
                        sword = new MagicSword(); break;
                    default:
                        throw new Exception("wrong sword");
                }
                Dic.Add(type, sword);
                return sword;
            }
        }
    }
}
