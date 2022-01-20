using System;
using System.Collections.Generic;
using System.Text;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class StatistikaBodovi : Statistika
    {
        private string klub;
        private string trener;
        private int odigranaKola;
        private int brojPobjeda;
        private int brojNerijesenih;
        private int brojPoraza;
        private int brojPostignutihGolova;
        private int brojPrimljenihGolova;
        private int razlikaGolova;
        private int brojBodova;

        public StatistikaBodovi()
        {
            Klub = "";
            Trener = "";
            OdigranaKola = 0;
            BrojPobjeda = 0;
            BrojNerijesenih = 0;
            BrojPoraza = 0;
            BrojPostignutihGolova = 0;
            BrojPrimljenihGolova = 0;
            RazlikaGolova = 0;
            BrojBodova = 0;
        }

        public StatistikaBodovi(StatistikaBodovi statistikaBodovi)
        {
            this.klub = statistikaBodovi.Klub;
            this.trener = statistikaBodovi.Trener;
            this.odigranaKola = statistikaBodovi.OdigranaKola;
            this.brojPobjeda = statistikaBodovi.BrojPobjeda;
            this.brojNerijesenih = statistikaBodovi.BrojNerijesenih;
            this.brojPoraza = statistikaBodovi.BrojPoraza;
            this.brojPostignutihGolova = statistikaBodovi.BrojPostignutihGolova;
            this.brojPrimljenihGolova = statistikaBodovi.BrojPrimljenihGolova;
            this.razlikaGolova = this.brojPostignutihGolova - this.brojPrimljenihGolova;
            this.brojBodova = this.BrojPobjeda * 3 + this.brojNerijesenih * 1;
        }


        public void DodajBodove(StatistikaBodovi statistikaBodovi)
        {
            this.odigranaKola += statistikaBodovi.OdigranaKola;
            this.brojPobjeda += statistikaBodovi.BrojPobjeda;
            this.brojNerijesenih += statistikaBodovi.BrojNerijesenih;
            this.brojPoraza += statistikaBodovi.BrojPoraza;
            this.brojPostignutihGolova += statistikaBodovi.BrojPostignutihGolova;
            this.brojPrimljenihGolova += statistikaBodovi.BrojPrimljenihGolova;
            this.razlikaGolova = this.brojPostignutihGolova - this.brojPrimljenihGolova;
            this.brojBodova = this.BrojPobjeda * 3 + this.brojNerijesenih * 1;
        }

        public string Klub { get => klub; set => klub = value; }
        public int OdigranaKola { get => odigranaKola; set => odigranaKola = value; }
        public int BrojPobjeda { get => brojPobjeda; set => brojPobjeda = value; }
        public int BrojNerijesenih { get => brojNerijesenih; set => brojNerijesenih = value; }
        public int BrojPoraza { get => brojPoraza; set => brojPoraza = value; }
        public int BrojPostignutihGolova { get => brojPostignutihGolova; set => brojPostignutihGolova = value; }
        public int BrojPrimljenihGolova { get => brojPrimljenihGolova; set => brojPrimljenihGolova = value; }
        public int RazlikaGolova { get => razlikaGolova; set => razlikaGolova = value; }
        public int BrojBodova { get => brojBodova; set => brojBodova = value; }
        public string Trener { get => trener; set => trener = value; }
    }
}
