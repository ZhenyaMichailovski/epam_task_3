using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.Dish
{
    public class Dish
    {
        public const decimal Cost = 100;
        public List<Product.Product> Products { get; set; }
        public Dish(List<Product.Product> products)
        {
            Products = products;
        }
    }
}
