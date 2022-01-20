using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike.ObradaDogadaja
{
    public class DogadajHandlerZuti : DogadajHandler
    {
        public DogadajHandlerZuti(int tipDogadaja)
        {
            this.tipDogadaja = tipDogadaja;
        }

        protected override bool ObradiDogadaj(Dogadaj dogadaj)
        {
            Igrac igrac = dogadaj.IgracO;
            return igrac.State.ObradiStanje(igrac, dogadaj);
        }
    }
}
