using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Interfaces;
using epam_task_3.Queue.QueueSlicing;
using Newtonsoft.Json;

namespace epam_task_3.JsonManager
{
    public class JsonQueueSlicingManager : Interfaces.IJsonManager<QueueSlicingParent>
    {
        private string Path;
        public JsonQueueSlicingManager(string path)
        {
            Path = path;
        }

        public List<QueueSlicingParent> GetAll()
        {
            string json = File.ReadAllText(Path);
            var queueSlicings = JsonConvert.DeserializeObject<List<QueueSlicingParent>>(json);

            return queueSlicings;
        }

        public void Create(QueueSlicingParent queueSlicing)
        {
            var items = GetAll();
            items.Add(queueSlicing);
            SetAll(items);
        }

        public void Delete(int id)
        {
            var items = GetAll();
            var item = items.FirstOrDefault(x => x.QueueSlicing.Id == id);
            items.Remove(item);
            SetAll(items);
        }
        
        public void SetAll(List<QueueSlicingParent> queueSlicingParents)
        {
            var str = JsonConvert.SerializeObject(queueSlicingParents);
            var sw = File.CreateText(Path);
            sw.Write(str);
        }
    }
}
