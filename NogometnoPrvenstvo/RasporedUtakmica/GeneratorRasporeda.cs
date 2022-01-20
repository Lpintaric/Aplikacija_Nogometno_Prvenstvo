using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using lpintaric_zadaca_3.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.RasporedUtakmica
{
    public class GeneratorRasporeda
    {
        private static GeneratorRasporeda instanca;

        private NogometnaLigaPodaci bazaPodataka;
        private List<Klub> sviKlubovi;
        private int brojKlubova;
        private List<Klub> prvaSkupina;
        private List<Klub> drugaSkupina;
        private int brojKola;
        int brojUtakmice;
        public GeneratorRasporeda()
        {
            this.bazaPodataka = NogometnaLigaPodaci.DohvatiInstancu();
        }

        public static GeneratorRasporeda DohvatiInstancu()
        {
            if (instanca == null)
            {
                instanca = new GeneratorRasporeda();
            }
            return instanca;
        }

        public void GenerirajRaspored(int brojAlgoritma)
        {
            PripremiPodatke();
            PostaviSkupine(brojAlgoritma);
            GenerirajKola();
        }

        private void GenerirajUtakmice(Kolo kolo)
        {
            bool krugParan = false;

            int modulo = brojKola % prvaSkupina.Count;

            if (modulo == 0)
            {
                if (krugParan)
                {
                    krugParan = false;
                }
                else
                {
                    krugParan = true;
                }
            }
            
            for (int i = 0; i < drugaSkupina.Count; i++)
            {
                Utakmica novaUtakmica;
                if (kolo.Broj % 2 == 1)
                {
                    if(krugParan)
                        novaUtakmica = new Utakmica(brojUtakmice, kolo.Broj, prvaSkupina[i], drugaSkupina[i]);
                    else
                        novaUtakmica = new Utakmica(brojUtakmice, kolo.Broj, drugaSkupina[i], prvaSkupina[i]);
                }
                else
                {
                    if (krugParan)
                        novaUtakmica = new Utakmica(brojUtakmice, kolo.Broj, drugaSkupina[i], prvaSkupina[i]);
                    else
                        novaUtakmica = new Utakmica(brojUtakmice, kolo.Broj, prvaSkupina[i], drugaSkupina[i]);

                }
                kolo.DodajKomponentu(novaUtakmica);
                brojUtakmice++;
            }

            Klub klubPremjesti = prvaSkupina.Last();
            prvaSkupina.Remove(klubPremjesti);
            prvaSkupina.Insert(0, klubPremjesti);
        }

        private void PripremiPodatke()
        {
            this.sviKlubovi = bazaPodataka.Klubovi;
            this.brojKlubova = sviKlubovi.Count;
            this.prvaSkupina = null;
            this.drugaSkupina = null;
            this.brojKola = 0;
            this.brojUtakmice = 1;
        }

        private Raspored GenerirajKola()
        {
            brojKola = ((brojKlubova + 1) / 2) * 2;

            Raspored raspored = new Raspored();
            bazaPodataka.GeneriraniRasporedi.Add(raspored);

            for (int i = 1; i <= brojKola; i++)
            {
                Kolo kolo = new Kolo(i);
                raspored.Kola.Add(kolo);
                GenerirajUtakmice(kolo);
            }

            return raspored;
        }

        private void PostaviSkupine(int brojAlgoritma)
        {
            if(brojAlgoritma == 2)
            {
                sviKlubovi = sviKlubovi.OrderBy(x => x.Naziv).ToList();
            }
            if (brojAlgoritma == 3)
            {
                sviKlubovi = sviKlubovi.OrderBy(x => x.Naziv.Length)
                    .ThenByDescending(x => PrebrojiSamoglasnike(x.DohvatiTrenera().ImePrezime))
                    .ToList();
            }
            int granica = (brojKlubova + 1) / 2;

            prvaSkupina = sviKlubovi.Take(granica).ToList();
            drugaSkupina = sviKlubovi.Skip(granica).ToList();
        }

        private int PrebrojiSamoglasnike(string naziv)
        {
            char[] samoglasnici = new[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

            int broj = 0;
            foreach (char slovo in naziv)
            {
                if (samoglasnici.Contains(slovo))
                {
                    broj++;
                }
            }
            return broj;
        }
    }
}
