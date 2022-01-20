using lpintaric_zadaca_3.PrikazStatistike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.Entiteti.Utakmice
{
    public class Kolo : PrvenstvoComponent
    {
        private int broj;
        private List<PrvenstvoComponent> utakmice;

        public Kolo(int broj)
        {
            this.Broj = broj;
            utakmice = new List<PrvenstvoComponent>();
        }

        public void DodajKomponentu(PrvenstvoComponent komponenta)
        {
            utakmice.Add(komponenta);
        }

        public List<Utakmica> DohvatiUtakmice()
        {
            return utakmice.Cast<Utakmica>().ToList(); ;
        }

        public override PrikazVisitor Accept(PrikazVisitor prikazVisitor)
        {
            foreach (PrvenstvoComponent ut in utakmice)
            {
                ut.Accept(prikazVisitor);
            }
            prikazVisitor.Visit(this);
            return prikazVisitor;
        }

        public int Broj { get => broj; set => broj = value; }
    }
}
