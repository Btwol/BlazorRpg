using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public class CurrentCombatant
    {
        public Combatant Combatant { get; set; }
        public bool IsPlayer { get; set; }
        public bool Status { get; set; }    //enum, status effects(dazed, stunned, blinded, dead etc)
    }
}
