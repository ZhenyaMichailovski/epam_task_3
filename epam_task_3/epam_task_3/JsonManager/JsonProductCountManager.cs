using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Interfaces;
using epam_task_3.ProductCount;
using Newtonsoft.Json;

namespace epam_task_3.JsonManager
{
    public class JsonProductCountManager : IJsonManager<ProductCountParent>
    {
        private string Path;
        public JsonProductCountManager(string path)
        {
            Path = path;
        }
        public List<ProductCountParent> GetAll()
        {
            string json = File.ReadAllText(Path);
            var items = JsonConvert.DeserializeObject<List<ProductCountParent>>(json);

            return items;
        }

        public void Create(ProductCountParent queueSlicing)
        {
            var items = GetAll();
            items.Add(queueSlicing);
            SetAll(items);
        }

        public void Delete(int id)
        {
            var items = GetAll();
            var item = items.FirstOrDefault(x => x.ProductCount.Id == id);
            items.Remove(item);
            SetAll(items);
        }

        public void SetAll(List<ProductCountParent> queueSlicingParents)
        {
            var str = JsonConvert.SerializeObject(queueSlicingParents);
            using (var sw = File.CreateText(Path))
                sw.Write(str);
        }
    }
}
