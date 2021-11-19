using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epam_task_3.Dish;
using epam_task_3.Enums;
using epam_task_3.JsonManager;
using epam_task_3.PathToFile;

namespace epam_task_3.CreateDishes
{
    /// <summary>
    /// order creation class
    /// includes creating a dish, checking the recipe, checking the download
    /// </summary>
    public class CreateDishes
    {
        /// <summary>
        /// order execution method
        /// </summary>
        /// <param name="id">id of the required order</param>
        /// <returns>List of th required dishes</returns>
        public List<Dish.Dish> ExecuteOrder(int id)
        {
            JsonOrderManager jsonOrderManager = new JsonOrderManager(PathToFile.PathToFile.PathToOrder);
            var orders = jsonOrderManager.GetAll();
            var order = orders.FirstOrDefault(x => x.Order.Id == id);

            JsonRecipeManager jsonRecipeManager = new JsonRecipeManager(PathToFile.PathToFile.PathToRecipe);
            var recipes = jsonRecipeManager.GetAll();
            var dishes = new List<Dish.Dish>();
            for (int i = 0; i < order.Order.Dish.Count; i++)
            {
                var recipe = recipes.FirstOrDefault(x => x.Recipe.Name == order.Order.Dish[i]);
                dishes.Add(CreateDish(recipe.Recipe.Name, recipe));
            }

            orders.Remove(order);
            jsonOrderManager.SetAll(orders);

            JsonHistoryManager jsonHistoryManager = new JsonHistoryManager(PathToFile.PathToFile.PathToHistory);
            var historys = jsonHistoryManager.GetAll();

            var historyParent = new History.HistoryParent();
            historyParent.History = new History.History() { Id = order.Order.Id, Date = order.Order.Date, Dish = order.Order.Dish };
            historys.Add(historyParent);

            jsonHistoryManager.SetAll(historys);

            return dishes;
        }

        /// <summary>
        /// the method of creating a dish
        /// </summary>
        /// <param name="name">name of dish</param>
        /// <param name="recipe">Recipe of the required dish</param>
        /// <returns>required dish</returns>
        private Dish.Dish CreateDish(string name, Recipe.RecipeParent recipe)
        {
            Enum.TryParse(name, out DishEnum item);

            switch (item)
            {
                case DishEnum.CabbageAndTomatoSalad:
                    return CreateCabbageAndTomatoSalad(recipe);
                default:
                    throw new Exception("Не получилось найти такое блюдо");
            }

        }

        /// <summary>
        /// the method of creating a salad
        /// </summary>
        /// <param name="recipe">recipe of the salad</param>
        /// <returns>salad</returns>
        private Dish.Dish CreateCabbageAndTomatoSalad(Recipe.RecipeParent recipe)
        {
            JsonProductCountManager jsonProductCountManager = new JsonProductCountManager(PathToFile.PathToFile.PathToProductCount);
            var productCounts = jsonProductCountManager.GetAll();

            CheckQueueSlicing();

            var items = new List<Product.Product>();
            for(int i = 0; i < recipe.Recipe.Product.Count; i++)
            {
                foreach (var productCount in productCounts)
                    if (productCount.ProductCount.Name == recipe.Recipe.Product[i].ProductJson.Name)
                        if(productCount.ProductCount.Count >= recipe.Recipe.Product[i].ProductJson.CountProduct)
                        productCount.ProductCount.Count -= recipe.Recipe.Product[i].ProductJson.CountProduct;

                items.Add(CreateProduct(recipe.Recipe.Product[i].ProductJson.Name,
                    recipe.Recipe.Product[i].ProductJson.Processor, recipe.Recipe.Product[i].ProductJson.TypeProcess));
                  
                
            }
            return new CabbageAndTomatoSalad(items);
        }


        /// <summary>
        /// the method of creating the necessary processed product
        /// </summary>
        /// <param name="name">name of product</param>
        /// <param name="processor">processing</param>
        /// <param name="typeProcessor">type of processing</param>
        /// <returns>necessary processed product</returns>
        private Product.Product CreateProduct(string name, string processor, string typeProcessor)
        {
            Enum.TryParse(name, out ProductEnum typeProduct);
            Enum.TryParse(processor, out ProcessorEnum processorEnum);
            Enum.TryParse(typeProcessor, out TypeProcessorEnum typeProcessorEnum);
            ProductProcessor.ProductProcessor productProcessor = new ProductProcessor.ProductProcessor();

            return productProcessor.CreateProcessor(processorEnum, typeProduct, typeProcessorEnum);
        }


        /// <summary>
        /// method for checking the free cutter
        /// </summary>
        private void CheckQueueSlicing()
        {
            JsonQueueSlicingManager jsonQueueSlicingManager = new JsonQueueSlicingManager(PathToFile.PathToFile.PathToQueueSlicing);
            var items = jsonQueueSlicingManager.GetAll();
            foreach(var item in items)
            {
                if((DateTime.Now - item.QueueSlicing.StartTime).Minutes > item.QueueSlicing.TimeToCutting/* || DateTime.Now.Day > item.QueueSlicing.StartTime.Day*/)
                {
                    items.Remove(item);
                }
            }
            jsonQueueSlicingManager.SetAll(items);
            
        }
    }
}
