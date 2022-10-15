using BlazorRpg.Shared.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models.Buildings
{
    public class FuelMine : Building
    {
        public override string Name { get; set; } = "Fuel Mine";
        public override Dictionary<double, Resource>? Extraction { get; set; } = new Dictionary<double, Resource>()
        {
            { 2, Resource.Fuel }
        };
    }
}
