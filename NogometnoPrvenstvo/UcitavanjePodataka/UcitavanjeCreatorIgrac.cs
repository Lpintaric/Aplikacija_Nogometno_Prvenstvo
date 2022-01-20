using lpintaric_zadaca_3.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.UcitavanjePodataka
{
    public class UcitavanjeCreatorIgrac : UcitavanjeCreator
    {
        private string zapis;
        private List<string> atributi;
        private string[] pozicije;
        private Igrac igrac;

        public UcitavanjeCreatorIgrac(string zapis)
        {
            this.zapis = zapis;
        }

        public string jeLiZapisIspravan()
        {
            String[] dijeloviZapisa = zapis.Split(';');
            atributi = new List<string>(dijeloviZapisa);
            pozicije = dijeloviZapisa[2].Split(',');

            if (atributi.Count != 4)
                return "ERROR:" + zapis + " -> Nevaljan broj atributa!";
                
            if (atributi.Find(x => x == "") != null)
                return "ERROR:" + zapis + " -> Prazan atribut!";

            return "OK";
        }

        public LigaComponent pretvoriZapisUObjekt()
        {
            List<String> listaPozicija = new List<string>(pozicije);
            igrac = new Igrac(atributi[0], atributi[1], listaPozicija, atributi[3]);
            return igrac;
        }

    }
}
