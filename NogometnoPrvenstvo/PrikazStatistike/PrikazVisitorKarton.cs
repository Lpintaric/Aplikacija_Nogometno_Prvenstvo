using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{

    public class PrikazVisitorKarton : PrikazVisitor
    {
        private List<StatistikaKarton> statistike;
        private int kolo;

        public List<StatistikaKarton> Statistike { get => statistike; set => statistike = value; }

        public PrikazVisitorKarton(int kolo)
        {
            this.kolo = kolo;
            statistike = new List<StatistikaKarton>();
        }

        public override List<Statistika> Visit(Prvenstvo p)
        {
            return statistike.Cast<Statistika>().ToList();
        }

        public override void Visit(Kolo k)
        {
            if (k.Broj >= kolo)
                nastavi = false;
            else
                nastavi = true;
        }

        public override void Visit(Utakmica u)
        {
            StatistikaKarton statistikaKartonDomacin = new StatistikaKarton();
            StatistikaKarton statistikaKartonGost = new StatistikaKarton();

            statistikaKartonDomacin.Klub = u.DomacinO.Naziv;
            statistikaKartonGost.Klub = u.GostO.Naziv;

            List<Dogadaj> kartoni = u.DohvatiDogadaje().FindAll(d => d.Vrsta == 10 || d.Vrsta == 11);

            List<Dogadaj> kartoniDomacin = kartoni.FindAll(d => d.Klub == u.Domacin);
            List<Dogadaj> kartoniGost = kartoni.FindAll(d => d.Klub == u.Gost);

            if (kartoni.Count <= 0)
            {
                return;
            }

            DohvatiStatistikuKartonaZaKlub(kartoniDomacin, statistikaKartonDomacin);

            DohvatiStatistikuKartonaZaKlub(kartoniGost, statistikaKartonGost);

            DodajUListu(statistike, statistikaKartonDomacin);

            DodajUListu(statistike, statistikaKartonGost);



        }

        private void DohvatiStatistikuKartonaZaKlub(List<Dogadaj> kartoniKluba, StatistikaKarton statistikaKarton)
        {
            List<Dogadaj> zutiKartoni = kartoniKluba.FindAll(d => d.Vrsta == 10);
            List<Dogadaj> crveniKartoni = kartoniKluba.FindAll(d => d.Vrsta == 11);

            List<string> igraciSaZutimKartonom = new List<string>();

            foreach (Dogadaj zutiKarton in zutiKartoni)
            {
                statistikaKarton.Zuti++;
                if (igraciSaZutimKartonom.Count > 0)
                {
                    string igracSaZutim = null;
                    igracSaZutim = igraciSaZutimKartonom.Find(x => x == zutiKarton.Igrac);
                    if (igracSaZutim != null)
                    {
                        statistikaKarton.DrugiZuti++;
                    }
                    else
                    {
                        igraciSaZutimKartonom.Add(zutiKarton.Igrac);
                    }
                }
            }

            statistikaKarton.CrveniKarton = crveniKartoni.Count;
        }

        private void DodajUListu(List<StatistikaKarton> listaStatistika, StatistikaKarton novaStatistika)
        {
            StatistikaKarton statistika = listaStatistika.Find(st => st.Klub == novaStatistika.Klub);
            if (statistika != null)
            {
                statistika.DodajKartone(novaStatistika);
            }
            else
            {
                listaStatistika.Add(new StatistikaKarton(novaStatistika));
            }
        }
    }
}
