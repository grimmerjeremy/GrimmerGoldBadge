using ClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClaimsTest
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            Claims claimOne = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 04, 27), new DateTime(2018, 04, 27));
            Claims claimTwo = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(04 / 11 / 2018), new DateTime(04 / 12 / 2018));
            Claims claimThree = new Claims(3, ClaimType.Theft, "Stolen Pancakes.", 4.00, new DateTime(04 / 27 / 2018), new DateTime(06 / 01 / 2018));

            _repo.AddClaimToDirectory(claimOne);
            _repo.AddClaimToDirectory(claimTwo);
            _repo.AddClaimToDirectory(claimThree);
        }



        [TestMethod]
        public void EnterNewClaim()
        {
            Claims claim = new Claims();
            
            bool addClaim = _repo.AddClaimToDirectory(claim);
            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void SeeAllClaims()
        {
            Claims claim = new Claims();
            _repo.AddClaimToDirectory(claim);
            Queue<Claims> ListOfClaims = _repo.GetClaims();
            bool claimHasItem = ListOfClaims.Contains(claim);
            Assert.IsTrue(claimHasItem);
        }


        [TestMethod]
        public void DequeueNextItem()
        {
            int guessAmt = 2;
            _repo.ProcessClaim();
            Assert.AreEqual(guessAmt, _repo.GetClaims().Count);

        }
    }
}
