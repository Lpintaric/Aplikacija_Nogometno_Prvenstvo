using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.UcitavanjePodataka
{
    class UcitavanjeCreatorSastavUtakmice : UcitavanjeCreator
    {
        private string zapis;
        private List<string> atributi;
        private SastavUtakmice sastavUtakmice;

        public UcitavanjeCreatorSastavUtakmice(string zapis)
        {
            this.zapis = zapis;
        }

        public string jeLiZapisIspravan()
        {
            String[] dijeloviZapisa = zapis.Split(';');
            atributi = new List<string>(dijeloviZapisa);

            if (atributi.Count != 5)
            {
                return "ERROR:" + zapis + " -> Nevaljan broj atributa!";
            }
            if (atributi.Find(x => x == "") != null)
            {
                return "ERROR:" + zapis + " -> Prazan atribut!";
            }

            return "OK";
        }

        public LigaComponent pretvoriZapisUObjekt()
        {
            sastavUtakmice = new SastavUtakmice(Int32.Parse(atributi[0]), atributi[1], atributi[2], atributi[3], atributi[4]);
            return sastavUtakmice;
        }
    }
}
