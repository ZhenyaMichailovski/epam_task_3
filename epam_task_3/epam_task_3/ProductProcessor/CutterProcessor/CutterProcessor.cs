using epam_task_3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.ProductProcessor.CutterProcessor
{
    public class CutterProcessor : ProductProcessor
    {
        public const int Power = 5;

        public const decimal Cost = 10;
        public CutterProcessor()
            : base()
        { }

        public Product.Product CreateSliceProduct(ProductEnum slideProdectEnum, TypeProcessorEnum slideProcessorEnum)
        {
            switch (slideProdectEnum)
            {
                case ProductEnum.Cabbage:
                    CabbageCutter cabbageCutter = new CabbageCutter();
                    return cabbageCutter.CreateCutterCabbage(slideProcessorEnum);
                case ProductEnum.Tomatoes:
                    TomatoesCutter tomatoesCutter = new TomatoesCutter();
                    return tomatoesCutter.CreateSlideTomatoes(slideProcessorEnum);
                default:
                    throw new Exception("Невозможно нарезать");
            }
        }
    }
}
