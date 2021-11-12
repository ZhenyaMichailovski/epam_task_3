using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Enums;
using epam_task_3.JsonManager;
using epam_task_3.Product.Tomatoes;

namespace epam_task_3.ProductProcessor.CutterProcessor
{
    public class TomatoesCutter : CutterProcessor
    {
        public const int Time = 5;

        public TomatoesCutter()
            : base()
        { }

        public Product.Product CreateSlideTomatoes(TypeProcessorEnum tomatoesProcessorEnum)
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
                        Name = "SlideTomatoes",
                        StartTime = DateTime.Now,
                        TimeToCutting = Time
                    }
                });
                jsonQueueSlicingManager.SetAll(queueSlicings);
            }
            else
                throw new Exception("Очередь занята!");

            return new SlideTomatoes(TypeProductEnum.SlideTomatoes.ToString(), Cost, tomatoesProcessorEnum);
        }
    }
}
