using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
        public int IngredientId { get; set; }
        public double IngredientQuantity { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }


    }
}
