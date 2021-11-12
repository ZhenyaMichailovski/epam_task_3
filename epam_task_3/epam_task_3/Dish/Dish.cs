using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.Dish
{
    public abstract class Dish
    {
        public List<Product.Product> Products { get; }

        public Dish(List<Product.Product> products)
        {
            Products = products;
        }
    }
}
