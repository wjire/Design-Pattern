using System;

namespace _20_责任链模式
{
    /// <summary>
    /// 老总
    /// </summary>
    public class President : Approver
    {
        public President(string name, decimal price) : base(name, price) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Price < 100000)
            {
                Console.WriteLine($"the {this}-{Name} is Purchasing");
            }
            else
            {
                Console.WriteLine("Request 需要组织一个会议讨论");
            }
        }
    }
}
