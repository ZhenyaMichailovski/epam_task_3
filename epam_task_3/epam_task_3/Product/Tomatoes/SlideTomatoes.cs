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
        public SlideProcessorEnum TomatoesProcessorEnum { get; }
        public decimal CostOfSlideTomatoes { get; }
        public SlideTomatoes(string name, decimal costOfSlide, SlideProcessorEnum tomatoesProcessorEnum)
           : base(name)
        {
            CostOfSlideTomatoes = costOfSlide + Cost;
            TomatoesProcessorEnum = tomatoesProcessorEnum;
        }
    }
}
