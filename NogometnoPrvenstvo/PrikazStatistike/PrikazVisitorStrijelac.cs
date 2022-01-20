using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class PrikazVisitorStrijelac : PrikazVisitor
    {
        private List<StatistikaStrijelac> statistike;
        private int kolo;

        public List<StatistikaStrijelac> Statistike { get => statistike; set => statistike = value; }

        public PrikazVisitorStrijelac(int kolo)
        {
            this.kolo = kolo;
            statistike = new List<StatistikaStrijelac>();
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
            StatistikaStrijelac statistikaIgraca;
            List<Dogadaj> goloviUtakmice = u.DohvatiDogadaje().FindAll(d => (d.Vrsta == 1 || d.Vrsta == 2));
            if (goloviUtakmice.Count <= 0)
            {
                return;
            }

            foreach (Dogadaj gol in goloviUtakmice)
            {
                statistikaIgraca = new StatistikaStrijelac(gol.Igrac, 1, gol.KlubO.Naziv);
                DodajUListu(statistike, statistikaIgraca);
            }


        }

        private void DodajUListu(List<StatistikaStrijelac> listaStatistika, StatistikaStrijelac novaStatistika)
        {
            StatistikaStrijelac statistika = listaStatistika.Find(st => st.Igrac == novaStatistika.Igrac);
            if (statistika != null)
            {
                statistika.DodajGolove(novaStatistika);
            }
            else
            {
                listaStatistika.Add(new StatistikaStrijelac(novaStatistika));
            }
        }
    }
}
