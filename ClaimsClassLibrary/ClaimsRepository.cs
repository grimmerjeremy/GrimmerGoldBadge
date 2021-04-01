using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClassLibrary
{
    public class ClaimsRepository
    {
        //Create
        protected readonly Queue<Claims> _claimsDirectory = new Queue<Claims>();
        public bool EnterNewClaim(Claims claim)
        {
            int startingCount = _claimsDirectory.Count;
            _claimsDirectory.Enqueue(claim);
            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool AddClaimToDirectory(Claims claim)
        {
            int startingCount = _claimsDirectory.Count;

            _claimsDirectory.Enqueue(claim);

            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        
        //Read
        public Claims SeeNextClaim()
        {
            if (_claimsDirectory.Count > 0)
            {
                return _claimsDirectory.Peek();
            }
            else
            {
                return null;
            }
        }

        public bool ProcessClaim()
        {
            if (_claimsDirectory.Count > 0)
            {
                _claimsDirectory.Dequeue();
                return true;
            }
            else
            {
                return false;
            }


            /*
            int startingCount = _claimsDirectory.Count;
            _claimsDirectory.Dequeue();
            bool wasReturned = (_claimsDirectory.Count < startingCount) ? true : false;
            return wasReturned;
            */
        }
        

        //???I'm getting confused.
        //Turns out the confusion was understanding Dequeue
        //See Next VS Delete
        public Queue<Claims> ShowAllClaims(Claims claim)
        {
            return _claimsDirectory;
        }


        public Queue<Claims> GetClaims()
        {
            return _claimsDirectory;
        }

    }
}
