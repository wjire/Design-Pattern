using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_责任链模式
{

    /// <summary>
    /// 采购请求
    /// </summary>
    public class PurchaseRequest
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        public PurchaseRequest(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }
    }
}
