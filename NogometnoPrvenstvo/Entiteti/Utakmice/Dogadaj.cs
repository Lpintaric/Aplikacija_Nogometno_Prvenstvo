using lpintaric_zadaca_3.PrikazStatistike;
using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.Entiteti.Utakmice
{
    public class Dogadaj : PrvenstvoComponent
    {
        private int broj;
        private string min;
        private int vrsta;
        private string klub;
        private string igrac;
        private string zamjena;
        private Klub klubO;
        private Igrac igracO;
        private Igrac zamjenaO;

        public Dogadaj(DogadajBuilder b)
        {
            this.broj = b.Broj;
            this.min = b.Min;
            this.vrsta = b.Vrsta;
            this.klub = b.Klub;
            this.igrac = b.Igrac;
            this.zamjena = b.Zamjena;
            this.klubO = null;
            this.igracO = null;
            this.zamjenaO = null;
        }


        public int Broj { get => broj; set => broj = value; }
        public string Min { get => min; set => min = value; }
        public int Vrsta { get => vrsta; set => vrsta = value; }
        public string Klub { get => klub; set => klub = value; }
        public string Igrac { get => igrac; set => igrac = value; }
        public string Zamjena { get => zamjena; set => zamjena = value; }
        public Klub KlubO { get => klubO; set => klubO = value; }
        public Igrac IgracO { get => igracO; set => igracO = value; }
        public Igrac ZamjenaO { get => zamjenaO; set => zamjenaO = value; }

        public override PrikazVisitor Accept(PrikazVisitor prikazVisitor)
        {
            return null;
        }

        public override bool Equals(object obj)
        {
            return obj is Dogadaj dogadaj &&
                   broj == dogadaj.broj &&
                   min == dogadaj.min &&
                   vrsta == dogadaj.vrsta &&
                   klub == dogadaj.klub &&
                   igrac == dogadaj.igrac &&
                   zamjena == dogadaj.zamjena &&
                   EqualityComparer<Klub>.Default.Equals(klubO, dogadaj.klubO);
        }

        public override string ToString()
        {
            return $"{broj} {min} {vrsta} {klub} {igrac} {zamjena}";
        }


        public class DogadajBuilder
        {
            private int broj;
            private string min;
            private int vrsta;
            private string klub;
            private string igrac;
            private string zamjena;

            public DogadajBuilder(int broj, string min, int vrsta)
            {
                this.broj = broj;
                this.min = min;
                this.vrsta = vrsta;
                this.klub = null;
                this.igrac = null;
                this.zamjena = null;
            }

            public int Broj { get => broj;}
            public string Min { get => min;}
            public int Vrsta { get => vrsta;}
            public string Klub { get => klub;}
            public string Igrac { get => igrac;}
            public string Zamjena { get => zamjena;}

            public DogadajBuilder postaviKlub(string klub)
            {
                this.klub = klub;
                return this;
            }
            public DogadajBuilder postaviIgrac(string igrac)
            {
                this.igrac = igrac;
                return this;
            }
            public DogadajBuilder postaviZamjena(string zamjena)
            {
                this.zamjena = zamjena;
                return this;
            }
            public Dogadaj build()
            {
                return new Dogadaj(this);
            }
        }
    }
}
