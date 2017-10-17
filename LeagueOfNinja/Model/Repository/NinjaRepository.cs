using LeagueOfNinja.Model;
using LeagueOfNinja.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueofNinja.Model.Repository
{
    class NinjaRepository : INinjaRepository
    {
        public List<Ninja> GetNinjas()
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninjas.ToList();
            }
        }
    }
}
