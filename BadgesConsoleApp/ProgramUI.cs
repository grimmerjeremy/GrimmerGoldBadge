using BadgesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsoleApp
{
    class ProgramUI
    {
        private readonly BadgeRepository _badgeDirectory = new BadgeRepository();

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

                Console.WriteLine("Greetings, Security Admin. How can I help you today?\n" +
                    "1: Create a new badge?\n" +
                    "2: Edit an existing badge?\n" +
                    "3: View a list of all current badges?\n" +
                    "4: Exit.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please make a selection from the options provided.\n" +
                            "Press any key to continue......");
                        Console.ReadKey();
                        break;
                }
            }

        }

        private void CreateNewBadge()
        {
            Console.Clear();
            Badge badge = new Badge();
                        
            Console.WriteLine("What is the new badge number?");
            badge.BadgeNumber = Convert.ToInt32(Console.ReadLine());

            bool addingDoors = true;
            while (addingDoors)
            {
                Setup(badge);
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Setup(badge);
                }
                if (userInput == "2")
                {
                    addingDoors = false;
                }
                else
                {
                    Console.WriteLine("Please enter either 1 or 2.");
                    addingDoors = false;
                }
            }

            _badgeDirectory.CreateNewBadge(badge);

            Console.WriteLine("If you are finished, press 'enter' to return to the main menu.");
            Console.ReadKey();

        }
        private void Setup(Badge badge) 
        {
            Console.WriteLine("What Door Number would you like to add?");
            badge.DoorAccess.Add(Console.ReadLine());

            Console.WriteLine("Would you like to add another door? \n" +
                    "1: Yes \n" +
                    "2: No");
        }
        private void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, Badge> ListOfBadges = _badgeDirectory.GetBadges();
            foreach (var badge in ListOfBadges)
            {
                DisplayBadges(badge.Value);
            }
            Console.WriteLine("Press any key to continue.......");
            Console.ReadKey();

        }

        private void DisplayBadges(Badge badge)
        {
            Console.WriteLine($"Badge #  {badge.BadgeNumber } ".PadRight(10));
            foreach (var doors in badge.DoorAccess)
            {
                Console.WriteLine(doors.PadRight(10));
            }
        }

        private void EditBadge()
        {
            Console.Clear();
            Dictionary<int, Badge> badges = _badgeDirectory.GetBadges();

            foreach (var badge in badges)
            {
                DisplayBadges(badge.Value);
            }

            Console.WriteLine("Enter the badge number you would like to update.");
            try
            {
                int userInputBadgeID = int.Parse(Console.ReadLine());
                Badge selectedBadge = _badgeDirectory.GetBadgeByBadgeNumber(userInputBadgeID);
                if (selectedBadge == null)
                {
                    Console.WriteLine("Badge ID doesn't exist.");
                }
                else
                {
                    Console.WriteLine("1: Remove a door.\n" +
                        "2: Add a door.");

                    string userInputEdit = Console.ReadLine();
                    switch (userInputEdit)
                    {
                        case "1":
                            Console.WriteLine("Please input the door number you would like to delete.");
                            string userInputDoorNumber = Console.ReadLine();
                            bool isSuccessful = _badgeDirectory.RemoveDoor(selectedBadge.BadgeNumber, userInputDoorNumber);
                            if (isSuccessful)
                            {
                                Console.WriteLine("Door removed.");
                            }
                            else
                            {
                                Console.WriteLine("You Failed.");

                            }
                            break;
                        case "2":
                            Console.WriteLine("Please input the door number you would liek to add.");
                            string userAddDoorNumber = Console.ReadLine();
                            bool isAccomplished = _badgeDirectory.AddDoor(selectedBadge.BadgeNumber, userAddDoorNumber);
                            if (isAccomplished)
                            {
                                Console.WriteLine("Door added.");
                            }
                            else
                            {
                                Console.WriteLine("You Failed.");
                                RunMenu();

                            }
                            break;
                        
                    }


                }


                Console.ReadKey();
            }
            catch (Exception)
            {

                RunMenu();



            }







        }



        
        private void SeedMenuList()
        {
            
            
            Badge badgeOne = new Badge(12345, new List<string> { "A7" });
            Badge badgeTwo = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge badgeThree = new Badge(32345, new List<string> { "A4", "A5" });

            _badgeDirectory.CreateNewBadge(badgeOne);
            _badgeDirectory.CreateNewBadge(badgeTwo);
            _badgeDirectory.CreateNewBadge(badgeThree);
        }
          

    }





}
