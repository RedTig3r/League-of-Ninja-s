using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueofNinja.Model
{
    class NinjaRepository : INinjaRepository
    {
        public List<Ninja> GetNinjas()
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninja.ToList();
            }
        }
    }
}
