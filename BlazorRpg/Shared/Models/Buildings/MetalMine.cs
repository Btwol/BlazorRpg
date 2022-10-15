using BlazorRpg.Shared.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models.Buildings
{
    public class MetalMine : Building
    {
        public override string Name { get; set; } = "Metal Mine";
        public override Dictionary<double, Resource>? Extraction { get; set; } = new Dictionary<double, Resource>()
        {
            { 10, Resource.Metal }
        };
    }
}
