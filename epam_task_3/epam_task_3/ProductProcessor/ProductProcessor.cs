using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.ProductProcessor
{
    public abstract class ProductProcessor
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public ProductProcessor(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
