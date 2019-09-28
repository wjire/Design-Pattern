using System;

namespace _14_模板方法模式
{
    public abstract class Meat
    {
        public void CookMeat()
        {
            PourOil();
            Heat();
            AddMeat();
            if (HookMethod())
            {
                Chao();
            }
            //AddMeat();
       
        }

        private void PourOil()
        {
            Console.WriteLine("第一步:倒油");
        }

        private void Heat()
        {
            Console.WriteLine("第二步:加热");
        }

        /// <summary>
        /// 钩子方法,子类通过重写该方法,决定是否调用父类的方法,从而达到通过子类改变父类的行为
        /// </summary>
        /// <returns></returns>
        protected virtual bool HookMethod()
        {
            return true;
        }

        protected abstract void AddMeat();


        protected virtual void Chao()
        {
            Console.WriteLine("第四步,翻滚肉肉");
        }
    }
}
