using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Interfaces;
using epam_task_3.Recipe;
using Newtonsoft.Json;

namespace epam_task_3.JsonManager
{
    public class JsonRecipeManager : IJsonManager<RecipeParent>
    {
        private string Path;
        public JsonRecipeManager(string path)
        {
            Path = path;
        }

        public List<RecipeParent> GetAll()
        {
            string json = File.ReadAllText(Path);
            var queueSlicings = JsonConvert.DeserializeObject<List<RecipeParent>>(json);

            return queueSlicings;
        }

        public void Create(RecipeParent queueSlicing)
        {
            var items = GetAll();
            items.Add(queueSlicing);
            SetAll(items);
        }

        public void Delete(int id)
        {
            var items = GetAll();
            var item = items.FirstOrDefault(x => x.Recipe.Id == id);
            items.Remove(item);
            SetAll(items);
        }

        public void SetAll(List<RecipeParent> queueSlicingParents)
        {
            var str = JsonConvert.SerializeObject(queueSlicingParents);
            using (var sw = File.CreateText(Path))
                sw.Write(str);
        }
    }
}
