using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Product.Cabbage;
using epam_task_3.Enums;
using epam_task_3.Product;

namespace epam_task_3.ProductProcessor.CutterProcessor
{
    public class CabbageCutter : ProductProcessor
    {
        public const int Time = 10;
        public CabbageCutter()
            : base ()
        { }

        public Product.Product CreateCutterCabbage(SlideProcessorEnum cabbageProcessorEnum)
        {
            return new SlideCabbage(SlideProductEnum.SlideCabbage.ToString(), Cost, cabbageProcessorEnum);
        }
    }
}
