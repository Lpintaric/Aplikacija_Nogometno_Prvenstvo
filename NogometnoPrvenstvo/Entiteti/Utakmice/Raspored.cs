using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.Entiteti.Utakmice
{
    public class Raspored
    {
        int redniBroj;
        string datumVrijeme;
        private List<Kolo> kola;

        private static int brojac = 0;

        public Raspored()
        {
            this.redniBroj = brojac;
            brojac++;
            this.datumVrijeme = DateTime.UtcNow.ToString("dd/MM/yyyy hh:mm:ss");
            this.kola = new List<Kolo>();
        }

        public List<Kolo> Kola { get => kola; set => kola = value; }
        public int RedniBroj { get => redniBroj; }
        public string DatumVrijeme { get => datumVrijeme; }
    }
}
