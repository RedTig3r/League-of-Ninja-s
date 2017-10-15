using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.Model
{
    class DummyEquipmentRepo : Equipment
    {
       public List<Equipment> GetEquipments()
        {
            var equipments = new List<Equipment>();

            equipments.Add(new Equipment { Id = 1, Title = "Madonna", Category = "Head" , Strength = 22, Intelligence = 5 ,Gold = 800 });
            equipments.Add(new Equipment { Id = 2, Title = "Prince", Strength = 3, Agility = 10, Gold = 500 });
            equipments.Add(new Equipment { Id = 3, Title = "Michael Jackson", Strength = 6, Agility = 90, Intelligence = 5 ,Gold = 1600 });

            return equipments;
        }
    }
}
