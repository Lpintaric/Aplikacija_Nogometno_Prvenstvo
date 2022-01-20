using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.Text;
using static lpintaric_zadaca_3.Entiteti.Utakmice.Dogadaj;

namespace lpintaric_zadaca_3.UcitavanjePodataka
{
    class UcitavanjeCreatorDogadaj : UcitavanjeCreator
    {
        private string zapis;
        private List<string> atributi;
        private Dogadaj dogadaj;

        public UcitavanjeCreatorDogadaj(string zapis)
        {
            this.zapis = zapis;
        }

        public string jeLiZapisIspravan()
        {
            String[] dijeloviZapisa = zapis.Split(';');
            atributi = new List<string>(dijeloviZapisa);

            if (atributi.Count != 6)
                return "ERROR:" + zapis + " -> Nevaljan broj atributa!";

            if (atributi[0] == "" || atributi[1] == "" || atributi[2] == "")
                return "ERROR:" + zapis + " -> Atributi 1, 2 , 3 nesmiju biti prazni!";

            if (atributi[2] == "0" || atributi[2] == "99")
            {
                if (atributi[3] != "" || atributi[4] != "" || atributi[5] != "")
                    return "ERROR:" + zapis + " -> Atributi 4, 5 i 6 moraju biti prazni";
            }

            if (atributi[2] == "1"
                || atributi[2] == "2"
                || atributi[2] == "3"
                || atributi[2] == "10"
                || atributi[2] == "11")
            {
                if (atributi[3] == "" || atributi[4] == "" || atributi[5] != "")
                    return "ERROR:" + zapis + " -> Atributi 4 i 5 nesmiju biti prazni, dok atribut 6 mora biti prazan!";
            }

            if (atributi[2] == "20")
            {
                if (atributi[3] == "" || atributi[4] == "" || atributi[5] == "")
                {
                    return "ERROR:" + zapis + " -> Atributi 4, 5 i 6 nesmiju biti prazni";
                }
            }
            return "OK";
        }


        public LigaComponent pretvoriZapisUObjekt()
        {
            if (atributi[2] == "0" || atributi[2] == "99")
            {
                dogadaj = new DogadajBuilder(int.Parse(atributi[0]), atributi[1], int.Parse(atributi[2])).build();
            }
            else if (atributi[2] == "1"
               || atributi[2] == "2"
               || atributi[2] == "3"
               || atributi[2] == "10"
               || atributi[2] == "11")
            {
                dogadaj = new DogadajBuilder(int.Parse(atributi[0]), atributi[1], int.Parse(atributi[2]))
                    .postaviKlub(atributi[3])
                    .postaviIgrac(atributi[4])
                    .build();

            }
            else if (atributi[2] == "20")
            {
                dogadaj = new DogadajBuilder(int.Parse(atributi[0]), atributi[1], int.Parse(atributi[2]))
                    .postaviKlub(atributi[3])
                    .postaviIgrac(atributi[4])
                    .postaviZamjena(atributi[5])
                    .build();
            }
            return dogadaj;
        }
    }
}
