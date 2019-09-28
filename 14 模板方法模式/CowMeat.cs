using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_模板方法模式
{
    public class CowMeat : Meat
    {
        protected override void AddMeat()
        {
            Console.WriteLine("第三步:到牛肉");
        }

        /// <summary>
        /// 重写钩子方法
        /// </summary>
        /// <returns></returns>
        protected override bool HookMethod()
        {
            return false;
        }
    }
}
