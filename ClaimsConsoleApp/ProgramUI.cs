using ClaimsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsConsoleApp
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _claimsDirectory = new ClaimsRepository();
        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }


        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("How can I help you today? Would you like to: \n" +
                    "1: See all claims.\n" +
                    "2: Access next claim.\n" +
                    "3: Enter a new claim.\n" +
                    "4: Exit Program.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        PeekNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry. \n" +
                            "Please make a selection from the available options.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;

                }
            }
        }

        private void ShowAllClaims()
        {
            Console.Clear();

            Queue<Claims> ListOfClaims = _claimsDirectory.GetClaims();
            foreach (Claims claim in ListOfClaims)
            {
                DisplayClaims(claim);

                //Console.WriteLine("Total Claims: "{claimID.Count}"."); 
                //(Something Missing)
            }
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }

        private void DisplayClaims(Claims claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimID} \n" +
                $"Claim Type: {claim.ClaimType} \n" +
                $"Description: {claim.Description} \n" +
                $"Claim Amount: {claim.ClaimAmount} \n" +
                $"Date Of Incident: {claim.DateOfIncident} \n" +
                $"Date of Claim: {claim.DateOfClaim} \n" +
                $"Is Valid {claim.IsValid}");
        }


        private void PeekNextClaim()
        {
            Console.Clear();
            Queue<Claims> ListOfClaims = _claimsDirectory.GetClaims();
            Claims claim = _claimsDirectory.SeeNextClaim();
            if (claim == null)
            {
                Console.WriteLine("There are no more claims to be processed.");
                Console.ReadKey();
            }
            else
            {
                DisplayClaims(claim);
                Console.WriteLine("This is the next clam.: \n" +
                    "Press -y- to pull this claim off the top of the list. \n" +
                    "Press -n- to return to the Main Menu.");
                string userInput = Console.ReadLine();

                if (userInput == "y")
                {
                    Dequeue();
                   
                }
                else
                {
                    RunMenu();
                }
            }

            /*
            switch (userInput)
            {
                case "y":
                    Dequeue();
                    break;
                case "n":
                    ReturnToMain();
                    break;
                default:
                    Console.WriteLine("Invalid entry. \n" +
                        "Please make a selection from the available options.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    break;

            }
            */
        }
        private void Dequeue()
        {
            bool isSuccessful = _claimsDirectory.ProcessClaim();
            if (isSuccessful)
            {
                Console.WriteLine("Claim has been processed.");
            }
            else
            {
                Console.WriteLine("Claim has not ben processed.");
            }
            Console.ReadKey();
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claims claim = new Claims();

            Console.WriteLine("New Claim Entry Log.");

            Console.WriteLine("Enter the claim ID: ");
            claim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the claim type: \n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please choose from the available options.\n" +
                        "Press any key to continue......");
                    Console.ReadKey();
                    break;
            }

            Console.WriteLine("Enter a claim Description: ");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount of the damage: ");
            claim.ClaimAmount = double.Parse(Console.ReadLine());


            Console.WriteLine("Enter the date of the accident using MM/DD/YYYY: ");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the claim using MM/DD/YYYY: ");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimsDirectory.AddClaimToDirectory(claim);




        }



        private void SeedClaimList()
        {
            Claims claimOne = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 04, 27), new DateTime(2018, 04, 27));
            Claims claimTwo = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(04 / 11 / 2018), new DateTime(04 / 12 / 2018));
            Claims claimThree = new Claims(3, ClaimType.Theft, "Stolen Pancakes.", 4.00, new DateTime(04 / 27 / 2018), new DateTime(06 / 01 / 2018));

            _claimsDirectory.AddClaimToDirectory(claimOne);
            _claimsDirectory.AddClaimToDirectory(claimTwo);
            _claimsDirectory.AddClaimToDirectory(claimThree);
        }


    }
}
