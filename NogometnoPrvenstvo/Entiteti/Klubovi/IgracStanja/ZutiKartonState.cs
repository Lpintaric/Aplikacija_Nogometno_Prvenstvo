using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.Entiteti.Klubovi.IgracStanja
{
    public class ZutiKartonState : State
    {
        public bool ObradiStanje(Igrac igrac, Dogadaj dogadaj)
        {
            int vrsta = dogadaj.Vrsta;
            if (vrsta == 1 || vrsta == 2 || vrsta == 3)
            {
                return true;
            }
            else if (vrsta == 10)
            {
                igrac.State = Igrac.IzvanIgreState;
                return true;
            }
            else if (vrsta == 11)
            {
                igrac.State = Igrac.IzvanIgreState;
                return true;
            }
            else if (vrsta == 20)
            {
                igrac.State = Igrac.IzvanIgreState;
                dogadaj.ZamjenaO.State = Igrac.IgraState;
                return true;
            }
            return false;
        }
    }
}
