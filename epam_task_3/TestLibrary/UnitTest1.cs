using NUnit.Framework;
using epam_task_3.Queue.QueueSlicing;
using epam_task_3.JsonManager;
using System.Collections.Generic;
using System;
using epam_task_3.PathToFile;

namespace TestLibrary
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            JsonRecipeManager jsonRecipeManager = new JsonRecipeManager(PathToFile.PathToRecipe);
            var items = jsonRecipeManager.GetAll();
            Assert.IsTrue(true);
        }
    }
}