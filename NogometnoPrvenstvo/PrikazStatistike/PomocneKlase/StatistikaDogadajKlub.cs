using System.Collections.Generic;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class StatistikaDogadajKlub
    {
        private string nazivKluba;
        private int brojGolova;
        private List<string> golovi;
        private string ostalo;

        public StatistikaDogadajKlub()
        {
            this.NazivKluba = "";
            this.BrojGolova = 0;
            this.Golovi = new List<string>();
            this.Ostalo = "";
        }

        public StatistikaDogadajKlub(StatistikaDogadajKlub dogadajKlub)
        {
            this.nazivKluba = dogadajKlub.nazivKluba;
            this.brojGolova = dogadajKlub.brojGolova;
            this.golovi = new List<string>(dogadajKlub.golovi);
            this.ostalo = dogadajKlub.ostalo;
        }

        public string NazivKluba { get => nazivKluba; set => nazivKluba = value; }
        public int BrojGolova { get => brojGolova; set => brojGolova = value; }
        public List<string> Golovi { get => golovi; set => golovi = value; }
        public string Ostalo { get => ostalo; set => ostalo = value; }
    }
}