using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Enums;

namespace epam_task_3.Product.Tomatoes
{
    public class SlideTomatoes : Product
    {
        public TypeProcessorEnum TomatoesProcessorEnum { get; }
        public decimal CostOfSlideTomatoes { get; }
        public SlideTomatoes(string name, decimal costOfSlide, TypeProcessorEnum tomatoesProcessorEnum)
           : base(name)
        {
            CostOfSlideTomatoes = costOfSlide + Cost;
            TomatoesProcessorEnum = tomatoesProcessorEnum;
        }
    }
}
