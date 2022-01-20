using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using lpintaric_zadaca_3.PrikazStatistike.ObradaDogadaja;
using lpintaric_zadaca_3.UcitavanjePodataka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lpintaric_zadaca_3.Podaci
{
    public class NogometnaLigaPodaci
    {
        private static NogometnaLigaPodaci instanca;

        private UcitavanjeFacade ucitavanjeFacade;

        private List<Klub> klubovi;

        private Prvenstvo prvenstvo;

        private List<Raspored> generiraniRasporedi;

        private Raspored aktualniRaspored;

        private int brojKola;

        

        private NogometnaLigaPodaci()
        {
            ucitavanjeFacade = new UcitavanjeFacade();
            prvenstvo = new Prvenstvo();
            generiraniRasporedi = new List<Raspored>();
            aktualniRaspored = new Raspored();
        }

        public static NogometnaLigaPodaci DohvatiInstancu()
        {
            if (instanca == null)
            {
                instanca = new NogometnaLigaPodaci();
            }
            return instanca;
        }

        public void SpremiKlubove(string datotekaKlubovi)
        {
            this.klubovi = ucitavanjeFacade.UcitajKlubove(datotekaKlubovi);
            int brojKlubova = klubovi.Count;
            if (brojKlubova < 10)
                BrojKola = brojKlubova * 4;
            else
                BrojKola = brojKlubova * 2;
            for (int i = 1; i <= BrojKola; i++)
            {
                Kolo k = new Kolo(i);
                Prvenstvo.Kola.Add(k);
            }
        }
        public void SpremiIgrace(string datotekaIgraci)
        {
            List<Igrac> igraci = null;   
            igraci = ucitavanjeFacade.UcitajIgrace(datotekaIgraci);
            foreach (Igrac i in igraci)
            {
                Klub klub = klubovi.Find(k => k.Oznaka == i.Klub);
                if (klub != null)
                {
                    i.KlubO = klub;
                    klub.DodajKomponentu(i);
                }
                    
            }
        }
        public void SpremiUtakmice(string datotekaUtakmice)
        {
            List<Utakmica> utakmice;
            utakmice = ucitavanjeFacade.UcitajUtakmice(datotekaUtakmice);
            
            foreach (Utakmica utakmica in utakmice)
            {
                utakmica.DomacinO = klubovi.Find(k => k.Oznaka == utakmica.Domacin);
                utakmica.GostO = klubovi.Find(k => k.Oznaka == utakmica.Gost);
                if (utakmica.DomacinO == null || utakmica.GostO == null)
                    continue;
                Kolo kolo = Prvenstvo.Kola.Find(k => k.Broj == utakmica.Kolo);
                if (kolo != null)
                {
                    kolo.DodajKomponentu(utakmica);
                }
            }
        }
        public void SpremiSastaveUtakmica(string datotekaSastaviUtakmica)
        {
            List<SastavUtakmice> sastaviUtakmica = ucitavanjeFacade.UcitajSastaveUtakmica(datotekaSastaviUtakmica);

            foreach (Kolo kolo in Prvenstvo.Kola)
            {
                List<Utakmica> utakmiceKola = kolo.DohvatiUtakmice();
                foreach (Utakmica u in utakmiceKola)
                {
                    List<SastavUtakmice> odabraniSastavi = sastaviUtakmica.FindAll(su => su.Broj == u.Broj);
                    foreach (SastavUtakmice sastav in odabraniSastavi)
                    {
                        Klub klub = Klubovi.Find(k => k.Oznaka == sastav.Klub);
                        if (klub == null)
                            continue;
                        Igrac igrac = klub.DohvatiIgrace().Find(i => i.ImePrezime == sastav.Igrac);
                        if (igrac == null)
                            continue;
                        sastav.KlubO = klub;
                        sastav.IgracO = igrac;
                        u.DodajKomponentu(sastav);
                    }
                }
            }
            
        }

        public void PostaviPocetnaStanjaIgraca(Utakmica u)
        {
            List<SastavUtakmice> sastavi = u.DohvatiSastave();
            PostaviStanjaIgracaKluba(u.DomacinO, sastavi);
            PostaviStanjaIgracaKluba(u.GostO, sastavi);

        }

        private void PostaviStanjaIgracaKluba(Klub klub, List<SastavUtakmice> sastavi)
        {
            foreach (Igrac igrac in klub.DohvatiIgrace())
            {
                SastavUtakmice su = sastavi.Find(s => s.IgracO == igrac);
                if (su == null)
                {
                    igrac.PostaviPocetnoStanje("N");
                }
                else
                {
                    igrac.PostaviPocetnoStanje(su.Vrsta);
                }


            }
        }

        public void SpremiDogadaje(string datotekaDogadaji)
        {

            List<Dogadaj> dogadaji = ucitavanjeFacade.UcitajDogadaje(datotekaDogadaji);

            foreach (Kolo kolo in Prvenstvo.Kola)
            {
                List<Utakmica> utakmiceKola = kolo.DohvatiUtakmice();
                foreach (Utakmica u in utakmiceKola)
                {
                    PostaviPocetnaStanjaIgraca(u);
                    List<Dogadaj> odabraniDogadaji = dogadaji.FindAll(d => d.Broj == u.Broj);
                    foreach (Dogadaj dogadaj in odabraniDogadaji)
                    {
                        Klub klub = klubovi.Find(k => k.Oznaka == dogadaj.Klub);
                        if (klub == null)
                            continue;
                        Igrac igrac = klub.DohvatiIgrace().Find(i => i.ImePrezime == dogadaj.Igrac);
                        if (igrac == null)
                            continue;
                        Igrac zamjena = klub.DohvatiIgrace().Find(i => i.ImePrezime == dogadaj.Zamjena);
                        if (dogadaj.Vrsta == 20 && zamjena == null)
                            continue;
                        dogadaj.KlubO = klubovi.Find(k => k.Oznaka == dogadaj.Klub);
                        if (u.PostojiDogađaj(dogadaj))
                            continue;
                        
                        dogadaj.KlubO = klub;
                        dogadaj.IgracO = igrac;
                        dogadaj.ZamjenaO = zamjena;

                        if (DogadajVerifikator.dohvatiInstancu().dohvatiLanacProvjere().PristupiObradi(dogadaj) == false)
                            continue;
                        u.DodajKomponentu(dogadaj);
                    }
                }
            }
        }

        public List<Klub> Klubovi { get => klubovi; }
        public int BrojKola { get => brojKola; set => brojKola = value; }
        public Prvenstvo Prvenstvo { get => prvenstvo; set => prvenstvo = value; }
        public List<Raspored> GeneriraniRasporedi { get => generiraniRasporedi; set => generiraniRasporedi = value; }
        public Raspored AktualniRaspored { get => aktualniRaspored; set => aktualniRaspored = value; }
    }
}
