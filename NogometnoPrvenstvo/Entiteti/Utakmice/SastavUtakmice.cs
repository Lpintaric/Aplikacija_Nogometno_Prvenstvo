using lpintaric_zadaca_3.PrikazStatistike;
using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.Entiteti.Utakmice
{
    public class SastavUtakmice : PrvenstvoComponent
    {
        private int broj;
        private string klub;
        private string vrsta;
        private string igrac;
        private string pozicija;
        private Igrac igracO;
        private Klub klubO;

        public SastavUtakmice(int broj, string klub, string vrsta, string igrac, string pozicija)
        {
            this.Broj = broj;
            this.Klub = klub;
            this.Vrsta = vrsta;
            this.Igrac = igrac;
            this.Pozicija = pozicija;
            this.igracO = null;
            this.klubO = null;
        }

        public int Broj { get => broj; set => broj = value; }
        public string Klub { get => klub; set => klub = value; }
        public string Vrsta { get => vrsta; set => vrsta = value; }
        public string Igrac { get => igrac; set => igrac = value; }
        public string Pozicija { get => pozicija; set => pozicija = value; }
        public Igrac IgracO { get => igracO; set => igracO = value; }
        public Klub KlubO { get => klubO; set => klubO = value; }

        public override PrikazVisitor Accept(PrikazVisitor prikazVisitor)
        {
            return null;
        }

        public override string ToString()
        {
            return $"{broj} {klub} {vrsta} {igrac} {pozicija}";
        }
    }


}
