using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lpintaric_zadaca_3.PrikazStatistike
{
    public abstract class DogadajObserver
    {
        protected DogadajiSubject dogadajiSubject;
        public abstract void Azuriraj();
    }
}
