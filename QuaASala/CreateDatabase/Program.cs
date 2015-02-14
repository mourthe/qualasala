﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CreateDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the path and the reader
            const string path = @"...\..\..\..\docs\Tabela_Salas.csv";
            var reader = new StreamReader(File.OpenRead(path));

            // forbidden room on PUC
            var forbiddenRooms = GetForbiddenRooms();

            var rooms = new List<DbTuple>();
            try
            {
                // remove the first line
                reader.ReadLine();

                // begin reading the important part of the file
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    
                    var values = line.Split(',');

                    // if the first value is empty, lab, rdc, dpto or belongs to the forbidden rooms list continue 
                    if (values[0].Equals(string.Empty) || values[0].Equals("RDC") || values[0].Equals("LAB") 
                        || values[0].Equals("DPTO") || values[0].ElementAt(0) == 'I' || values[0].ElementAt(0) == 'R' 
                        || values[0].Equals("LAC") || values[0].ElementAt(0) == 'C' || values[0].ElementAt(0) == 'D'
                        || forbiddenRooms.Contains(values[0]) || values[0].Equals("LAMAQ") || values[0].Equals("SPA")
                        || values[0].Equals("FB6") || values[0].Equals("LABHD") || values[0].Equals("LBIAG") 
                        || values[0].Equals("LIENG") || values[0].Equals("PIUES") || values[0].Contains("ARTE")) 
                        continue;

                    rooms.Add(new DbTuple(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]));
                }
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(exception.Message + "\n" + exception.InnerException.Message);
            }

            // create and fill the dictionary to merge tuples with the same ID
            var tuples = new Dictionary<string, DbTuple>();
            foreach (var tuple in rooms)
            {
                var key = tuple.Sala + "," + tuple.HorarioIni + "," + tuple.HorarioFin;

                // check if there is a tuple with the same id on the dictionary
                if (!tuples.ContainsKey(key))
                {
                    tuples.Add(key, tuple);
                }
                // there is a key 
                else
                {
                    tuples[key] = DbTuple.MergeTwoTuples(tuples[key], tuple);
                }
            }

            // Create a list from the dictionary
            var finalData = tuples.Values.ToList().OrderBy(x=>x.Sala).ToList();
            
            Console.WriteLine("Tamanho lista: " + rooms.Count);
            Console.WriteLine("Tamanho dicionario: " + tuples.Keys.Count);
            Console.WriteLine("Exemplo lista: " + rooms.ElementAt(3000));
            Console.WriteLine("Exemplo dicionario: " + tuples.ElementAt(501));

            // save the datatable on a csv file
            Database.Utils.SaveDataOnCsv(finalData);

            Console.WriteLine("Terminou.");
            Console.ReadLine();
        }


        private static List<string> GetForbiddenRooms()
        {
            // create the path and the reader for the forbidden rooms
            var result = new List<string>();
            GetForbiddenRoomsForBuilding(result, @"...\..\..\..\docs\Sala_Proibidas_Leme.txt", "L");
            GetForbiddenRoomsForBuilding(result, @"...\..\..\..\docs\Sala_Proibidas_Kennedy.txt", "K");
            GetForbiddenRoomsForBuilding(result, @"...\..\..\..\docs\Sala_Proibidas_Frings.txt", "F");

            return result;
        }

        private static void GetForbiddenRoomsForBuilding(List<string> rooms, string path, string prefix)
        {
            var reader = new StreamReader(File.OpenRead(path));

            // put the content of the file into a list
            while (!reader.EndOfStream)
            {
                rooms.Add(prefix + reader.ReadLine());
            }
        }

        private static string[] _rooms = {"F200","F200",
"F200",
"F200",
"F200",
"F200",
"F200",
"F200",
"F200",
"F200A",
"F200A",
"F200A",
"F200A",
"F200A",
"F200A",
"F200A",
"F200A",
"F200A",
"F200A",
"F201",
"F201",
"F201",
"F201",
"F201",
"F201",
"F201",
"F201",
"F201",
"F201A",
"F201A",
"F201A",
"F201A",
"F201A",
"F201A",
"F201A",
"F201A",
"F202",
"F202",
"F202",
"F202",
"F202",
"F202",
"F202",
"F202",
"F206",
"F206",
"F206",
"F206",
"F206",
"F206",
"F206",
"F206",
"F300",
"F300",
"F300",
"F300",
"F300",
"F301",
"F301",
"F301",
"F301",
"F301",
"F301",
"F301",
"F301A",
"F301A",
"F301A",
"F301A",
"F301A",
"F301A",
"F301A",
"F301A",
"F301A",
"F301A",
"F301A",
"F302",
"F302",
"F302",
"F302",
"F302",
"F302",
"F302",
"F302",
"F302",
"F306",
"F306",
"F306",
"F306",
"F308",
"F308",
"F308",
"F308",
"F308",
"F308",
"F308",
"F308",
"F308",
"F308",
"F310",
"F310",
"F310",
"F310",
"F310",
"F310",
"F310",
"F310",
"F310",
"F310",
"F310",
"F310",
"F400",
"F400",
"F400",
"F400",
"F400",
"F400",
"F400",
"F400",
"F400A",
"F400A",
"F400A",
"F400A",
"F400A",
"F400A",
"F400A",
"F400A",
"F400A",
"F400A",
"F401",
"F401",
"F401",
"F401",
"F401",
"F401",
"F401",
"F401",
"F401",
"F402",
"F402",
"F402",
"F402",
"F402",
"F402",
"F402",
"F402",
"F406",
"F406",
"F406",
"F406",
"F406",
"F406",
"F406",
"F406",
"F408",
"F408",
"F408",
"F408",
"F408",
"F408",
"F408",
"F410",
"F410",
"F410",
"F410",
"F410",
"F410",
"F410",
"F410",
"F502",
"F502",
"F502",
"F502",
"F502",
"F502",
"F502",
"F502",
"F502",
"F506",
"F506",
"F506",
"F506",
"F506",
"F506",
"F506",
"F506",
"F515",
"F602",
"F602",
"F602",
"F602",
"F602",
"F602",
"F602",
"F602",
"F606",
"F606",
"F606",
"F606",
"F606",
"F606",
"F606",
"F606",
"F610",
"F610",
"F610",
"F610",
"F610",
"F610",
"F610",
"F610",
"F610",
"F610",
"K101",
"K101",
"K101",
"K101",
"K101",
"K101",
"K103",
"K103",
"K103",
"K103",
"K103",
"K103",
"K104",
"K104",
"K104",
"K104",
"K104",
"K104",
"K105",
"K105",
"K105",
"K105",
"K105",
"K105",
"K108",
"K108",
"K108",
"K108",
"K108",
"K108",
"K109",
"K109",
"K109",
"K109",
"K109",
"K109",
"K110",
"K110",
"K110",
"K110",
"K110",
"K110",
"K112",
"K112",
"K112",
"K112",
"K112",
"K112",
"K113",
"K113",
"K113",
"K113",
"K113",
"K113",
"K114",
"K114",
"K114",
"K114",
"K114",
"K114",
"K116",
"K116",
"K116",
"K116",
"K116",
"K116",
"K116",
"K117",
"K117",
"K117",
"K117",
"K117",
"K117",
"K118",
"K118",
"K118",
"K118",
"K118",
"K118",
"K120",
"K120",
"K120",
"K120",
"K120",
"K120",
"K122",
"K122",
"K122",
"K122",
"K122",
"K122",
"K123",
"K123",
"K123",
"K123",
"K123",
"K123",
"K123",
"K123",
"K124",
"K124",
"K124",
"K124",
"K124",
"K124",
"K124",
"K124",
"K124",
"K128",
"K128",
"K128",
"K128",
"K128",
"K128",
"K128",
"K611",
"K611",
"K611",
"K611",
"K611",
"K611",
"K613",
"K613",
"K613",
"K613",
"K613",
"K613",
"K613",
"K615",
"K615",
"K615",
"K615",
"K615",
"K615",
"K617",
"K617",
"K617",
"K617",
"K617",
"K617",
"K617",
"K617",
"K618",
"K618",
"K618",
"K618",
"K618",
"K618",
"K618",
"K618",
"K618",
"L106",
"L106",
"L106",
"L106",
"L106",
"L106",
"L106",
"L106",
"L110",
"L110",
"L110",
"L110",
"L110",
"L110",
"L110",
"L110",
"L110",
"L114",
"L114",
"L114",
"L114",
"L114",
"L114",
"L118",
"L118",
"L118",
"L118",
"L118",
"L118",
"L118",
"L118",
"L118",
"L118",
"L120",
"L120",
"L120",
"L120",
"L120",
"L120",
"L120",
"L120",
"L120",
"L120",
"L128",
"L128",
"L128",
"L128",
"L128",
"L142",
"L142",
"L142",
"L142",
"L142",
"L142",
"L142",
"L144",
"L144",
"L144",
"L144",
"L144",
"L144",
"L144",
"L148",
"L148",
"L148",
"L148",
"L148",
"L148",
"L150",
"L150",
"L150",
"L150",
"L150",
"L150",
"L150",
"L150",
"L154",
"L154",
"L154",
"L154",
"L154",
"L154",
"L154",
"L154",
"L160",
"L160",
"L160",
"L160",
"L160",
"L160",
"L160",
"L160",
"L164",
"L164",
"L164",
"L164",
"L164",
"L164",
"L164",
"L164",
"L164",
"L206",
"L206",
"L206",
"L206",
"L206",
"L206",
"L206",
"L206",
"L206",
"L210",
"L210",
"L210",
"L210",
"L210",
"L210",
"L210",
"L210",
"L214",
"L214",
"L214",
"L214",
"L214",
"L214",
"L214",
"L214",
"L214",
"L216",
"L216",
"L216",
"L216",
"L216",
"L216",
"L216",
"L216",
"L216",
"L216",
"L216",
"L218",
"L218",
"L218",
"L218",
"L218",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L222",
"L224",
"L224",
"L224",
"L224",
"L224",
"L224",
"L224",
"L224",
"L224",
"L224",
"L224",
"L232",
"L232",
"L232",
"L232",
"L232",
"L232",
"L232",
"L232",
"L232",
"L232",
"L234",
"L234",
"L234",
"L234",
"L234",
"L234",
"L234",
"L234",
"L234",
"L234",
"L238",
"L238",
"L238",
"L238",
"L238",
"L238",
"L238",
"L242",
"L242",
"L242",
"L242",
"L242",
"L242",
"L242",
"L250",
"L250",
"L250",
"L250",
"L250",
"L250",
"L250",
"L250",
"L250",
"L250",
"L250",
"L250",
"L260",
"L260",
"L260",
"L260",
"L260",
"L260",
"L260",
"L260",
"L260",
"L274",
"L274",
"L274",
"L274",
"L274",
"L310",
"L310",
"L310",
"L310",
"L310",
"L310",
"L310",
"L324",
"L324",
"L324",
"L324",
"L324",
"L324",
"L324",
"L324",
"L324",
"L328",
"L328",
"L328",
"L328",
"L328",
"L328",
"L328",
"L328",
"L328",
"L330",
"L330",
"L330",
"L330",
"L330",
"L330",
"L330",
"L330",
"L332",
"L332",
"L332",
"L332",
"L332",
"L332",
"L332",
"L332",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L336",
"L338",
"L338",
"L338",
"L338",
"L338",
"L338",
"L338",
"L338",
"L338",
"L338",
"L338",
"L338",
"L376A",
"L401",
"L401",
"L401",
"L408",
"L408",
"L408",
"L408",
"L408",
"L408",
"L408",
"L408",
"L408",
"L408",
"L408",
"L408",
"L408",
"L410",
"L410",
"L410",
"L410",
"L410",
"L410",
"L410",
"L410",
"L410",
"L410",
"L414",
"L414",
"L414",
"L414",
"L414",
"L414",
"L414",
"L418",
"L418",
"L418",
"L418",
"L418",
"L418",
"L418",
"L418",
"L418",
"L418",
"L422",
"L422",
"L422",
"L422",
"L422",
"L422",
"L422",
"L422",
"L422",
"L422",
"L422",
"L422",
"L422",
"L428",
"L428",
"L428",
"L428",
"L428",
"L428",
"L428",
"L428",
"L428",
"L428",
"L428",
"L428",
"L438",
"L438",
"L438",
"L438",
"L438",
"L438",
"L438",
"L438",
"L438",
"L438",
"L438",
"L438",
"L442",
"L442",
"L442",
"L442",
"L442",
"L442",
"L446",
"L446",
"L446",
"L446",
"L446",
"L446",
"L446",
"L446",
"L446",
"L446",
"L450",
"L450",
"L450",
"L450",
"L450",
"L450",
"L450",
"L450",
"L450",
"L450",
"L452",
"L452",
"L452",
"L452",
"L452",
"L452",
"L452",
"L452",
"L452",
"L454",
"L454",
"L454",
"L454",
"L454",
"L454",
"L454",
"L454",
"L456",
"L456",
"L456",
"L456",
"L456",
"L456",
"L456",
"L462",
"L462",
"L462",
"L462",
"L462",
"L462",
"L462",
"L464",
"L464",
"L464",
"L464",
"L464",
"L464",
"L464",
"L480",
"L480",
"L480",
"L480",
"L480",
"L480",
"L480",
"L480",
"L480",
"L480",
"L481",
"L481",
"L481",
"L481",
"L481",
"L481",
"L481",
"L481",
"L481",
"L481",
"L481",
"L504",
"L504",
"L504",
"L504",
"L504",
"L504",
"L504",
"L506",
"L506",
"L506",
"L506",
"L506",
"L506",
"L506",
"L506",
"L506",
"L508",
"L508",
"L508",
"L508",
"L508",
"L508",
"L508",
"L508",
"L510",
"L510",
"L510",
"L510",
"L510",
"L510",
"L510",
"L510",
"L510",
"L512",
"L512",
"L512",
"L512",
"L512",
"L514",
"L514",
"L514",
"L514",
"L514",
"L514",
"L514",
"L514",
"L516",
"L516",
"L516",
"L516",
"L516",
"L516",
"L518",
"L518",
"L518",
"L518",
"L518",
"L518",
"L518",
"L518",
"L518",
"L520",
"L520",
"L520",
"L520",
"L520",
"L520",
"L520",
"L520",
"L522",
"L522",
"L522",
"L522",
"L522",
"L522",
"L522",
"L522",
"L522",
"L522",
"L524",
"L524",
"L524",
"L524",
"L524",
"L524",
"L524",
"L524",
"L526",
"L526",
"L526",
"L526",
"L526",
"L526",
"L528",
"L528",
"L528",
"L528",
"L528",
"L530",
"L530",
"L530",
"L530",
"L530",
"L530",
"L530",
"L530",
"L530",
"L530",
"L530",
"L532",
"L532",
"L532",
"L532",
"L532",
"L532",
"L532",
"L532",
"L532",
"L532",
"L542",
"L542",
"L542",
"L542",
"L542",
"L542",
"L542",
"L542",
"L542",
"L542",
"L570",
"L570",
"L570",
"L570",
"L570",
"L570",
"L570",
"L570",
"L570",
"L581",
"L581",
"L581",
"L581",
"L581",
"L581",
"L581",
"L581",
"L582",
"L582",
"L582",
"L582",
"L582",
"L582",
"L582",
"L582",
"L582",
"L582",
"L649",
"L649",
"L649",
"L649",
"L658",
"L658",
"L658",
"L658",
"L658",
"L658",
"L658",
"L658",
"L658",
"L658",
"L658",
"L658",
"L658",
"L664",
"L664",
"L664",
"L664",
"L664",
"L664",
"L664",
"L664",
"L774",
"L774",
"L774",
"L774",
"L774",
"L774",
"L774",
"L774",
"L776",
"L776",
"L776",
"L776",
"L776",
"L776",
"L776",
"L856",
"L856",
"L856"};
    }
}
