using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike.PomocneKlase
{
    public class IgracPostava
    {
        private string klub;
        private string igrac;
        private string pozicija;

        public string Klub { get => klub; set => klub = value; }
        public string Igrac { get => igrac; set => igrac = value; }
        public string Pozicija { get => pozicija; set => pozicija = value; }
    }
}
