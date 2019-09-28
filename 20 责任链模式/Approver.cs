using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_责任链模式
{
    /// <summary>
    /// 审批人
    /// </summary>
    public abstract class Approver
    {
        /// <summary>
        /// 下一个审批人
        /// </summary>
        public Approver NextApprover { get; set; }

        /// <summary>
        /// 审批人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前审批人的最大权限
        /// </summary>
        public decimal MaxPrice { get; set; }

        protected Approver(string name,decimal maxPrice)
        {
            this.Name = name;
            this.MaxPrice = maxPrice;
        }

        public abstract void ProcessRequest(PurchaseRequest request);
    }
}
