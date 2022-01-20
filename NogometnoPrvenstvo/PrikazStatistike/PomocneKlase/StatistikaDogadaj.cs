using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class StatistikaDogadaj : Statistika
    {
        private string vrijeme;
        private StatistikaDogadajKlub domacin;
        private StatistikaDogadajKlub gost;

        public StatistikaDogadaj()
        {
            this.vrijeme = "";
            this.domacin = new StatistikaDogadajKlub();
            this.gost = new StatistikaDogadajKlub();
        }

        public StatistikaDogadaj(StatistikaDogadaj postojecaStatistika)
        {

            this.vrijeme = postojecaStatistika.vrijeme;
            this.domacin = new StatistikaDogadajKlub(postojecaStatistika.domacin);
            this.gost = new StatistikaDogadajKlub (postojecaStatistika.gost);
        }

        public string Vrijeme { get => vrijeme; set => vrijeme = value; }
        public StatistikaDogadajKlub Domacin { get => domacin; set => domacin = value; }
        public StatistikaDogadajKlub Gost { get => gost; set => gost = value; }
    }
}
