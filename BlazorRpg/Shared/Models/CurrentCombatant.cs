using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public class CurrentCombatant : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsPlayer { get; set; }  //or team1, team2...
        public bool Status { get; set; }    //enum List, status effects(dazed, stunned, blinded, dead etc),
                                            //consider adding bool Alive and status only for temp effects on Combatant
        public long CurrentHP { get; set; }
        public virtual Combatant? Combatant { get; set; }
        public int? CombatantId { get; set; }
        public int? EncounterId { get; set; } = 0;    //used to differentiate between encounters
        public int Initiative { get; set; }
    }
}
