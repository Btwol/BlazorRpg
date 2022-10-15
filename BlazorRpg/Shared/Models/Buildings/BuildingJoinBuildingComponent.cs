using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models.Buildings
{
    public class BuildingJoinBuildingComponent
    {
        [Key, Column(Order = 1)]
        public int BuildingId { get; set; }
        [Key, Column(Order = 2)]
        public int BuildingComponentId { get; set; }
        public virtual Building Building { get; set; }
        public virtual BuildingComponent BuildingComponent { get; set; }
    }
}
