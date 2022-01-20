using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using lpintaric_zadaca_3.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class PrikazVisitorBodovi : PrikazVisitor
    {
        private List<StatistikaBodovi> statistike;
        private int kolo;

        public PrikazVisitorBodovi(int kolo, List<Klub> sviKlubovi)
        {
            this.kolo = kolo;
            
             
            statistike = new List<StatistikaBodovi>();
            foreach (Klub k in sviKlubovi)
            {
                StatistikaBodovi statistikaKluba = new StatistikaBodovi();
                statistikaKluba.Klub = k.Naziv;
                statistikaKluba.Trener = k.DohvatiTrenera().ImePrezime;
                statistike.Add(statistikaKluba);
            }

        }

        public List<StatistikaBodovi> Statistike { get => statistike; }

        public override List<Statistika> Visit(Prvenstvo p)
        {
            return statistike.Cast<Statistika>().ToList();
        }

        public override void Visit(Kolo k)
        {
            if(k.Broj >= kolo)
                nastavi = false;
            else
                nastavi = true;
        }


        public override void Visit(Utakmica u)
        {
            StatistikaBodovi statistikaDomacin = new StatistikaBodovi();
            StatistikaBodovi statistikaGost = new StatistikaBodovi();

            statistikaDomacin.Klub = u.DomacinO.Naziv;
            statistikaGost.Klub = u.GostO.Naziv;

            List<Dogadaj> dogUtakmice = u.DohvatiDogadaje();
            if (dogUtakmice.Count <= 0)
            {
                return;
            }

            statistikaDomacin.OdigranaKola++;
            statistikaGost.OdigranaKola++;

            statistikaDomacin.BrojPostignutihGolova = dogUtakmice.FindAll(x => (x.Vrsta == 1 || x.Vrsta == 2) && x.Klub == u.Domacin).Count;
            statistikaDomacin.BrojPostignutihGolova += dogUtakmice.FindAll(x => (x.Vrsta == 3) && x.Klub != u.Domacin).Count;
            statistikaGost.BrojPrimljenihGolova = statistikaDomacin.BrojPostignutihGolova;

            statistikaGost.BrojPostignutihGolova = dogUtakmice.FindAll(x => (x.Vrsta == 1 || x.Vrsta == 2) && x.Klub == u.Gost).Count;
            statistikaGost.BrojPostignutihGolova += dogUtakmice.FindAll(x => (x.Vrsta == 3) && x.Klub != u.Gost).Count;
            statistikaDomacin.BrojPrimljenihGolova = statistikaGost.BrojPostignutihGolova;

            if (statistikaDomacin.BrojPostignutihGolova > statistikaGost.BrojPostignutihGolova)
            {
                statistikaDomacin.BrojPobjeda++;
                statistikaGost.BrojPoraza++;
            }
            if (statistikaDomacin.BrojPostignutihGolova == statistikaGost.BrojPostignutihGolova)
            {
                statistikaDomacin.BrojNerijesenih++;
                statistikaGost.BrojNerijesenih++;
            }
            if (statistikaDomacin.BrojPostignutihGolova < statistikaGost.BrojPostignutihGolova)
            {
                statistikaDomacin.BrojPoraza++;
                statistikaGost.BrojPobjeda++;
            }

            DodajUListu(statistike, statistikaDomacin);
            DodajUListu(statistike, statistikaGost);
        }



        private void DodajUListu(List<StatistikaBodovi> listaStatistika, StatistikaBodovi novaStatistika)
        {
            StatistikaBodovi statistika = listaStatistika.Find(st => st.Klub == novaStatistika.Klub);
            if (statistika != null)
            {
                statistika.DodajBodove(novaStatistika);
            }
            else
            {
                listaStatistika.Add(new StatistikaBodovi(novaStatistika));
            }
        }

    }
}
