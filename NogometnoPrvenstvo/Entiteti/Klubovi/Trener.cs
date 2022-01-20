using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.Entiteti
{
    public class Trener : Osoba
    {
        string imePrezime = "";

        public Trener(string imePrezime)
        {
            this.ImePrezime = imePrezime;
        }

        public string ImePrezime { get => imePrezime; set => imePrezime = value; }


        public override string ToString()
        {
            return $"{imePrezime}";
        }
    }
}
