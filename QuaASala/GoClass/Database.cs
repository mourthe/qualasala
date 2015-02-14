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

        private static List<string> _allRoomsList;
    
        public static IList<string> GetRoomsFrom(string hour, string day)
        {
            if (_data == null) 
            {
                LoadDb();
            }
            if (_allRoomsList == null)
            {
                LoadRoomList();
            }
            
            // get all the occupied rooms for that time of day
            var occupiedRooms = (from t in _data where TimeBelongToInterval(t, hour) 
                        && t.IsOccupiedThisDay(day) select t.Sala).ToList();

            // diff the occupiedRooms from the _allRoomsList
            return _allRoomsList.Where(r => !occupiedRooms.Contains(r)).ToList();
        }

        private static void LoadRoomList()
        {
            // mudar para relativo
            var reader = new StreamReader(@"C:\Users\Fabio\Documents\GitHub\qualasala\docs\Nomes_de_salas_premitidas.txt");
            _allRoomsList = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (line == null) continue;

                _allRoomsList.Add(line);
            }
        }

        private static bool TimeBelongToInterval(DbTuple t, string hour)
        {
            return (Convert.ToInt32(hour) >= Convert.ToInt32(t.HorarioIni) &&
                     Convert.ToInt32(hour) <= Convert.ToInt32(t.HorarioFin));
        }

        private static void LoadDb()
        {
            var reader = new StreamReader(@"\Tabela_Salas.csv");
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
