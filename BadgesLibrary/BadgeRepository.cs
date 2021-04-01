using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesLibrary
{
    public class BadgeRepository
    {
                        //Dictionary<KeyType, ValueType>
        private readonly Dictionary<int, Badge> _badgeDirectory = new Dictionary<int, Badge>();
        //Create
        public bool CreateNewBadge(Badge badge)
        {
            int startingCount = _badgeDirectory.Count;
            _badgeDirectory.Add(badge.BadgeNumber, badge);

            bool wasAdded = (_badgeDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public Dictionary<int, Badge> ListAllBadges(Badge badge)
        {
            return _badgeDirectory;
        }

        public Dictionary<int, Badge> GetBadges()
        {
            return _badgeDirectory;
        }


        //
        public Badge GetBadgeByBadgeNumber(int badgeNumber)
        {
            foreach (var badge in _badgeDirectory)
            {
                int badgeKey = badge.Key;
                if (badgeKey == badgeNumber)
                {
                    return badge.Value;
                }
            }
            return null;
        }


        //Update
        public bool EditBadge(int oldBadgeNumber, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByBadgeNumber(oldBadgeNumber);

            if (oldBadge != null)
            {
                oldBadge.DoorAccess = newBadge.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveDoor(int badgeNumber, string doorNumber)
        {
            foreach (var badgeID in _badgeDirectory)
            {
                if (badgeID.Value.BadgeNumber == badgeNumber)
                {
                    foreach (var door in badgeID.Value.DoorAccess)
                    {
                        if (door == doorNumber)
                        {
                            badgeID.Value.DoorAccess.Remove(door);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool AddDoor(int badgeNumber, string userAddDoorNumber)
        {
            Badge badge = GetBadgeByBadgeNumber(badgeNumber);
            if (badge == null)
            {
                return false;
            }
            else
            {
                badge.DoorAccess.Add(userAddDoorNumber);
                return true;
            }
        }



        /*NOT IN DIRECTIONS
        //Delete
        public bool DeleteBadge(Badge existingbadge)
        {
            bool deleteResult = _badgeDirectory.Remove(existingbadge);
            return deleteResult;
        }
        */

    }
}
