using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the path and the reader
            const string path = @"...\..\..\..\docs\Tabela_Salas.csv";
            var reader = new StreamReader(File.OpenRead(path));

            // forbidden room on leme
            var forbiddenRooms = GetForbiddenRooms("L");

            var rooms = new List<Tuple>();
            try
            {
                // remove the first line
                reader.ReadLine();

                // begin reading the important part of the file
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // if the first value is empty, lab, rdc, dpto or belongs to the forbidden rooms list continue
                    if (values[0].Equals(string.Empty) || values[0].Equals("RDC") 
                            || values[0].Equals("LAB") || values[0].Equals("DPTO") 
                            || forbiddenRooms.Contains(values[0])) 
                        continue;

                    rooms.Add(new Tuple(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]));
                }
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(exception.Message + "\n" + exception.InnerException.Message);
            }

            // create and fill the dictionary to merge tuples with the same ID
            var tuples = new Dictionary<string, Tuple>();
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
                    tuples[key] = Tuple.MergeTwoTuples(tuples[key], tuple);
                }
            }

            // Create a list from the dictionary
            var finalData = tuples.Values.ToList();
            var datatable = Database.Utils.ConvertToDatatable(finalData);

            Console.WriteLine("Terminou.");
            Console.WriteLine("Tamanho lista: " + rooms.Count);
            Console.WriteLine("Tamanho dicionario: " + tuples.Keys.Count);
            Console.WriteLine("Exemplo lista: " + rooms.ElementAt(3000));
            Console.WriteLine("Exemplo dicionario: " + tuples.ElementAt(501));
        }


        private static List<string> GetForbiddenRooms(string prefix)
        {
            // create the path and the reader for the forbidden rooms
            const string path = @"...\..\..\..\docs\Sala_Proibidas_Leme.txt";
            var reader = new StreamReader(File.OpenRead(path));

            // put the content of the file into a list
            var rooms = new List<string>();
            while (!reader.EndOfStream)
            {
                rooms.Add(prefix + reader.ReadLine());
            }
            
            return rooms;
        }
    }
}
