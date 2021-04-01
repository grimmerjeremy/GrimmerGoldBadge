using CafeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsoleApp
{
    public class ProgramUI
    {
        private readonly CafeMenuRepository _menuDirectory = new CafeMenuRepository();

        public void Run()
        {
            SeedMenuList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you would like to select: \n" +
                    "1: Add a Menu Item.\n" +
                    "2: Delete a Menu Item.\n" +
                    "3: View all Menu Items.\n" +
                    "4: Exit.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ShowAllMenuItems();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.\n" +
                            "Press any key to coninue.......");
                        Console.ReadKey();
                        break;

                }
            }

        }
        private void AddMenuItem()
        {
            Console.Clear();
            CafeMenu menu = new CafeMenu();

            Console.WriteLine("You are about to add a new menu item.");

            Console.WriteLine("Please enter a Name for the item:");
            menu.Name = Console.ReadLine();

            Console.WriteLine("Please enter the Ingreedients for the item:");
            menu.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter a Price for the item:");
            menu.Price = double.Parse(Console.ReadLine());

            //Actually adds it to the list.
            _menuDirectory.AddMenuItemToDirectory(menu);
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("You are about to delete an existing menu item.");

            Console.WriteLine("Which menu item would you like to delete?");
            List<CafeMenu> cafeMenu = _menuDirectory.GetMenu();
            int count = 0;
            foreach (CafeMenu menu in cafeMenu)
            {
                count++;
                Console.WriteLine($"{count}. {menu.Name}");
            }
                int targetMenuID = int.Parse(Console.ReadLine());
                int targetIndex = targetMenuID - 1;
                
                if (targetIndex >= 0 && targetIndex < cafeMenu.Count)
                {
                    CafeMenu desiredItem = cafeMenu[targetIndex];
                    if (_menuDirectory.DeleteMenuItemFromDirectory(desiredItem))
                    {
                        Console.WriteLine($"{desiredItem.Name} has been removed.");
                    }
                    else
                    {
                        Console.WriteLine("Item not found.");
                    }
                }
                else
                {
                    Console.WriteLine("No cMenu Item has that name.");
                }
                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
        }

        private void ShowAllMenuItems()
        {
            Console.Clear();

            List<CafeMenu> ListOfMenuItems = _menuDirectory.GetMenu();
            foreach (CafeMenu menu in ListOfMenuItems)
            {
                DisplayMenu(menu);
            }
            Console.WriteLine("Press any key to continue......");
            Console.ReadKey();
        }

        private void DisplayMenu(CafeMenu menu)
        {
            Console.WriteLine($" Name: {menu.Name}\n" +
                $"Ingreedients: {menu.Ingredients}\n" +
                $"Price: {menu.Price}");
        }





        private void SeedMenuList()
        {
            CafeMenu burger = new CafeMenu(1, "Cheese Burger", "Patty, Bun, Toppings", 2.50);
            CafeMenu smFries = new CafeMenu(2, "Small French Fries", "3.0 oz Fries", 1.50);
            CafeMenu smNuggets = new CafeMenu(3, "Small Chicken Nuggets", "6 Nuggets", 2.50);

            _menuDirectory.AddMenuItemToDirectory(burger);
            _menuDirectory.AddMenuItemToDirectory(smFries);
            _menuDirectory.AddMenuItemToDirectory(smNuggets);


        }

    }
}
