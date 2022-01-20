using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.Entiteti
{
    public abstract class KluboviComponent : LigaComponent
    {
        public KluboviComponent() { }

        public virtual List<Igrac> DohvatiIgrace()
        {
            throw new NotImplementedException();
        }

        public virtual Trener DohvatiTrenera()
        {
            throw new NotImplementedException();
        }
        public virtual void DodajKomponentu(KluboviComponent komponenta) { }
    }
}

