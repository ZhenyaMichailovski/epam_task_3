using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.History
{
    public class HistoryParent
    {
        public History History { get; set; }

        public override bool Equals(object obj)
        {
            var item = (History)obj;

            return (this.History.Equals(item));
        }
    }
}
