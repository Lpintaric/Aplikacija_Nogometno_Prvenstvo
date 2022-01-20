using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class PrikazVisitorDogadaj : PrikazVisitor
    {
        private List<StatistikaDogadaj> statistike;
        private int kolo;
        private string prviKlub;
        private string drugiKlub;

        public List<StatistikaDogadaj> Statistike { get => statistike; set => statistike = value; }

        public PrikazVisitorDogadaj(int kolo, string prviKlub, string drugiKlub)
        {
            this.prviKlub = prviKlub;
            this.drugiKlub = drugiKlub;
            this.kolo = kolo;
            statistike = new List<StatistikaDogadaj>();
        }

        public override List<Statistika> Visit(Prvenstvo p)
        {
            return statistike.Cast<Statistika>().ToList();
        }

        public override void Visit(Kolo k)
        {
            if (k.Broj == kolo)
                nastavi = false;
            else
                nastavi = true;
        }

        public override void Visit(Utakmica u)
        {
            if (u.Kolo != kolo)
                return;
            if ((u.Domacin != prviKlub || u.Gost != drugiKlub) && (u.Domacin != drugiKlub || u.Gost != prviKlub))
                return;

            StatistikaDogadaj statistikaDogadaj = new StatistikaDogadaj();
            statistikaDogadaj.Domacin.NazivKluba = u.DomacinO.Naziv;
            statistikaDogadaj.Gost.NazivKluba = u.GostO.Naziv;

            List<Dogadaj> dogadajiUtakmice = u.DohvatiDogadaje();
            if (dogadajiUtakmice.Count <= 0)
            {
                Console.WriteLine("Ne postoje događaji za zadanu utakmicu !");
                return;
            }

            foreach (Dogadaj dogadaj in dogadajiUtakmice)
            {
                statistikaDogadaj = new StatistikaDogadaj(statistikaDogadaj);
                statistikaDogadaj.Vrijeme = dogadaj.Min;
                statistikaDogadaj.Domacin.Ostalo = "";
                statistikaDogadaj.Gost.Ostalo = "";

                if (dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2)
                {
                    if (dogadaj.Klub == u.Domacin)
                    {
                        statistikaDogadaj.Domacin.BrojGolova++;
                        statistikaDogadaj.Domacin.Golovi.Add(dogadaj.Igrac + " " + dogadaj.Min);
                    }
                    else if (dogadaj.Klub == u.Gost)
                    {
                        statistikaDogadaj.Gost.BrojGolova++;
                        statistikaDogadaj.Gost.Golovi.Add(dogadaj.Igrac + " " + dogadaj.Min);
                    }

                    statistikaDogadaj.Domacin.Ostalo = "";
                    statistikaDogadaj.Gost.Ostalo = "";
                }
                else if (dogadaj.Vrsta == 3)
                {
                    if (dogadaj.Klub == u.Domacin)
                    {
                        statistikaDogadaj.Gost.BrojGolova++;
                        statistikaDogadaj.Domacin.Golovi.Add("(A)" + dogadaj.Igrac + " " + dogadaj.Min);
                    }
                    else if (dogadaj.Klub == u.Gost)
                    {
                        statistikaDogadaj.Domacin.BrojGolova++;
                        statistikaDogadaj.Gost.Golovi.Add("(A)" + dogadaj.Igrac + " " + dogadaj.Min);
                    }

                }
                else if (dogadaj.Vrsta == 10 || dogadaj.Vrsta == 11 || dogadaj.Vrsta == 20)
                {
                    string dog = "";

                    if (dogadaj.Vrsta == 20)
                    {
                        dog = "IN : " + dogadaj.Zamjena + " - OUT : " + dogadaj.Igrac;
                    }
                    else if (dogadaj.Vrsta == 10)
                    {
                        dog = "Zuti : " + dogadaj.Igrac;
                    }
                    else if (dogadaj.Vrsta == 11)
                    {
                        dog = "Crveni : " + dogadaj.Igrac;
                    }

                    if (dogadaj.Klub == u.Domacin)
                    {
                        statistikaDogadaj.Domacin.Ostalo = dog;
                    }
                    else if (dogadaj.Klub == u.Gost)
                    {
                        statistikaDogadaj.Gost.Ostalo = dog;
                    }
                }
                else
                {
                    continue;
                }

                statistike.Add(statistikaDogadaj);
            }
        }
    }
}
