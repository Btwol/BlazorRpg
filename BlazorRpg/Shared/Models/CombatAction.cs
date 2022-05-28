using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public class CombatAction
    {
        public int ActorId { get; set; }
        public int? TargetId { get; set; }
        public int ActionId { get; set; }
    }
}
