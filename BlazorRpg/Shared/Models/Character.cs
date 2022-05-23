using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public class Character : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public long Exp { get; set; }
        public CharacterClass Class { get; set; }

    }
}
