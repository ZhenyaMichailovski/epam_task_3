using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.Queue.QueueSlicing
{
    public class QueueSlicing
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("TimeToCutting")]
        public int TimeToCutting { get; set; }

        [JsonProperty("NameProduct")]
        public string Name { get; set; }

        [JsonProperty("StartTime")]
        public DateTime StartTime { get; set; }

        public QueueSlicing(int id, int timeToCutting, string name, DateTime startTime)
        {
            Id = id;
            TimeToCutting = timeToCutting;
            Name = name;
            StartTime = startTime;
        }

        public override bool Equals(object obj)
        {
            var item = (QueueSlicing)obj;

            return (item.Id == Id && item.TimeToCutting == TimeToCutting && item.StartTime == StartTime) ;
        }
    }
}
