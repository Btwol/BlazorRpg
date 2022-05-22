using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public class SecondTestModel : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
