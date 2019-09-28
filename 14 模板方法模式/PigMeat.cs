using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_模板方法模式
{
    public class PigMeat : Meat
    {
        protected override void AddMeat()
        {
            Console.WriteLine("第三步:加猪肉");
        }
    }
}
