using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.ProductCount
{
    public class ProductCountParent
    {
        public ProductCount ProductCount { get; set; }

        public override bool Equals(object obj)
        {
            var item = (ProductCount)obj;
            return this.ProductCount.Equals(item);
        }
    }
}
