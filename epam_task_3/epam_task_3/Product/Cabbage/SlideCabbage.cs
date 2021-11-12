using epam_task_3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.Product.Cabbage
{
    public class SlideCabbage : Product
    {
        public TypeProcessorEnum CabbageProcessorEnum { get;}
        public decimal CostOfSlideCabbage { get; }
        public SlideCabbage(string name, decimal costOfClide, TypeProcessorEnum cabbageProcessorEnum)
            : base(name)
        {
            CostOfSlideCabbage = costOfClide + Cost;
            CabbageProcessorEnum = cabbageProcessorEnum;
        }
    }
}
