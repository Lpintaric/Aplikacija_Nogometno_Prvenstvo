using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.Entiteti.Klubovi.IgracStanja
{
    public interface State
    {
        bool ObradiStanje(Igrac igrac, Dogadaj dogadaj);
    }
}
