using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.Entiteti.Klubovi.IgracStanja
{
    public class ZamjenaState : State
    {
        public bool ObradiStanje(Igrac igrac, Dogadaj dogadaj)
        {
            int vrsta = dogadaj.Vrsta;
            if (vrsta == 1 || vrsta == 2 || vrsta == 3 || vrsta == 10 || vrsta == 11 || vrsta == 20)
            {
                Console.WriteLine($"Događaj '{dogadaj}' nije valjan jer je igrač u pričuvi ! ");
                return false;
            }

            return false;
        }
    }
}
