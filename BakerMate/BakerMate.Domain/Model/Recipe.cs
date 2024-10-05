using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseIngredientId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } // TODO: remove ?
        public Ingredient BaseIngredient { get; set; } // TODO: remove ?
        public List<RecipeIngredient> RecipeIngredients { get; set;}
        public List<RecipeBaseCount> RecipeBaseCounts { get; set; }


    }
}
