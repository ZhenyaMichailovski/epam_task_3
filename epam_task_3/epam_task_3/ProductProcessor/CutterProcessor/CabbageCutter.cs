using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Product.Cabbage;
using epam_task_3.Enums;
using epam_task_3.JsonManager;
using epam_task_3.PathToFile;
using epam_task_3.Product;

namespace epam_task_3.ProductProcessor.CutterProcessor
{
    public class CabbageCutter : CutterProcessor
    {
        public const int Time = 10;
        public CabbageCutter()
            : base ()
        { }

        public Product.Product CreateCutterCabbage(TypeProcessorEnum cabbageProcessorEnum)
        {
            JsonQueueSlicingManager jsonQueueSlicingManager = new JsonQueueSlicingManager(PathToFile.PathToFile.PathToQueueSlicing);
            var queueSlicings = jsonQueueSlicingManager.GetAll();
            if (queueSlicings.Count < 5)
            {
                queueSlicings.Add(new Queue.QueueSlicing.QueueSlicingParent()
                {
                    QueueSlicing = new Queue.QueueSlicing.QueueSlicing()
                    {
                        Id = queueSlicings.Count + 1,
                        Name = "SlideCabbage",
                        StartTime = DateTime.Now,
                        TimeToCutting = Time
                    }
                });
                jsonQueueSlicingManager.SetAll(queueSlicings);
            }
            else
                throw new Exception("Очередь занята!");

            return new SlideCabbage(TypeProductEnum.SlideCabbage.ToString(), Cost, cabbageProcessorEnum);
        }
    }
}
