using lpintaric_zadaca_3.PrikazStatistike;
using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.Entiteti.Utakmice
{
    public class Utakmica : PrvenstvoComponent
    {
        private int broj;
        private int kolo;
        private string domacin;
        private string gost;
        private string pocetak;
        private Klub domacinO;
        private Klub gostO;

        List<PrvenstvoComponent> sastaviDogadaji;

        public Utakmica(int broj, int kolo, string domacin, string gost, string pocetak)
        {
            this.Broj = broj;
            this.Kolo = kolo;
            this.Domacin = domacin;
            this.Gost = gost;
            this.Pocetak = pocetak;
            DomacinO = null;
            GostO = null;

            sastaviDogadaji = new List<PrvenstvoComponent>();
        }

        public Utakmica(int broj, int kolo, Klub domacin, Klub gost)
        {
            this.broj = broj;
            this.kolo = kolo;
            this.domacin = "";
            this.gost = "";
            this.pocetak = "";
            DomacinO = domacin;
            GostO = gost;

            sastaviDogadaji = new List<PrvenstvoComponent>();
        }

        public int Broj { get => broj; set => broj = value; }
        public int Kolo { get => kolo; set => kolo = value; }
        public string Domacin { get => domacin; set => domacin = value; }
        public string Gost { get => gost; set => gost = value; }
        public string Pocetak { get => pocetak; set => pocetak = value; }
        public Klub DomacinO { get => domacinO; set => domacinO = value; }
        public Klub GostO { get => gostO; set => gostO = value; }

        public List<SastavUtakmice> DohvatiSastave()
        {
            List<SastavUtakmice> sastavi = new List<SastavUtakmice>();
            foreach (PrvenstvoComponent k in sastaviDogadaji)
            {
                if (k is SastavUtakmice)
                {
                    sastavi.Add(k as SastavUtakmice);
                }
            }
            return sastavi;
        }

        public List<Dogadaj> DohvatiDogadaje()
        {
            List<Dogadaj> dogadaji = new List<Dogadaj>();
            foreach (PrvenstvoComponent k in sastaviDogadaji)
            {
                if (k is Dogadaj)
                {
                    dogadaji.Add(k as Dogadaj);
                }
            }
            return dogadaji;
        }

        public void DodajKomponentu(PrvenstvoComponent komponenta)
        {
            sastaviDogadaji.Add(komponenta);
        }

        public void DodajViseKomponenti(List<PrvenstvoComponent> komponente)
        {
            sastaviDogadaji.AddRange(komponente);
        }

        public override string ToString()
        {
            return $"{broj} {kolo} {domacin} {gost} {pocetak}";
        }

        public bool PostojiDogađaj(Dogadaj d)
        {
            foreach (Dogadaj dog in DohvatiDogadaje())
            {
                if(dog.Equals(d))
                {
                    return true;
                }
            }
            return false;
        }

        public override PrikazVisitor Accept(PrikazVisitor prikazVisitor)
        {
            prikazVisitor.Visit(this);
            return prikazVisitor;
        }

        
    }


}
