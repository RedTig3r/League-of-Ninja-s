using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.Model
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public int Gold { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Agility { get; set; }
    }
}
