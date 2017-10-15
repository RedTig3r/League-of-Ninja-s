using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.Model
{
    class DummyNinjaRepo : NinjaRepository
    {
        public List<Ninja> GetNinjas()
        {
            var ninjas = new List<Ninja>();

            ninjas.Add(new Ninja { Id = 1, Name = "Madonna", Gold = 2500 });
            ninjas.Add(new Ninja { Id = 2, Name = "Prince", Gold = 3000 });
            ninjas.Add(new Ninja { Id = 3, Name = "Michael Jackson", Gold = 3000 });
            
            return ninjas;
        }
    }
}
