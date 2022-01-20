using lpintaric_zadaca_3.Entiteti;
using lpintaric_zadaca_3.Entiteti.Klubovi.IgracStanja;
using lpintaric_zadaca_3.Entiteti.Utakmice;
using lpintaric_zadaca_3.Podaci;
using lpintaric_zadaca_3.PrikazStatistike.ObradaDogadaja;
using lpintaric_zadaca_3.PrikazStatistike.PomocneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class PrikazVisitorSastavi : PrikazVisitor
    {
        private int kolo;
        private string prviKlub;
        private string drugiKlub; 

        List<IgracPostava> postavePocetakDomacin;
        List<IgracPostava> postavePocetakGost;
        List<IgracPostava> postaveKrajDomacin;
        List<IgracPostava> postaveKrajGost;

        public PrikazVisitorSastavi(int kolo, string prviKlub, string drugiKlub)
        {
            this.prviKlub = prviKlub;
            this.drugiKlub = drugiKlub;
            this.kolo = kolo;
            postavePocetakDomacin = new List<IgracPostava>();
            postavePocetakGost = new List<IgracPostava>();
            postaveKrajDomacin = new List<IgracPostava>();
            postaveKrajGost = new List<IgracPostava>();

        }

        public List<IgracPostava> PostavePocetakDomacin { get => postavePocetakDomacin; }
        public List<IgracPostava> PostavePocetakGost { get => postavePocetakGost; }
        public List<IgracPostava> PostaveKrajDomacin { get => postaveKrajDomacin; }
        public List<IgracPostava> PostaveKrajGost { get => postaveKrajGost; }

        public override List<Statistika> Visit(Prvenstvo p)
        {
            return null;
        }

        public override void Visit(Kolo k)
        {
            if (k.Broj == kolo)
                nastavi = false;
            else
                nastavi = true;
        }

        public override void Visit(Utakmica u)
        {
            if (u.Kolo != kolo)
                return;
            if ((u.Domacin != prviKlub || u.Gost != drugiKlub) && (u.Domacin != drugiKlub || u.Gost != prviKlub))
                return;

            List<Dogadaj> dogadajiUtakmice = u.DohvatiDogadaje();
            if (dogadajiUtakmice.Count <= 0)
            {
                Console.WriteLine("Ne postoje događaji za zadanu utakmicu !");
                return;
            }

            NogometnaLigaPodaci.DohvatiInstancu().PostaviPocetnaStanjaIgraca(u);

            postavePocetakDomacin = DohvatiPostaveKluba(u.DomacinO);
            postavePocetakGost = DohvatiPostaveKluba(u.GostO);

            foreach (Dogadaj dogadaj in dogadajiUtakmice)
            {
                DogadajHandler lanacProvjere = DogadajVerifikator.dohvatiInstancu().dohvatiLanacProvjere();
                lanacProvjere.PristupiObradi(dogadaj);
            }

            postaveKrajDomacin = DohvatiPostaveKluba(u.DomacinO);
            postaveKrajGost = DohvatiPostaveKluba(u.GostO);

        }


        private List<IgracPostava> DohvatiPostaveKluba(Klub klub)
        {
            List<IgracPostava> igracPostave = new List<IgracPostava>();

            foreach (Igrac igrac in klub.DohvatiIgrace())
            {
                if (igrac.State is IgraState || igrac.State is ZutiKartonState)
                {
                    IgracPostava igracPostava = new IgracPostava();
                    igracPostava.Klub = klub.Naziv;
                    igracPostava.Igrac = igrac.ImePrezime;
                    igracPostava.Pozicija = igrac.Pozicije.First();

                    igracPostave.Add(igracPostava);
                }
            }

            List<IgracPostava> igracPostaveSortirano = new List<IgracPostava>();

            foreach (IgracPostava ip in igracPostave)
            {
                if(ip.Pozicija == "G")
                {
                    igracPostaveSortirano.Add(ip);
                }
            }

            foreach (IgracPostava ip in igracPostave)
            {
                if (ip.Pozicija == "LB" || ip.Pozicija == "DB" || ip.Pozicija == "CB" || ip.Pozicija == "B")
                {
                    igracPostaveSortirano.Add(ip);
                }
            }

            foreach (IgracPostava ip in igracPostave)
            {
                if (ip.Pozicija == "LDV" || ip.Pozicija == "DDV" || ip.Pozicija == "CDV" || ip.Pozicija == "LV" 
                    || ip.Pozicija == "DV" || ip.Pozicija == "CV" || ip.Pozicija == "LOV" || ip.Pozicija == "DOV"
                    || ip.Pozicija == "COV" || ip.Pozicija == "V")
                {
                    igracPostaveSortirano.Add(ip);
                }
            }

            foreach (IgracPostava ip in igracPostave)
            {
                if (ip.Pozicija == "LN" || ip.Pozicija == "DN" || ip.Pozicija == "CN" || ip.Pozicija == "N" )
                {
                    igracPostaveSortirano.Add(ip);
                }
            }

            return igracPostaveSortirano;
        }
    }
}
