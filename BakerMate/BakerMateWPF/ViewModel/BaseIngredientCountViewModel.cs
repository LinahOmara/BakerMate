using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.WPF.ViewModel
{
    public class BaseIngredientCountViewModel : MasterDetailDataGridViewModel
    {
        private Recipe recipe;

        public Recipe Recipe {
            get => recipe;
            set
            {
                recipe = value;
                OnPropertyChanged(nameof(Recipe));
            }
        }
        protected override void RevertAction()
        {
            foreach (var item in MasterList)
            {
                bakerMateContext.Entry(item).CurrentValues.SetValues(bakerMateContext.Entry(item).OriginalValues);
            }
            MasterList.Clear();
            MasterList = new(bakerMateContext.Set<RecipeBaseCount>().Where(x => x.RecipieId == Recipe.Id).ToList());
        }

        public override void PopulateDetailList()
        {
        }

        public BaseIngredientCountViewModel(Recipe recipe)
        {
            List<RecipeBaseCount> recipeBaseCount = bakerMateContext.Set<RecipeBaseCount>().Where(x => x.RecipieId == recipe.Id).ToList();
            MasterList = new(recipeBaseCount);
            Recipe = recipe;
        }
    }
}
