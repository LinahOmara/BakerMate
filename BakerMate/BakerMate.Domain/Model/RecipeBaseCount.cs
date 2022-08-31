using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class RecipeBaseCount
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
        public double BaseCount { get; set; }
        public int Size { get; set; }
        public Recipe Recipe { get; set; }

    }
}
