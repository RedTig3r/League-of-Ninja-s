using LeagueOfNinja.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.Model
{
    interface INinjaRepository
    {
        List<Ninja> GetNinjas();

    }
}
