using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.UcitavanjePodataka
{
    public class UcitavanjeFacade
    {
        UcitavanjeCreator ucitavanjeCreator = null;

        public List<Klub> UcitajKlubove(string datotekaKlubovi)
        {
            string[] zapisi;
            zapisi = File.ReadAllLines(datotekaKlubovi, Encoding.UTF8);

            Klub klub;
            List<Klub> klubovi = new List<Klub>();

            for (int i = 1; i < zapisi.Length; i++)
            {
                ucitavanjeCreator = new UcitavanjeCreatorKlub(zapisi[i]);
                string[] porukaIspravnosti = ucitavanjeCreator.jeLiZapisIspravan().Split(':');
                if (porukaIspravnosti[0] == "ERROR")
                {
                    Console.WriteLine($"DatotekaKlubovi: Zapis br. {i} je neispravan. " + porukaIspravnosti[1]);
                    continue;
                }
                klub = (Klub)ucitavanjeCreator.pretvoriZapisUObjekt();
                klubovi.Add(klub);
            }

            return klubovi;
        }

        public List<Igrac> UcitajIgrace(string datotekaIgraci)
        {
            string[] zapisi;
            zapisi = File.ReadAllLines(datotekaIgraci, Encoding.UTF8);

            Igrac igrac;
            List<Igrac> igraci = new List<Igrac>();

            for (int i = 1; i < zapisi.Length; i++)
            {
                ucitavanjeCreator = new UcitavanjeCreatorIgrac(zapisi[i]);
                string[] porukaIspravnosti = ucitavanjeCreator.jeLiZapisIspravan().Split(':');
                if (porukaIspravnosti[0] == "ERROR")
                {
                    Console.WriteLine($"DatotekaIgraci: Zapis br. {i} je neispravan. " + porukaIspravnosti[1]);
                    continue;
                }
                igrac = (Igrac)ucitavanjeCreator.pretvoriZapisUObjekt();
                igraci.Add(igrac);
            }

            return igraci;
        }

        public List<Utakmica> UcitajUtakmice(string datotekaUtakmice)
        {
            string[] zapisi;
            zapisi = File.ReadAllLines(datotekaUtakmice, Encoding.UTF8);

            Utakmica utakmica;
            List<Utakmica> utakmice = new List<Utakmica>();

            for (int i = 1; i < zapisi.Length; i++)
            {
                ucitavanjeCreator = new UcitavanjeCreatorUtakmica(zapisi[i]);
                string[] porukaIspravnosti = ucitavanjeCreator.jeLiZapisIspravan().Split(':');
                if (porukaIspravnosti[0] == "ERROR")
                {
                    Console.WriteLine($"DatotekaUtakmice: Zapis br. {i} je neispravan. " + porukaIspravnosti[1]);
                    continue;
                }
                utakmica = (Utakmica)ucitavanjeCreator.pretvoriZapisUObjekt();
                utakmice.Add(utakmica);
            }

            return utakmice;
        }

        public List<SastavUtakmice> UcitajSastaveUtakmica(string datotekaSastaviUtakmica)
        {
            string[] zapisi;
            zapisi = File.ReadAllLines(datotekaSastaviUtakmica, Encoding.UTF8);

            SastavUtakmice sastavUtakmice;
            List<SastavUtakmice> sastaviUtakmica = new List<SastavUtakmice>();

            for (int i = 1; i < zapisi.Length; i++)
            {
                ucitavanjeCreator = new UcitavanjeCreatorSastavUtakmice(zapisi[i]);
                string[] porukaIspravnosti = ucitavanjeCreator.jeLiZapisIspravan().Split(':');
                if (porukaIspravnosti[0] == "ERROR")
                {
                    Console.WriteLine($"DatotekaSastaviUtakmice: Zapis br. {i} je neispravan. " + porukaIspravnosti[1]);
                    continue;
                }
                sastavUtakmice = (SastavUtakmice)ucitavanjeCreator.pretvoriZapisUObjekt();
                sastaviUtakmica.Add(sastavUtakmice);
            }

            return sastaviUtakmica;
        }

        public List<Dogadaj> UcitajDogadaje(string datotekaDogadaji)
        {
            string[] zapisi;
            zapisi = File.ReadAllLines(datotekaDogadaji, Encoding.UTF8);

            Dogadaj dogadaj;
            List<Dogadaj> dogadaji = new List<Dogadaj>();

            for (int i = 1; i < zapisi.Length; i++)
            {
                ucitavanjeCreator = new UcitavanjeCreatorDogadaj(zapisi[i]);
                string[] porukaIspravnosti = ucitavanjeCreator.jeLiZapisIspravan().Split(':');
                if (porukaIspravnosti[0] == "ERROR")
                {
                    Console.WriteLine($"DatotekaDogadaji: Zapis br. {i} je neispravan. " + porukaIspravnosti[1]);
                    continue;
                }
                dogadaj = (Dogadaj)ucitavanjeCreator.pretvoriZapisUObjekt();
                dogadaji.Add(dogadaj);
            }

            return dogadaji;
        }


    }
}
