using System;

namespace _20_责任链模式
{
    /// <summary>
    /// 经理
    /// </summary>
    public class Manager : Approver
    {
        public Manager(string name, decimal price) : base(name, price) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Price < 10000)
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
