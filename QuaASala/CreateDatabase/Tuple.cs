using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
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
            return Sala + "," + HorarioIni + "," + HorarioFin + "," + Seg + "," + Ter + "," + Qua + "," + Qui + "," + Sex;
        }
    }
}
