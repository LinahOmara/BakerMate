using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class RecipeSize
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
        public string? Size { get; set; }
        public double Multiplier { get; set; }
        public double OutputWeight { get; set; }
        public Recipe? Recipe { get; set;}
    }
}
