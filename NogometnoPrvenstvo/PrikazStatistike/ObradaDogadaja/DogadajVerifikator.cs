using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike.ObradaDogadaja
{
    public class DogadajVerifikator
    {
        private static DogadajVerifikator instanca;

        DogadajHandler dogadajHandlerPocetak;
        DogadajHandler dogadajHandlerGol;
        DogadajHandler dogadajHandlerGolPenal;
        DogadajHandler dogadajHandlerAutogol;
        DogadajHandler dogadajHandlerZuti;
        DogadajHandler dogadajHandlerCrveni;
        DogadajHandler dogadajHandlerZamjena;
        DogadajHandler dogadajHandlerKraj;

        public DogadajVerifikator()
        {
            PostaviLanacProvjere();
        }

        public DogadajHandler dohvatiLanacProvjere()
        {
            return dogadajHandlerPocetak;
        }

        private void PostaviLanacProvjere()
        {
            dogadajHandlerPocetak = new DogadajHandlerPocetak(0);
            dogadajHandlerGol = new DogadajHandlerGol(1);
            dogadajHandlerGolPenal = new DogadajHandlerGolPenal(2);
            dogadajHandlerAutogol = new DogadajHandlerAutogol(3);
            dogadajHandlerZuti = new DogadajHandlerZuti(10);
            dogadajHandlerCrveni = new DogadajHandlerCrveni(11);
            dogadajHandlerZamjena = new DogadajHandlerZamjena(20);
            dogadajHandlerKraj = new DogadajHandlerKraj(99);

            dogadajHandlerPocetak.SlijedeciHandler = dogadajHandlerGol;
            dogadajHandlerGol.SlijedeciHandler = dogadajHandlerGolPenal;
            dogadajHandlerGolPenal.SlijedeciHandler = dogadajHandlerAutogol;
            dogadajHandlerAutogol.SlijedeciHandler = dogadajHandlerZuti;
            dogadajHandlerZuti.SlijedeciHandler = dogadajHandlerCrveni;
            dogadajHandlerCrveni.SlijedeciHandler = dogadajHandlerZamjena;
            dogadajHandlerZamjena.SlijedeciHandler = dogadajHandlerKraj;
        }

        public static DogadajVerifikator dohvatiInstancu()
        {
            if (instanca == null)
            {
                instanca = new DogadajVerifikator();
            }
            return instanca;
        }


    }
}
