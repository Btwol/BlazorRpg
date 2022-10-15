using BlazorRpg.Shared.Models.Buildings;
using BlazorRpg.Shared.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public class ResourceProfile : IBaseModel
    {
        public int Id { get; set; }
        public double Metals { get; set; } = 0;
        public double Crystals { get; set; } = 0;
        public double Fuel { get; set; } = 0;
        public DateTime LastSave { get; set; } = DateTime.UnixEpoch;
        public List<Building> Buildings { get; set; }
        public Dictionary<double, Resource> CurrentExtraction { get; set; }
        //public List<string> Modifiers { get; set; }
    }
}
