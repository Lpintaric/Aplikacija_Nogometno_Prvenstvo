using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike.ObradaDogadaja
{
    public class DogadajHandlerPocetak : DogadajHandler
    {
        public DogadajHandlerPocetak(int tipDogadaja)
        {
            this.tipDogadaja = tipDogadaja;
        }

        protected override bool ObradiDogadaj(Dogadaj dogadaj)
        {
            return true;
        }
    }
}
