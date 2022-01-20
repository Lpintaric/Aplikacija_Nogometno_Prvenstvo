using lpintaric_zadaca_3.PrikazStatistike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.Entiteti.Utakmice
{
    public abstract class PrvenstvoComponent : LigaComponent
    {
        public abstract PrikazVisitor Accept(PrikazVisitor prikazVisitor);
    }
}
