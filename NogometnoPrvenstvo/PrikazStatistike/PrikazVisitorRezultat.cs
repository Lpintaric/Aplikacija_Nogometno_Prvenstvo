using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class PrikazVisitorRezultat : PrikazVisitor
    {
        private List<StatistikaRezultat> statistike;
        private int kolo;
        private string oznakaKluba;
        public List<StatistikaRezultat> Statistike { get => statistike; set => statistike = value; }
        public PrikazVisitorRezultat(int kolo, string oznakaKluba)
        {
            this.oznakaKluba = oznakaKluba;
            this.kolo = kolo;
            statistike = new List<StatistikaRezultat>();
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
            if (u.Domacin != oznakaKluba && u.Gost != oznakaKluba)
                return;

            List<Dogadaj> goloviUtakmice = u.DohvatiDogadaje().FindAll(d => d.Vrsta == 1 || d.Vrsta == 2 || d.Vrsta == 3);

            if (goloviUtakmice.Count <= 0)
                return;

            StatistikaRezultat sr = new StatistikaRezultat();

            int brojPostignutihGolovaDomacin = 0;
            int brojPostignutihGolovaGost = 0;

            

            brojPostignutihGolovaDomacin += goloviUtakmice.FindAll(d => (d.Vrsta == 1 || d.Vrsta == 2) && d.Klub == u.Domacin).Count;
            brojPostignutihGolovaDomacin += goloviUtakmice.FindAll(d => (d.Vrsta == 3) && d.Klub != u.Domacin).Count;

            brojPostignutihGolovaGost += goloviUtakmice.FindAll(d => (d.Vrsta == 1 || d.Vrsta == 2) && d.Klub == u.Gost).Count;
            brojPostignutihGolovaGost += goloviUtakmice.FindAll(d => (d.Vrsta == 3) && d.Klub != u.Gost).Count;

            sr.Kolo = u.Kolo;
            sr.DatumVrijeme = u.Pocetak;
            sr.Domacin = u.DomacinO.Naziv;
            sr.Gost = u.GostO.Naziv;
            sr.Rezultat = $"{brojPostignutihGolovaDomacin} : {brojPostignutihGolovaGost}";

            statistike.Add(sr);
        }
    }
}
