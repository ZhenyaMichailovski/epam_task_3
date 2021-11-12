using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Interfaces;
using epam_task_3.Order;
using Newtonsoft.Json;

namespace epam_task_3.JsonManager
{
    public class JsonOrderManager : IJsonManager<OrderParent>
    {
        private string Path;
        public JsonOrderManager(string path)
        {
            Path = path;
        }
        public List<OrderParent> GetAll()
        {
            string json = File.ReadAllText(Path);
            var items = JsonConvert.DeserializeObject<List<OrderParent>>(json);

            return items;
        }

        public void Create(OrderParent queueSlicing)
        {
            var items = GetAll();
            items.Add(queueSlicing);
            SetAll(items);
        }

        public void Delete(int id)
        {
            var items = GetAll();
            var item = items.FirstOrDefault(x => x.DishJson.Id == id);
            items.Remove(item);
            SetAll(items);
        }

        public void SetAll(List<OrderParent> queueSlicingParents)
        {
            var str = JsonConvert.SerializeObject(queueSlicingParents);
            var sw = File.CreateText(Path);
            sw.Write(str);
        }
    }
}
