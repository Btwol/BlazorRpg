﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public class Combatant// : ICombatant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public long Exp { get; set; }
        public CharacterClass Class { get; set; }
        public int Str { get; set; } = 10;
        public int Int { get; set; } = 10;
        public int Att { get; set; } = 10;
        public int Vit { get; set; } = 10;
        public int Def { get; set; } = 10;
        public int Wis { get; set; } = 10;
        public int Agi { get; set; } = 10;
        public int Luck { get; set; } = 10;
        public long HP { get; set; } = 100;
        public long MP { get; set; } = 100;

        //List<enum GlobalStatus> GlobalStatuses
    }
}
