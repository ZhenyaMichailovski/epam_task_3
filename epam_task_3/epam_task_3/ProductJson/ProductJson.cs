using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.ProductJson
{
    public class ProductJson
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CountProduct")]
        public int CountProduct { get; set; }

        [JsonProperty("TypeProcess")]
        public string TypeProcess { get; set; }

        [JsonProperty("Processor")]
        public string Processor { get; set; }
    }
}
