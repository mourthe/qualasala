using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoClass
{
    public class Service
    {
        public static IList<string> GetRooms(string time, string day)
        {
            return Database.GetRoomsFrom(time, day);
        }
    }
}
