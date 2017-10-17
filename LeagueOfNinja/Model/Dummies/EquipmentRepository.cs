using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.Model
{
    interface EquipmentRepository
    {
        List<Equipment> GetEquipments();
    }
}
