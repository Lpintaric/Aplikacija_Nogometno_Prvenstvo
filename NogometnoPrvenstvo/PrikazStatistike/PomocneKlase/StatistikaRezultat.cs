using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class StatistikaRezultat : Statistika
    {
        int kolo;
        string datumVrijeme;
        string domaćin;
        string gost;
        string rezultat;

        public int Kolo { get => kolo; set => kolo = value; }
        public string DatumVrijeme { get => datumVrijeme; set => datumVrijeme = value; }
        public string Domacin { get => domaćin; set => domaćin = value; }
        public string Gost { get => gost; set => gost = value; }
        public string Rezultat { get => rezultat; set => rezultat = value; }
    }
}
