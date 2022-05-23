using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public interface ICombatant
    {
        public int Str { get; set; }
        public int Int { get; set; }
        public int Att { get; set; }
        public int Vit { get; set; }
        public int Def { get; set; }
        public int Wis { get; set; }
        public int Agi { get; set; }
        public int Luck { get; set; }
        public long HP { get; set; }
        public long MP { get; set; }
    }
}
