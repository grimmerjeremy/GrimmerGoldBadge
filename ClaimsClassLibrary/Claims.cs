using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClassLibrary
{
    public enum ClaimType { Car, Home, Theft}
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                DateTime dateOfIncident = DateOfIncident;
                DateTime dateOfClaim = DateOfClaim;

                TimeSpan difference = dateOfClaim - dateOfIncident;
                if (difference.Days < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public Claims(int claimID,
            ClaimType claimType,
            string description,
            double claimAmount,
            DateTime dateOfIncident,
            DateTime dateOfClaim)


        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

        }
        public Claims()
        {

        }
    }
}
