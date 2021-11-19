using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.History
{
    public class History
    {
        
        public int Id { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("Dish")]
        public List<string> Dish { get; set; }

        public override bool Equals(object obj)
        {
            var item = (History)obj;
            return (item.Id == this.Id);
        }
    }
}
