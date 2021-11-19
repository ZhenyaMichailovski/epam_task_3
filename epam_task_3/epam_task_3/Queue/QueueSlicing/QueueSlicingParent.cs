using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.Queue.QueueSlicing
{
    public class QueueSlicingParent
    {
        public QueueSlicing QueueSlicing { get; set; }

        public QueueSlicingParent(QueueSlicing item)
        {
            QueueSlicing = item;
        }

        public QueueSlicingParent()
        {
        }
    }
}
