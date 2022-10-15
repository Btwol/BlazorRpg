using BlazorRpg.Shared.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models.Buildings
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static double[] LevelModifiers { get; set; } = new double[] { 1, 1.5, 2, 3, 4, 6, 8, 12 };
        public int Level { get; set; } = 1;
        public virtual IEnumerable<BuildingComponent> BuildingComponents { get; set; }



        public Dictionary<double, Resource> GetCurrentExtraction(int Level)
        {
            Dictionary<double, Resource> currentExtraction = new Dictionary<double,Resource>();
            foreach(KeyValuePair<double, Resource> resources in Extraction)
            {
                if(Level <= LevelModifiers.Count())
                {
                    currentExtraction.Add(resources.Key*LevelModifiers[Level-1], resources.Value);
                }
                else currentExtraction.Add(resources.Key * LevelModifiers[LevelModifiers.Count()-1]*(LevelModifiers.Count()-Level), resources.Value);
            }
            return currentExtraction;
        }
    }
}
