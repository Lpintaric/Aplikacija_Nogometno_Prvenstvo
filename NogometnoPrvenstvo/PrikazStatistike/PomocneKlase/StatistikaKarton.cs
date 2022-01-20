using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class StatistikaKarton : Statistika
    {
        string klub;
        int zuti;
        int drugiZuti;
        int crveniKarton;
        int ukupanBrojKartona;

        public StatistikaKarton()
        {
            this.klub = "";
            this.zuti = 0;
            this.drugiZuti = 0;
            this.crveniKarton = 0;
            this.ukupanBrojKartona = 0;
        }

        public StatistikaKarton(StatistikaKarton statistika)
        {
            this.klub = statistika.klub;
            this.zuti = statistika.zuti;
            this.drugiZuti = statistika.drugiZuti;
            this.crveniKarton = statistika.crveniKarton;
            this.ukupanBrojKartona = this.zuti + this.crveniKarton;
        }

        public void DodajKartone(StatistikaKarton statistika)
        {
            this.zuti += statistika.zuti;
            this.drugiZuti += statistika.drugiZuti;
            this.crveniKarton += statistika.crveniKarton;
            this.ukupanBrojKartona = this.zuti + this.crveniKarton;
        }

        public string Klub { get => klub; set => klub = value; }
        public int Zuti { get => zuti; set => zuti = value; }
        public int DrugiZuti { get => drugiZuti; set => drugiZuti = value; }
        public int CrveniKarton { get => crveniKarton; set => crveniKarton = value; }
        public int UkupanBrojKartona { get => ukupanBrojKartona; set => ukupanBrojKartona = value; }
    }
}
