using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.Dish
{
    public class CabbageAndTomatoSalad : Dish
    {
        public const decimal Cost = 100;
        public CabbageAndTomatoSalad(List<Product.Product> products)
            : base(products)
        { }
    }
}
