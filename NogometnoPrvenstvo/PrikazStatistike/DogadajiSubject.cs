using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public class DogadajiSubject
    {
        private List<DogadajObserver> observeri = new List<DogadajObserver>();
        private StatistikaDogadaj trenutniDogadaj;

        public StatistikaDogadaj DohvatiTrenutnoStanje()
        {
            return trenutniDogadaj;
        }
        public void PostaviNovoStanje(StatistikaDogadaj noviDogadaj)
        {
            trenutniDogadaj = noviDogadaj;
            PoslajiObavjest();
        }

        public void DodajObservera(DogadajObserver observer)
        {
            observeri.Add(observer);
        }
        
        public void PoslajiObavjest()
        {
            foreach(DogadajObserver obs in observeri)
            {
                obs.Azuriraj();
            }
        }


    }
}
