using NUnit.Framework;
using epam_task_3.Queue.QueueSlicing;
using epam_task_3.JsonManager;
using System.Collections.Generic;
using System;
using epam_task_3.PathToFile;
using epam_task_3.History;
using epam_task_3.CreateDishes;
using epam_task_3.Dish;
using epam_task_3.ProductJson;
using epam_task_3.ProductCount;

namespace TestLibrary
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetAllOfHistory()
        {
            var historys = new List<HistoryParent>();
            var history = new HistoryParent();
            List<string> dishes = new List<string>();
            dishes.Add("CabbageAndTomatoSalad");
            history.History = new History
            {
                Id = 1,
                Date = Convert.ToDateTime("9.11.2021"),
                Dish = dishes
            };
            historys.Add(history);
            JsonHistoryManager jsonHistoryManager = new JsonHistoryManager(PathToFile.PathToHistory);

            var items = jsonHistoryManager.GetAll();

            Assert.AreEqual(items, historys);
        }

       [Test]
       public void CreateOfProduct()
        {
            var products = new List<ProductCount>
            {
                new ProductCount
                {
                    Id = 1,
                    Count = 40,
                    Name = "Tomatoes"
                },
                new ProductCount
                {
                    Id = 2,
                    Count = 40,
                    Name = "Cabbage"
                },
                new ProductCount
                {
                    Id = 3,
                    Count = 10,
                    Name = "Test"
                },
            };
            JsonProductCountManager jsonProductCount = new JsonProductCountManager(PathToFile.PathToProductCount);
            var product = new ProductCountParent
            {
                ProductCount = new ProductCount
                {
                    Id = 3,
                    Count = 10,
                    Name = "Test"
                }
            };
            
            jsonProductCount.Create(product);

            var items = jsonProductCount.GetAll();
            jsonProductCount.Delete(1);

            Assert.AreEqual(items, products);
        }
    }
}