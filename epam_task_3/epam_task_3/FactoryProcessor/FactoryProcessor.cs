using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Enums;
using epam_task_3.Product.Cabbage;
using epam_task_3.Product.Tomatoes;
using epam_task_3.Product;
using epam_task_3.ProductProcessor.CutterProcessor;

namespace epam_task_3.FactoryProcessor
{
    public class FactoryProcessor
    {
        public Product.Product CreateSlideProduct(SlideProductEnum slideProdectEnum, SlideProcessorEnum slideProcessorEnum)
        {
            
            switch (slideProdectEnum)
            {
                case SlideProductEnum.SlideCabbage:
                    CabbageCutter cabbageCutter = new CabbageCutter();
                    return cabbageCutter.CreateCutterCabbage(slideProcessorEnum);
                case SlideProductEnum.SlideTomotoes:
                    TomatoesCutter tomatoesCutter = new TomatoesCutter();
                    return tomatoesCutter.CreateSlideTomatoes(slideProcessorEnum);
                default:
                    throw new Exception("Невозможно нарезать");
            }
        }
    }
}
