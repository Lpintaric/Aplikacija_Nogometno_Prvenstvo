using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System.Collections.Generic;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public abstract class PrikazVisitor
    {
        protected bool nastavi = true;

        public bool Nastavi { get => nastavi; }

        public abstract List<Statistika> Visit(Prvenstvo p);
        public abstract void Visit(Kolo k);
        public abstract void Visit(Utakmica u);
    }
}
