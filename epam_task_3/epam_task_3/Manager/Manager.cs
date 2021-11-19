using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.JsonManager;
using epam_task_3.ProductProcessor.CutterProcessor;

namespace epam_task_3.Manager
{
    /// <summary>
    /// the class is needed to find statistics
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// method of finding the load of the cutter
        /// </summary>
        /// <returns>available seats</returns>
        public int ViewingAvailableCapacitiesOfSlicing()
        {
            JsonQueueSlicingManager manager = new JsonQueueSlicingManager(PathToFile.PathToFile.PathToQueueSlicing);

            var items = manager.GetAll();

            return CutterProcessor.Power - items.Count;
        }

        /// <summary>
        /// viewing the orders made for the specified period
        /// </summary>
        /// <param name="dateStart">date of start period</param>
        /// <param name="dateEnd">date of end period</param>
        /// <returns>List of orders from period</returns>
        public List<History.HistoryParent> ViewingOrdersForPeriod(DateTime dateStart, DateTime dateEnd)
        {
            JsonManager.JsonHistoryManager jsonOrderManager = new JsonHistoryManager(PathToFile.PathToFile.PathToHistory);

            var orders = jsonOrderManager.GetAll();

            var items = orders.FindAll(x => x.History.Date >= dateStart && x.History.Date <= dateEnd);

            return items;
        }
    }
}
