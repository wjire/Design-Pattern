using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_责任链模式
{
    /// <summary>
    /// 副总
    /// </summary>
    public class VicePresident : Approver
    {
        public VicePresident(string name, decimal price) : base(name, price) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Price < 25000)
            {
                Console.WriteLine($"the {this}-{Name} is Purchasing");
            }
            else
            {
                NextApprover?.ProcessRequest(request);
            }
        }
    }
}
