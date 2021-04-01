using CafeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeTest
{


    [TestClass]
    public class UnitTest1
    {
        private CafeMenuRepository _repo = new CafeMenuRepository();

        [TestInitialize]
        public void Arrange()
        {
            CafeMenu _menu = new CafeMenu(4, "Land", "Land", 5.00);
            _repo.AddMenuItemToDirectory(_menu);
        }

        [TestMethod]
        public void AddToMenu()
        {
            CafeMenu menu = new CafeMenu(2, "Fish", "Fish", 3.00);
            CafeMenuRepository repository = new CafeMenuRepository();

            bool addItem = repository.AddMenuItemToDirectory(menu);

            Assert.IsTrue(addItem);
        }

        [TestMethod]
        public void ShowAllMenu()
        {
            CafeMenu menu = new CafeMenu();
            CafeMenuRepository repo = new CafeMenuRepository();
            repo.AddMenuItemToDirectory(menu);

            List<CafeMenu> ListOfMenuItems = repo.GetMenu();

            bool menuHasItem = ListOfMenuItems.Contains(menu);

            Assert.IsTrue(menuHasItem);
        }

        [TestMethod]
        public void DeleteFromMenu()
        {

            CafeMenu content = _repo.GetMenuItemByName("Land");
            bool removeResult = _repo.DeleteMenuItemFromDirectory(content);
            Assert.IsTrue(removeResult);

            /*
            CafeMenu menu = _repo.GetMenuItemByID(2);
            _repo.DeleteMenuItemFromDirectory(menu);
            Assert.AreEqual(firstCount - 1, List.Count);
            */


        }
    }
}
