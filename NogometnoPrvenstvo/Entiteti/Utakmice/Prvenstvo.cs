using lpintaric_zadaca_3.Entiteti.Utakmice;
using lpintaric_zadaca_3.PrikazStatistike;
using System.Collections.Generic;

namespace lpintaric_zadaca_3.Entiteti
{
    public class Prvenstvo : PrvenstvoComponent
    {
        private List<Kolo> kola;

        public Prvenstvo()
        {
            this.kola = new List<Kolo>();
        }

        public List<Kolo> Kola { get => kola; set => kola = value; }

        public override PrikazVisitor Accept(PrikazVisitor prikazVisitor)
        {
            foreach (Kolo ko in kola)
            {
                if (ko.Accept(prikazVisitor).Nastavi == false)
                    break;
            }
            prikazVisitor.Visit(this);

            return prikazVisitor;
        }
    }
}
