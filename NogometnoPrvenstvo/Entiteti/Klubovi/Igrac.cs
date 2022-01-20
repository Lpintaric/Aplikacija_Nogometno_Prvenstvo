using lpintaric_zadaca_3.Entiteti.Klubovi.IgracStanja;
using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.Entiteti
{
    public class Igrac : Osoba
    {
        private string klub;
        private string imePrezime;
        private List<string> pozicije;
        private string roden;
        private Klub klubO;

        private State state;

        private static IgraState igraState = new IgraState();
        private static ZutiKartonState zutiKartonState = new ZutiKartonState();
        private static IzvanIgreState izvanIgreState = new IzvanIgreState();
        private static ZamjenaState zamjenaState = new ZamjenaState();
        public Igrac(string klub, string imePrezime, List<string> pozicije, string roden)
        {
            Klub = klub;
            ImePrezime = imePrezime;
            Pozicije = pozicije;
            Roden = roden;
            Klub = klub;
            ImePrezime = imePrezime;
            Pozicije = pozicije;
            Roden = roden;
            KlubO = null;
            state = null;
        }

        public string Klub { get => klub; set => klub = value; }
        public string ImePrezime { get => imePrezime; set => imePrezime = value; }
        public List<string> Pozicije { get => pozicije; set => pozicije = value; }
        public string Roden { get => roden; set => roden = value; }
        public Klub KlubO { get => klubO; set => klubO = value; }
        public State State { get => state; set => state = value; }
        public static ZutiKartonState ZutiKartonState { get => zutiKartonState;}
        public static IzvanIgreState IzvanIgreState { get => izvanIgreState; }
        public static ZamjenaState ZamjenaState { get => zamjenaState; }
        public static IgraState IgraState { get => igraState; set => igraState = value; }

        public override string ToString()
        {
            return $"{klub} {imePrezime} {pozicije[0]} {roden}";
        }
         
        public void PostaviPocetnoStanje(string vrsta)
        {
            if (vrsta == "S")
                state = igraState;
            else if (vrsta == "P")
                state = zamjenaState;
            else
                state = izvanIgreState;
        }
    }
}
