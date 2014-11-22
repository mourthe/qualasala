using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CreateDatabase;

namespace GoClass
{
    public static class Database
    {
        private static List<DbTuple> _data;

        public static IList<string> GetRoomsFrom(string hour, string day)
        {
            if (_data == null) 
            {
                LoadDb();
            }
            
            // foreach line on the file 
            return (from t in _data where TimeBelongToInterval(t, hour) && t.IsFreeThisDay(day) select t.Sala).ToList();           
        }

        private static bool TimeBelongToInterval(DbTuple t, string hour)
        {
            return (Convert.ToInt32(hour) >= Convert.ToInt32(t.HorarioIni) &&
                     Convert.ToInt32(hour) <= Convert.ToInt32(t.HorarioFin));
        }

        private static void LoadDb()
        {
            var reader = new StreamReader(@"C:\Users\Fabio\Documents\GitHub\qualasala\QuaASala\GoClass\Database\Tabela_Salas.csv");
            _data = new List<DbTuple>();

            while (!reader.EndOfStream)
            {
                var readLine = reader.ReadLine();
                if (readLine == null) continue;

                var values = readLine.Split(',');
                   
                _data.Add(new DbTuple(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]));
            }
        }
    }
}
