using lpintaric_zadaca_3.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.UcitavanjePodataka
{
    class UcitavanjeCreatorKlub : UcitavanjeCreator
    {
        private string zapis;
        private List<string> atributi;
        private Klub klub;

        public UcitavanjeCreatorKlub(string zapis)
        {
            this.zapis = zapis;
        }

        public string jeLiZapisIspravan()
        {
            string[] dijeloviZapisa = zapis.Split(';');
            atributi = new List<string>(dijeloviZapisa);

            if (atributi.Count != 3)
            {
                return "ERROR:" + zapis + " -> Nevaljan broj atributa!" ;
            }
            else if (atributi.Find(x => x == "") != null)
            {
                return "ERROR:" + zapis + " -> Prazan atribut!";
            }

            return "OK";
        }

        public LigaComponent pretvoriZapisUObjekt()
        {
            klub = new Klub(atributi[0], atributi[1], atributi[2]);
            return klub;
        }
    }
}
