using BadgesLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgesTest
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepository _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepository();
            List<string> doorList = new List<string> { "A1", "A4", "A5", "A7", "B1", "B2" };
            //Door Lists group Doors
            Badge badgeOne = new Badge(12345, doorList);
            Badge badgeTwo = new Badge(22345, doorList);
            Badge badgeThree = new Badge(32345, doorList);

            _repo.CreateNewBadge(badgeOne);
            _repo.CreateNewBadge(badgeTwo);
            _repo.CreateNewBadge(badgeThree);

        }


        [TestMethod]
        public void CreateANewBadge()
        {
            Badge badge = new Badge();
            BadgeRepository repository = new BadgeRepository();
            bool addResult = repository.CreateNewBadge(badge);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void EditBadge()
        {
            List<string> doorAccess = new List<string> { "D8" };
            Badge newBadge = new Badge(12345,  doorAccess);
            BadgeRepository repository = new BadgeRepository();
            _repo.EditBadge(12345, newBadge );
            //Badge oldBadge = _repo.GetBadgeByBadgeNumber
            bool badgeUpdated = false;
            if (newBadge.BadgeNumber == 12345 && newBadge.DoorAccess == doorAccess)
            {
                badgeUpdated = true;
            }
            Assert.IsTrue(badgeUpdated);
        }

        [TestMethod]
        public void GetBadgeByNumber()
        {
            
            Badge badgeResult = _repo.GetBadgeByBadgeNumber(12345);
            
            foreach (var door in badgeResult.DoorAccess)
            {
                Console.WriteLine(door);
            }
            Assert.IsTrue(badgeResult.DoorAccess.Contains("A7"));
        }

        
        [TestMethod]
        public void ListAllBadges()
        {
            int guessCount = 3;
            Dictionary<int, Badge> ListOfBadges = _repo.GetBadges();
            
            Assert.AreEqual(guessCount,ListOfBadges.Count);
        }
        
        


    }
}
