using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20_责任链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 下面以公司采购东西为例子来实现责任链模式。
             * 公司规定，采购架构总价在1万之内，经理级别的人批准即可，总价大于1万小于2万5的则需要副总进行批准，总价大于2万5小于10万的需要总经理批准，而总价大于10万的则需要组织一个会议进行讨论。
             * 对于这样一个需求，最直观的方法就是设计一个方法，参数是采购的总价，然后在这个方法内对价格进行调整判断，然后针对不同的条件交给不同级别的人去处理，这样确实可以解决问题，但这样一来，我们就需要多重if-else语句来进行判断，但当加入一个新的条件范围时，我们又不得不去修改原来设计的方法来再添加一个条件判断，这样的设计显然违背了“开-闭”原则。这时候，可以采用责任链模式来解决这样的问题。具体实现代码如下所示。
             * 
             */

            PurchaseRequest request = new PurchaseRequest("computer", 139000);
            Approver manager = new Manager("李经理",10000);
            Approver vicePresident = new VicePresident("王副总",25000);
            Approver president = new President("马总",100000);

            //设置责任链
            manager.NextApprover = vicePresident;
            vicePresident.NextApprover = president;

            //处理请求
            manager.ProcessRequest(request);

            Console.ReadKey();
        }
    }
}
