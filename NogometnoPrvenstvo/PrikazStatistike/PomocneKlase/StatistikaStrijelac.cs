using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class StatistikaStrijelac :Statistika
    {
        string igrac;
        int brojGolova;
        string klub;

        public StatistikaStrijelac()
        {
            this.igrac = "";
            this.brojGolova = 0;
            this.klub = "";
        }

        public StatistikaStrijelac(StatistikaStrijelac statistika)
        {
            this.igrac = statistika.igrac;
            this.brojGolova = statistika.brojGolova;
            this.klub = statistika.Klub;
        }

        public StatistikaStrijelac(string igrac, int brojGolova, string klub)
        {
            this.igrac = igrac;
            this.brojGolova = brojGolova;
            this.klub = klub;
        }

        public void DodajGolove(StatistikaStrijelac statistika)
        {
            this.brojGolova += statistika.brojGolova;
        }

        public string Igrac { get => igrac; set => igrac = value; }
        public int BrojGolova { get => brojGolova; set => brojGolova = value; }
        public string Klub { get => klub; set => klub = value; }
    }
}
