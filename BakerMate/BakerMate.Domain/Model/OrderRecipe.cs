using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class OrderRecipe
    {
        public int RecipeId { get; set; }
        public int OrderId { get; set; }
        public Recipe Recipe { get; set; }
        public Order Order { get; set; }
    }
}
