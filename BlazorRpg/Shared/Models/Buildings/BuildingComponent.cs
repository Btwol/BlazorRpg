using BlazorRpg.Shared.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models.Buildings
{
    public class BuildingComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Resource? Resource { get; set; }
        public double? ResourceValue { get; set; }
        public int Level { get; set; } = 1;
        public virtual IEnumerable<Building> Buildings { get; set; }
    }
}
