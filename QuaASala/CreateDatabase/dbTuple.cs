using System;
using System.Linq;

namespace CreateDatabase
{
    [Serializable]
    public class DbTuple
    {
        public DbTuple (string sala, string horarioIni, string horarioFin, string seg, string ter, string qua, string qui, string sex)
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

        public DbTuple(string sala, string horarioIni, string horarioFin, bool seg, bool ter, bool qua, bool qui, bool sex)
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

        /// <summary>
        /// Returns if the rooms is available  on the requested day
        /// </summary>
        /// <param name="day">Needs to follow patern: Monday = seg, Tuesday = ter, Wednesday = qua, Thursday = qui, Friday = sex</param>
        public bool IsFreeThisDay(string day)
        {
            switch (day)
            {
                case "seg": return !Seg;
                case "ter": return !Ter;
                case "qua": return !Qua;
                case "qui": return !Qui;
                case "sex": return !Sex;
                default:
                    throw new  ArgumentException("Day do not belong");
            }
        }

        /// <summary>
        /// Returns if the rooms is not available on the requested day
        /// </summary>
        /// <param name="day">Needs to follow patern: Monday = seg, Tuesday = ter, Wednesday = qua, Thursday = qui, Friday = sex</param>
        public bool IsOccupiedThisDay(string day)
        {
            return !IsFreeThisDay(day);
        }

        public static DbTuple MergeTwoTuples(DbTuple tuple1, DbTuple tuple2)
        {
            if (tuple1.Sala.Equals(tuple2.Sala) && tuple1.HorarioFin.Equals(tuple2.HorarioFin)
                && tuple1.HorarioIni.Equals(tuple2.HorarioIni))
            {
                return new DbTuple(tuple1.Sala, tuple1.HorarioIni, tuple1.HorarioFin, tuple1.Seg || tuple2.Seg,
                                                                                    tuple1.Ter || tuple2.Ter,
                                                                                    tuple1.Qua || tuple2.Qua,
                                                                                    tuple1.Qui || tuple2.Qui,
                                                                                    tuple1.Sex || tuple2.Sex);
            }
            
            throw new Exception("Tuples not compatible.");
        }

        private static string ConvertToBinary(bool b)
        {
            return b ? "1" : "0";
        }
    }
}
