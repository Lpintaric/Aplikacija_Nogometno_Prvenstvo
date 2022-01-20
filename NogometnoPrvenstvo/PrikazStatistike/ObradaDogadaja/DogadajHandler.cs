using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike.ObradaDogadaja
{
    public abstract class DogadajHandler
    {
        protected DogadajHandler slijedeciHandler;

        protected int tipDogadaja;

        public DogadajHandler SlijedeciHandler { set => slijedeciHandler = value; }

        public bool PristupiObradi(Dogadaj dogadaj)
        {
            if(tipDogadaja == dogadaj.Vrsta)
            {
                return ObradiDogadaj(dogadaj);
            }
            else if(slijedeciHandler != null)
            {
                return slijedeciHandler.PristupiObradi(dogadaj);
            }
            else
            {
                return false;
            }
        }
        abstract protected bool ObradiDogadaj(Dogadaj dogadaj);
    }
}
