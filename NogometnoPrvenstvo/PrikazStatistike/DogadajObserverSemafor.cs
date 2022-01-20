using System;


namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class DogadajObserverSemafor : DogadajObserver
    {
        
        public DogadajObserverSemafor(DogadajiSubject subject)
        {
            dogadajiSubject = subject;
            dogadajiSubject.DodajObservera(this);
        }

        public override void Azuriraj()
        {
            StatistikaDogadaj sd = dogadajiSubject.DohvatiTrenutnoStanje();

            Console.WriteLine(IspisiRazmaknicu(103));
            Console.WriteLine($"|{PoravnanjeUCentar(sd.Vrijeme, 101)}|");
            Console.WriteLine(IspisiRazmaknicu(103));
            Console.WriteLine($"|{PoravnanjeUCentar(sd.Domacin.NazivKluba, 50)}|{PoravnanjeUCentar(sd.Gost.NazivKluba, 50)}|");
            Console.WriteLine(IspisiRazmaknicu(103));
            Console.WriteLine($"|{PoravnanjeUCentar(sd.Domacin.BrojGolova.ToString(), 50)}|{PoravnanjeUCentar(sd.Gost.BrojGolova.ToString(), 50)}|");
            Console.WriteLine(IspisiRazmaknicu(103));
            int brojStrijelaca;
            int brojStrijelacaDomacin = sd.Domacin.Golovi.Count;
            int brojStrijelacaGost = sd.Gost.Golovi.Count;
            if (brojStrijelacaDomacin >= brojStrijelacaGost)
            {
                brojStrijelaca = brojStrijelacaDomacin;
            }
            else
            {
                brojStrijelaca = brojStrijelacaGost;
            }
            for (int i = 0; i <= brojStrijelaca; i++)
            {
                string strijelacDomacin;
                string strijelacGost;

                if (brojStrijelacaDomacin - 1 >= i)
                {
                    strijelacDomacin = sd.Domacin.Golovi[i];
                }
                else
                {
                    strijelacDomacin = "";
                }

                if (brojStrijelacaGost - 1 >= i)
                {
                    strijelacGost = sd.Gost.Golovi[i];
                }
                else
                {
                    strijelacGost = "";
                }

                Console.WriteLine($"|{PoravnanjeUCentar(strijelacDomacin, 50)}|{PoravnanjeUCentar(strijelacGost, 50)}|");
            }
            Console.WriteLine(IspisiRazmaknicu(103));
            Console.WriteLine($"|{PoravnanjeUCentar(sd.Domacin.Ostalo, 50)}|{PoravnanjeUCentar(sd.Gost.Ostalo, 50)}|");
            Console.WriteLine(IspisiRazmaknicu(103));
        }

        private string PoravnanjeUCentar(string s, int duzina)
        {
            if (s.Length >= duzina)
            {
                return s;
            }

            int prostorLijevo = (duzina - s.Length) / 2;
            int prostorDesno = duzina - s.Length - prostorLijevo;

            return new string(' ', prostorLijevo) + s + new string(' ', prostorDesno);
        }

        private string IspisiRazmaknicu(int duzina)
        {
            string razmaknica = "";
            for (int i = 0; i < duzina; i++)
            {
                razmaknica += "-";
            }
            return razmaknica;
        }
    }
}
