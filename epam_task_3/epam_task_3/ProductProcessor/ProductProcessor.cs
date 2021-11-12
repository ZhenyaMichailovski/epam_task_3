using epam_task_3.Enums;
using epam_task_3.ProductProcessor.CutterProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.ProductProcessor
{
    public class ProductProcessor
    {
        public ProductProcessor()
        { }

        public Product.Product CreateProcessor(ProcessorEnum processorEnum, ProductEnum typeProductEnum, TypeProcessorEnum typeProcessorEnum)
        {
            switch (processorEnum)
            {
                case ProcessorEnum.Slide:
                    CutterProcessor.CutterProcessor cutterProcessor = new CutterProcessor.CutterProcessor();
                    return cutterProcessor.CreateSliceProduct(typeProductEnum, typeProcessorEnum);
                default:
                    throw new Exception();
            }
        }
    }
}
