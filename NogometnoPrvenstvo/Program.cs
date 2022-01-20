using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using lpintaric_zadaca_3.Podaci;
using lpintaric_zadaca_3.PrikazStatistike;
using lpintaric_zadaca_3.PrikazStatistike.PomocneKlase;
using lpintaric_zadaca_3.RasporedUtakmica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lpintaric_zadaca_3
{
    public class Program
    {
        static string datotekaDogadaji = "";
        static string datotekaSastaviUtakmica = "";
        static string datotekaIgraci = "";
        static string datotekaUtakmice = "";
        static string datotekaKlubovi = "";
        static void Main(string[] args)
        {


            ValidirajArgumente(args);

            SpremiNaziveDatoteka(args);

            PostaviEncodingKonzole();

            ZapisiPodatkeUBazu(datotekaKlubovi, datotekaIgraci, datotekaUtakmice, datotekaSastaviUtakmica, datotekaDogadaji);

            ZapocniIzvrsavanjeKomandi();
        }

        private static void SpremiNaziveDatoteka(string[] args)
        {
            for (int i = 0; i < args.Length; i += 2)
            {
                if (args[i] == "-k")
                {
                    datotekaKlubovi = args[i + 1];
                }
                else if (args[i] == "-i")
                {
                    datotekaIgraci = args[i + 1];
                }
                else if (args[i] == "-u")
                {
                    datotekaUtakmice = args[i + 1];
                }
                else if (args[i] == "-s")
                {
                    datotekaSastaviUtakmica = args[i + 1];
                }
                else if (args[i] == "-d")
                {
                    datotekaDogadaji = args[i + 1];
                }
            }
        }

        private static void PostaviEncodingKonzole()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }

        private static void ValidirajArgumente(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine();
                Izlaz("Broj argumenata nesmije biti manji od 4");
            }

            if (args.ToList().Find(x => x == "-k") == null || args.ToList().Find(x => x == "-i") == null)
            {
                Izlaz("Datoteke klubova i igrača moraju biti uključene!");
            }

            if (args.ToList().Find(x => x == "-d") != null)
            {
                if (args.ToList().Find(x => x == "-s") == null)
                    Izlaz("Ako je u listi argumenata datoteka događaja tada mora biti i datoteka sastava");
                else if (args.ToList().Find(x => x == "-u") == null)
                    Izlaz("Ako je u listi argumenata datoteka događaja tada mora biti i datoteka utakmica");
            }

            if (args.ToList().Find(x => x == "-s") != null)
            {
                if (args.ToList().Find(x => x == "-u") == null)
                    Izlaz("Ako je u listi argumenata datoteka sastava tada mora biti i datoteka utakmica");
            }
        }

        private static void Izlaz(string porukaGreske)
        {
            Console.WriteLine("Neispravni aurgumenti : " + porukaGreske);
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void ZapocniIzvrsavanjeKomandi()
        {
            string komanda = "";

            int brojKola = NogometnaLigaPodaci.DohvatiInstancu().BrojKola;

            while (true)
            {
                Console.Write("Unesite akciju (X za izlaz): ");
                komanda = Console.ReadLine();
                if (komanda == "X") break;
                string[] dijelovi = komanda.Split(' ');
                try
                {
                    ObradiKomandu(dijelovi, brojKola);
                }
                catch (Exception)
                {

                    Console.WriteLine("Neispravna komanda");
                }
                
            }
        }

        private static void ObradiKomandu(String[] dijelovi, int brojKola)
        {
            List<Klub> sviKlubovi = NogometnaLigaPodaci.DohvatiInstancu().Klubovi;

            if (dijelovi[0] == "T" && (dijelovi.Length == 2 || dijelovi.Length == 1))
            {
                if (dijelovi.Length == 1)
                {
                    PrikaziStatistikuTimova(brojKola, sviKlubovi);
                }
                else if (dijelovi.Length == 2)
                {
                    PrikaziStatistikuTimova(int.Parse(dijelovi[1]), sviKlubovi);
                }
            }
            else if (dijelovi[0] == "S" && (dijelovi.Length == 2 || dijelovi.Length == 1))
            {
                if (dijelovi.Length == 1)
                {
                    PrikaziStrijelce(brojKola);
                }
                else
                {
                    PrikaziStrijelce(int.Parse(dijelovi[1]));
                }
            }
            else if (dijelovi[0] == "K" && (dijelovi.Length == 2 || dijelovi.Length == 1))
            {
                if (dijelovi.Length == 1)
                {
                    PrikaziKartone(brojKola);
                }
                else
                {
                    PrikaziKartone(int.Parse(dijelovi[1]));
                }
            }
            else if (dijelovi[0] == "R" && (dijelovi.Length == 3 || dijelovi.Length == 2))
            {
                if (dijelovi.Length == 2)
                {
                    PrikaziUtakmiceKluba(brojKola, dijelovi[1]);
                }
                else
                {
                    PrikaziUtakmiceKluba(int.Parse(dijelovi[2]), dijelovi[1]);
                }
            }
            else if (dijelovi[0] == "D" && dijelovi.Length == 5)
            {
                PrikaziDogadajeUtakmice(int.Parse(dijelovi[1]), dijelovi[2], dijelovi[3], int.Parse(dijelovi[4]));
            }
            else if (dijelovi[0] == "NU" && dijelovi.Length == 2)
            {
                string nazivDatoteke = dijelovi[1];
                DodajPodatkeUtakmica(nazivDatoteke);
            }
            else if (dijelovi[0] == "NS" && dijelovi.Length == 2)
            {
                string nazivDatoteke = dijelovi[1];
                DodajPodatkeSastava(nazivDatoteke);
            }
            else if (dijelovi[0] == "ND" && dijelovi.Length == 2)
            {
                string nazivDatoteke = dijelovi[1];
                DodajPodatkeDogadaja(nazivDatoteke);
            }
            else if (dijelovi[0] == "SU" && dijelovi.Length == 4)
            {
                PrikaziSastaveUtakmice(int.Parse(dijelovi[1]), dijelovi[2], dijelovi[3]);
            }
            else if (dijelovi[0] == "GR" && dijelovi.Length == 2)
            {
                GenerirajRaspored(int.Parse(dijelovi[1]));
            }
            else if (dijelovi[0] == "IR" && dijelovi.Length == 2)
            {
                PrikazRasporedaKluba(dijelovi[1]);
            }
            else if (dijelovi[0] == "IK" && dijelovi.Length == 2)
            {
                PrikazRasporedaKola(int.Parse(dijelovi[1]));
            }
            else if (dijelovi[0] == "IG" && dijelovi.Length == 1)
            {
                PrikazGeneriranihRasporeda();
            }
            else if (dijelovi[0] == "VR" && dijelovi.Length == 2)
            {
                PostavljanjeVazecegRasporeda(int.Parse(dijelovi[1]));
            }
            else
            {
                Console.WriteLine("Neispravna komanda");
            }
        }

        private static void PostavljanjeVazecegRasporeda(int redniBroj)
        {
            NogometnaLigaPodaci bazaPodataka = NogometnaLigaPodaci.DohvatiInstancu();
            Raspored raspored = bazaPodataka.GeneriraniRasporedi.Find(gr => gr.RedniBroj == redniBroj);
            if (raspored == null)
            {
                Console.WriteLine($"Raspored pod rednim brojem {redniBroj} ne postoji ! ");
                return;
            }
            bazaPodataka.AktualniRaspored = raspored;
            
            Console.WriteLine($"Raspored {redniBroj} je sada važeći ! ");
        }

        private static void PrikazGeneriranihRasporeda()
        {
            List<Raspored> rasporedi = NogometnaLigaPodaci.DohvatiInstancu().GeneriraniRasporedi;

            IspisiRazdjelnicu(102);
            Console.WriteLine($"|{$"GENERIRANI RASPOREDI",-100}|");
            IspisiRazdjelnicu(102);

            foreach (Raspored raspored in rasporedi)
            {
                Console.WriteLine($"|{raspored.RedniBroj,-50}|{raspored.DatumVrijeme,-50}|");
            }

            IspisiRazdjelnicu(102);

        }

        private static void PrikazRasporedaKluba(string oznakaKluba)
        {
            NogometnaLigaPodaci bazaPodataka = NogometnaLigaPodaci.DohvatiInstancu();
            Raspored raspored = bazaPodataka.AktualniRaspored;
            if (raspored == null)
            {
                Console.WriteLine("Važeći raspored nije postavljen !");
                return;
            }
            Klub klub = bazaPodataka.Klubovi.Find(k => k.Oznaka == oznakaKluba);
            if (klub == null)
            {
                Console.WriteLine($"Klub za oznaku {oznakaKluba} ne postoji");
                return;
            }            

            IspisiRazdjelnicu(102);
            Console.WriteLine($"|{$"Raspored za klub {klub.Naziv}",-100}|");
            IspisiRazdjelnicu(102);

            foreach (Kolo kolo in raspored.Kola)
            {
                Utakmica utakmica = kolo.DohvatiUtakmice().Find(ut => ut.DomacinO.Oznaka == oznakaKluba || ut.GostO.Oznaka == oznakaKluba);
                Console.WriteLine($"|{utakmica.DomacinO.Naziv,-50}|{utakmica.GostO.Naziv,-50}|");
            }

            IspisiRazdjelnicu(102);
        }

        private static void PrikazRasporedaKola(int kolo)
        {
            Raspored raspored = NogometnaLigaPodaci.DohvatiInstancu().AktualniRaspored;
            if(raspored.Kola.Count <= 0)
            {
                Console.WriteLine("Važeći raspored nije postavljen !");
                return;
            }
            if(kolo < 1 || kolo > raspored.Kola.Count)
            {
                Console.WriteLine("Broj kola nije unutar odgovarajućeg raspoena");
                return;
            }
            List<Utakmica> utakmiceKola = raspored.Kola.Find(k => k.Broj == kolo).DohvatiUtakmice();

            IspisiRazdjelnicu(102);
            Console.WriteLine($"|{$"Raspored kola {kolo}",-100}|");
            IspisiRazdjelnicu(102);

            foreach (Utakmica utakmica in utakmiceKola)
            {
                Console.WriteLine($"|{utakmica.DomacinO.Naziv,-50}|{utakmica.GostO.Naziv,-50}|");
            }

            IspisiRazdjelnicu(102);
        }

        private static void GenerirajRaspored(int brojAlgoritma)
        {
            if(brojAlgoritma != 1 && brojAlgoritma != 2 && brojAlgoritma != 3)
            {
                Console.WriteLine("Broj algoritma mora biti u rasponu od 1-3 !");
                return;
            }
            GeneratorRasporeda.DohvatiInstancu().GenerirajRaspored(brojAlgoritma);
            Console.WriteLine("Raspored je generiran!");
        }

        private static void PrikaziSastaveUtakmice(int kolo, string prviKlub, string drugiKlub)
        {
            PrikazVisitor visitor = new PrikazVisitorSastavi(kolo, prviKlub, drugiKlub);
            PrikazVisitorSastavi visitorSastavi = NogometnaLigaPodaci.DohvatiInstancu().Prvenstvo.Accept(visitor) as PrikazVisitorSastavi;

            List<IgracPostava> postaveDomacin = visitorSastavi.PostavePocetakDomacin;
            List<IgracPostava> postaveGost = visitorSastavi.PostavePocetakGost;
            IspisiSastaveUtakmice(visitorSastavi, postaveDomacin, postaveGost, "POČETNI SASTAVI");

            postaveDomacin = visitorSastavi.PostaveKrajDomacin;
            postaveGost = visitorSastavi.PostaveKrajGost;
            IspisiSastaveUtakmice(visitorSastavi, postaveDomacin, postaveGost, "ZAVRŠNI SASTAVI");

        }

        private static void IspisiSastaveUtakmice(PrikazVisitorSastavi visitorSastavi, List<IgracPostava> postaveDomacin, List<IgracPostava> postaveGost, string naslov)
        {
            IspisiRazdjelnicu(163);
            Console.WriteLine($"|{naslov,-161}|");
            IspisiRazdjelnicu(163);
            Console.WriteLine($"|{"Domacin",-80}|{"Gost",-80}|");
            IspisiRazdjelnicu(163);

            int brojRedaka = 0;
            if (postaveDomacin.Count >= postaveGost.Count)
            {
                brojRedaka = postaveDomacin.Count;
                IspisiSastave(postaveDomacin, postaveGost, brojRedaka);
            }
            else
            {
                brojRedaka = postaveGost.Count;
                IspisiSastave(postaveDomacin, postaveGost, brojRedaka);
            }
            IspisiRazdjelnicu(163);
        }

        private static void IspisiSastave(List<IgracPostava> postaveDomacin, List<IgracPostava> postaveGost, int brojRedaka)
        {
            for (int i = 0; i < brojRedaka; i++)
            {
                string redak = "";
                if (i + 1 > postaveGost.Count)
                {
                    redak = $"|{postaveDomacin[i].Klub,-20}{postaveDomacin[i].Igrac,-50}{postaveDomacin[i].Pozicija,-10}|" +
                        $"{"",-80}|";
                }
                else if (i + 1 > postaveDomacin.Count)
                {
                    redak = $"|{"",-80}|" +
                        $"{postaveGost[i].Klub,-20}{postaveGost[i].Igrac,-50}{postaveGost[i].Pozicija,-10}|";
                }
                else
                {
                    redak = $"|{postaveDomacin[i].Klub,-20}{postaveDomacin[i].Igrac,-50}{postaveDomacin[i].Pozicija,-10}|" +
                        $"{postaveGost[i].Klub,-20}{postaveGost[i].Igrac,-50}{postaveGost[i].Pozicija,-10}|";
                }
                Console.WriteLine(redak);
            }
        }

        private static void IspisiRazdjelnicu(int duzina)
        {
            string razdjelnica = "";
            for (int i = 0; i < duzina; i++)
            {
                razdjelnica += "-";
            }

            Console.WriteLine(razdjelnica);
        }

        private static void DodajPodatkeDogadaja(string nazivDatoteke)
        {
            NogometnaLigaPodaci.DohvatiInstancu().SpremiDogadaje(nazivDatoteke);
        }

        private static void DodajPodatkeSastava(string nazivDatoteke)
        {
            NogometnaLigaPodaci.DohvatiInstancu().SpremiSastaveUtakmica(nazivDatoteke);
        }

        private static void DodajPodatkeUtakmica(string nazivDatoteke)
        {
            NogometnaLigaPodaci.DohvatiInstancu().SpremiUtakmice(nazivDatoteke);
        }

        private static void ZapisiPodatkeUBazu(string datotekaKlubovi, string datotekaIgraci, string datotekaUtakmice, string datotekaSastaviUtakmica, string datotekaDogadaji)
        {
            NogometnaLigaPodaci podaci = NogometnaLigaPodaci.DohvatiInstancu();
            podaci.SpremiKlubove(datotekaKlubovi);
            podaci.SpremiIgrace(datotekaIgraci);

            if (datotekaUtakmice != "")
                podaci.SpremiUtakmice(datotekaUtakmice);
            if (datotekaSastaviUtakmica != "")
                podaci.SpremiSastaveUtakmica(datotekaSastaviUtakmica);
            if (datotekaDogadaji != "")
                podaci.SpremiDogadaje(datotekaDogadaji);
        }

        private static void PrikaziDogadajeUtakmice(int kolo, string prviKlub, string drugiKlub, int sekunde)
        {
            PrikazVisitor visitor = new PrikazVisitorDogadaj(kolo, prviKlub, drugiKlub);
            PrikazVisitorDogadaj visitorRezultati = NogometnaLigaPodaci.DohvatiInstancu().Prvenstvo.Accept(visitor) as PrikazVisitorDogadaj;

            List<StatistikaDogadaj> statistike = visitorRezultati.Statistike.Cast<StatistikaDogadaj>().ToList();

            if (statistike == null)
            {
                return;
            }

            DogadajiSubject subject = new DogadajiSubject();
            new DogadajObserverSemafor(subject);

            foreach (StatistikaDogadaj sd in statistike)
            {
                subject.PostaviNovoStanje(sd);
                Thread.Sleep(sekunde * 1000);
            }

        }
        private static void PrikaziUtakmiceKluba(int kolo, string oznakaKluba)
        {
            PrikazVisitor visitor = new PrikazVisitorRezultat(kolo, oznakaKluba);
            PrikazVisitorRezultat visitorRezultati = NogometnaLigaPodaci.DohvatiInstancu().Prvenstvo.Accept(visitor) as PrikazVisitorRezultat;

            List<StatistikaRezultat> statistike = visitorRezultati.Statistike.Cast<StatistikaRezultat>().ToList();

            Console.WriteLine($"--------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"Kolo",4}|{"Vrijeme",-20}|{"Domacin",-25}|{"Gost",-25}|{"REZ",-7}|");
            Console.WriteLine($"--------------------------------------------------------------------------------------");

            foreach (StatistikaRezultat s1 in statistike)
            {
                Console.WriteLine($"|{s1.Kolo,4}|{s1.DatumVrijeme,-20}|{s1.Domacin,-25}|{s1.Gost,-25}|{s1.Rezultat,-7}|");
            }

        }

        private static void PrikaziKartone(int kolo)
        {
            PrikazVisitor visitor = new PrikazVisitorKarton(kolo);
            PrikazVisitorKarton visitorKartoni = NogometnaLigaPodaci.DohvatiInstancu().Prvenstvo.Accept(visitor) as PrikazVisitorKarton;

            List<StatistikaKarton> statistike = visitorKartoni.Statistike.Cast<StatistikaKarton>().ToList();

            Console.WriteLine($"---------------------------------------------------------");
            Console.WriteLine($"|{"Klub",-25}|{"Z",5}|{"DZ",5}|{"C",5}|{"UK",5}|");
            Console.WriteLine($"---------------------------------------------------------");
            List<StatistikaKarton> sortirano = statistike.OrderByDescending(x => x.UkupanBrojKartona)
                .ThenByDescending(x => x.CrveniKarton)
                .ThenByDescending(x => x.DrugiZuti)
                .ToList();
            StatistikaKarton ukupnaStatistika = new StatistikaKarton();
            foreach (StatistikaKarton s1 in sortirano)
            {
                Console.WriteLine($"|{s1.Klub,-25}|{s1.Zuti,5}|{s1.DrugiZuti,5}|{s1.CrveniKarton,5}|{s1.UkupanBrojKartona,5}|");
                ukupnaStatistika.Zuti += s1.Zuti;
                ukupnaStatistika.DrugiZuti += s1.DrugiZuti;
                ukupnaStatistika.CrveniKarton += s1.CrveniKarton;
                ukupnaStatistika.UkupanBrojKartona += s1.UkupanBrojKartona;
            }
            Console.WriteLine($"----------------------------------------------------------");
            Console.WriteLine($"|{"",-25}|{ukupnaStatistika.Zuti,5}|{ukupnaStatistika.DrugiZuti,5}|{ukupnaStatistika.CrveniKarton,5}|{ukupnaStatistika.UkupanBrojKartona,5}|");
            Console.WriteLine($"----------------------------------------------------------");
        }

        private static void PrikaziStrijelce(int kolo)
        {
            PrikazVisitor visitor = new PrikazVisitorStrijelac(kolo);
            PrikazVisitorStrijelac visitorStrijelci = NogometnaLigaPodaci.DohvatiInstancu().Prvenstvo.Accept(visitor) as PrikazVisitorStrijelac;

            List<StatistikaStrijelac> statistike = visitorStrijelci.Statistike.Cast<StatistikaStrijelac>().ToList();

            Console.WriteLine($"----------------------------------------------------------");
            Console.WriteLine($"|{"Igrac",-25}|{"Klub",-25}|{"Golovi",5}|");
            Console.WriteLine($"----------------------------------------------------------");
            List<StatistikaStrijelac> sortirano = statistike.OrderByDescending(s => s.BrojGolova).ToList();
            StatistikaStrijelac ukupnaStatistika = new StatistikaStrijelac();
            foreach (StatistikaStrijelac s1 in sortirano)
            {
                Console.WriteLine($"|{s1.Igrac,-25}|{s1.Klub,-25}|{s1.BrojGolova,5}|");
                ukupnaStatistika.BrojGolova += s1.BrojGolova;
            }
            Console.WriteLine($"----------------------------------------------------------");
            Console.WriteLine($"|{"",-25}|{"",-25}|{ukupnaStatistika.BrojGolova,5}|");
            Console.WriteLine($"----------------------------------------------------------");
        }

        private static void PrikaziStatistikuTimova(int kolo, List<Klub> klubovi)
        {
            PrikazVisitor visitor = new PrikazVisitorBodovi(kolo, klubovi);
            PrikazVisitorBodovi visitorBodovi = NogometnaLigaPodaci.DohvatiInstancu().Prvenstvo.Accept(visitor) as PrikazVisitorBodovi;

            List<StatistikaBodovi> statistike = visitorBodovi.Statistike.Cast<StatistikaBodovi>().ToList();

            Console.WriteLine($"|{"Klub",-25}|{"Trener",-25}|{"OK",5}|{"P",5}|{"N",5}|{"I",5}|{"POG",5}|{"PRG",5}|{"R",5}|{"B",5}|");
            Console.WriteLine($"------------------------------------------------------------------------------------------------------");
            List<StatistikaBodovi> sortirano = statistike.OrderByDescending(x => x.BrojBodova)
                .ThenByDescending(x => x.RazlikaGolova)
                .ThenByDescending(x => x.BrojPostignutihGolova)
                .ThenByDescending(x => x.BrojPobjeda)
                .ToList();
            StatistikaBodovi ukupnaStatistika = new StatistikaBodovi();
            foreach (StatistikaBodovi s in sortirano)
            {
                Console.WriteLine($"|{s.Klub,-25}|{s.Trener,-25}|{s.OdigranaKola,5}|{s.BrojPobjeda,5}|{s.BrojNerijesenih,5}" +
                    $"|{s.BrojPoraza,5}|{s.BrojPostignutihGolova,5}|{s.BrojPrimljenihGolova,5}|{s.RazlikaGolova,5}|{s.BrojBodova,5}|");
                ukupnaStatistika.BrojPobjeda += s.BrojPobjeda;
                ukupnaStatistika.BrojNerijesenih += s.BrojNerijesenih;
                ukupnaStatistika.BrojPoraza += s.BrojPoraza;
                ukupnaStatistika.BrojPostignutihGolova += s.BrojPostignutihGolova;
                ukupnaStatistika.BrojPrimljenihGolova += s.BrojPrimljenihGolova;
                ukupnaStatistika.BrojBodova += s.BrojBodova;
            }
            Console.WriteLine($"------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"",-25}|{"",-25}|{"",5}|{ukupnaStatistika.BrojPobjeda,5}|{ukupnaStatistika.BrojNerijesenih,5}" +
                    $"|{ukupnaStatistika.BrojPoraza,5}|{ukupnaStatistika.BrojPostignutihGolova,5}|{ukupnaStatistika.BrojPrimljenihGolova,5}" +
                    $"|{"",5}|{ukupnaStatistika.BrojBodova,5}|");
            Console.WriteLine($"------------------------------------------------------------------------------------------------------");

        }

    }
}
