using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.Product
{
    public abstract class Product
    {
        public string Name { get; set; }

        public const decimal Cost = 20;

        public Product(string name)
        {
            Name = name;
        }
    }
}
