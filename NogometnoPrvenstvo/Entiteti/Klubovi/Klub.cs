using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.Entiteti
{
    public class Klub : KluboviComponent
    {
        private string oznaka;
        private string naziv;
        private List<KluboviComponent> clanovi;


        public Klub(string oznaka, string naziv, string trener)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;

            clanovi = new List<KluboviComponent>();
            Trener t = new Trener(trener);
            clanovi.Add(t);
        }

        public string Oznaka { get => oznaka; set => oznaka = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public override List<Igrac> DohvatiIgrace()
        {
            List<Igrac> igraci = new List<Igrac>();
            foreach (KluboviComponent k in clanovi)
            {
                if (k is Igrac)
                {
                    igraci.Add(k as Igrac);
                }
            }
            return igraci;
        }

        public override Trener DohvatiTrenera()
        {
            foreach (KluboviComponent k in clanovi)
            {
                if(k is Trener){
                    return k as Trener;
                }
            }
            return null;
        }

        public override void DodajKomponentu(KluboviComponent komponenta)
        {
            clanovi.Add(komponenta);
        }

        public override string ToString()
        {
            return $"{oznaka} {naziv}";
        }
    }
}
