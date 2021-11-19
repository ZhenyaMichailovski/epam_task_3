using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.ProductCount
{
    public class ProductCount
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            var item = (ProductCount)obj;
            return item.Id == this.Id;

        }
    }
}
