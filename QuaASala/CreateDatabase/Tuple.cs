using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    [Serializable]
    public class Tuple
    {
        public Tuple(string sala, string horarioIni, string horarioFin, string seg, string ter, string qua, string qui, string sex)
        {
            Sex = sex.Contains('1');
            Qui = qui.Contains('1');
            Qua = qua.Contains('1');
            Ter = ter.Contains('1');
            Seg = seg.Contains('1');
            HorarioFin = horarioFin;
            HorarioIni = horarioIni;
            Sala = sala;
        }

        private Tuple(string sala, string horarioIni, string horarioFin, bool seg, bool ter, bool qua, bool qui, bool sex)
        {
            Sex = sex;
            Qui = qui;
            Qua = qua;
            Ter = ter;
            Seg = seg;
            HorarioFin = horarioFin;
            HorarioIni = horarioIni;
            Sala = sala;
        } 

        public string Sala { get; private set; }
        public string HorarioIni { get; private set; }
        public string HorarioFin { get; private set; }
        public bool Seg { get; private set; }
        public bool Ter { get; private set; }
        public bool Qua { get; private set; }
        public bool Qui { get; private set; }
        public bool Sex { get; private set; }

        public override string ToString()
        {
            return Sala + "," + HorarioIni + "," + HorarioFin + "," + ConvertToBinary(Seg) + ","
                                                                    + ConvertToBinary(Ter) + ","
                                                                    + ConvertToBinary(Qua) + ","
                                                                    + ConvertToBinary(Qui) + ","
                                                                    + ConvertToBinary(Sex);
        }

        public static Tuple MergeTwoTuples(Tuple tuple1, Tuple tuple2)
        {
            if (tuple1.Sala.Equals(tuple2.Sala) && tuple1.HorarioFin.Equals(tuple2.HorarioFin)
                && tuple1.HorarioIni.Equals(tuple2.HorarioIni))
            {
                return new Tuple(tuple1.Sala, tuple1.HorarioIni, tuple1.HorarioFin, tuple1.Seg || tuple2.Seg,
                                                                                    tuple1.Ter || tuple2.Ter,
                                                                                    tuple1.Qua || tuple2.Qua,
                                                                                    tuple1.Qui || tuple2.Qui,
                                                                                    tuple1.Sex || tuple2.Sex);
            }
            else
            {
                throw new Exception("Tuples not compatible.");
            }
        }

        private static string ConvertToBinary(bool b)
        {
            return b ? "1" : "0";
        }
    }
}
