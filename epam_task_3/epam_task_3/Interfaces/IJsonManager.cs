using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_3.Interfaces
{
    interface IJsonManager<T>
    {
        public void Create(T item);
        public void Delete(int id);
        public List<T> GetAll();
        public void SetAll(List<T> items);
    }
}
