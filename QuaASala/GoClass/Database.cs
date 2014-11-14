using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GoClass
{
    public static class Database
    {
        private static List<CreateDatabase.dbTuple> _data = null;

        public static IList<string> GetRoomsFrom(string hour, string day)
        {
            if (_data == null) 
            {
                LoadDb();
            }
            
            // create the list
            var freeRooms = new List<string>();
            
            // foreach line on the file 
            foreach (var t in _data)
	        {
                if (TimeBelongToInterval(t, hour) && t.IsFreeThisDay(day))
                {
                    freeRooms.Add(t.Sala);
                }
	        }

            return freeRooms;           
        }

        private static bool TimeBelongToInterval(CreateDatabase.dbTuple t, string hour)
        {
            return (Convert.ToInt32(hour) >= Convert.ToInt32(t.HorarioIni) &&
                     Convert.ToInt32(hour) <= Convert.ToInt32(t.HorarioFin));
        }

        private static void LoadDb()
        {
            var reader = new StreamReader(@"...\..\..\..\QuaASala\GoClass\Database\Tabela_Salas.csv");

            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(',');
                    
                _data.Add(new CreateDatabase.dbTuple(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]));
            }
        }
    }
}
