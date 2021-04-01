using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClassLibrary
{
    public class CafeMenuRepository
    {
        private readonly List<CafeMenu> _menuDirectory = new List<CafeMenu>();

        //Create
        public bool AddMenuItemToDirectory(CafeMenu menu)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(menu);

            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<CafeMenu> ShowAllMenuItemsInDirectory(CafeMenu originalItem)
        {
            return _menuDirectory;
        }

        public List<CafeMenu> GetMenu()
        {
            return _menuDirectory;
        }

        public CafeMenu GetMenuItemByName(string name)
        {
            foreach (CafeMenu menu in _menuDirectory)
            {
                if (menu.Name.ToLower() == name.ToLower())
                {
                    return menu;
                }
            }
            return null;
        }

        public CafeMenu GetMenuItemByID(int Number)
        {
            foreach (CafeMenu menu in _menuDirectory)
            {
                if (menu.ID == Number)
                {
                    return menu;
                }
            }
            return null;
        }

        //Update
        //(Not asked for but it felt weird to leave it out. Then it didn't want to work so I commented it out. Will retuen if time permits.)
        /*
         public bool UpdateExistingMenuItem(string originalItem, CafeMenu newItem)
         {
             CafeMenu originalItem = ShowAllMenuItems(originalItem);

             if (originalItem != null)
             {
                 originalItem.Meal = newItem.Meal;
                 originalItem.Drink = newItem.Drink;
                 originalItem.Side = newItem.Side;

                 return true;
             }
             else
             {
                 return false;
             }
         }
        */


        //Delete
        public bool DeleteMenuItemFromDirectory(CafeMenu currentItem)
        {
            bool deleteResult = _menuDirectory.Remove(currentItem);
            return deleteResult;
        }


    }
}
