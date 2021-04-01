using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesLibrary
{
    public class Badge
    {
        //public enum Doors { A1, A2, A3, A4, A5, A6, A7, B1, B2, B3, B4}

        public int BadgeNumber { get; set; }
        public List<string> DoorAccess { get; set; } = new List<string>();


        public Badge(int badgeNumber, List<string> doorAccess)
        {
            BadgeNumber = badgeNumber;
            DoorAccess = doorAccess;
        }




        public Badge()
        {

        }
    }
}
