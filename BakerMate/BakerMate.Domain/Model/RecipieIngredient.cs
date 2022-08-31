using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class RecipieIngredient
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
        public Recipie Recipie { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Quantity { get; set; }


    }
}
