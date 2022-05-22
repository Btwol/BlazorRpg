using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRpg.Shared.Models
{
    public class TestModel : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual SecondTestModel? SecondTestModel { get; set; }
        public int? SecondTestModelId { get; set; }
    }
}
