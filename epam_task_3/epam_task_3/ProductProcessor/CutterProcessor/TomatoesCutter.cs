using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Enums;
using epam_task_3.Product.Tomatoes;

namespace epam_task_3.ProductProcessor.CutterProcessor
{
    public class TomatoesCutter : ProductProcessor
    {
        public const int Time = 5;
        public TomatoesCutter(string name)
            : base(name)
        { }

        public Product.Product CreateSlideTomatoes(TomatoesProcessorEnum tomatoesProcessorEnum)
        {
            return new SlideTomatoes(SlideProdectEnum.SlideTomotoes.ToString(), Cost, tomatoesProcessorEnum);
        }
    }
}
