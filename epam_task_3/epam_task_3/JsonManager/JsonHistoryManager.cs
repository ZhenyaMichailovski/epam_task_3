using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Interfaces;
using epam_task_3.History;
using System.IO;
using Newtonsoft.Json;

namespace epam_task_3.JsonManager
{
    public class JsonHistoryManager : IJsonManager<HistoryParent>
    {
        private string Path;
        public JsonHistoryManager(string path)
        {
            Path = path;
        }
        public List<HistoryParent> GetAll()
        {
            string json = File.ReadAllText(Path);
            var items = JsonConvert.DeserializeObject<List<HistoryParent>>(json);

            return items;
        }

        public void Create(HistoryParent queueSlicing)
        {
            var items = GetAll();
            items.Add(queueSlicing);
            SetAll(items);
        }

        public void Delete(int id)
        {
            var items = GetAll();
            var item = items.FirstOrDefault(x => x.History.Id == id);
            items.Remove(item);
            SetAll(items);
        }

        public void SetAll(List<HistoryParent> queueSlicingParents)
        {
            var str = JsonConvert.SerializeObject(queueSlicingParents);
            var sw = File.CreateText(Path);
            sw.Write(str);
        }
    }
}
