using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using BakerMate.WPF.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.WPF.ViewModel
{
    public class RecipeIngredientViewModel : MasterDetailDataGridViewModel
    {
        private ObservableCollection<Ingredient> ingredients;    

        public ObservableCollection<Ingredient> Ingredients
        {
            get => ingredients;
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }
        private ObservableCollection<UnitOfMeasure> unitOfMeasures;

        public ObservableCollection<UnitOfMeasure> UnitOfMeasures
        {
            get => unitOfMeasures;
            set
            {
                unitOfMeasures = value;
                OnPropertyChanged(nameof(UnitOfMeasures));
            }
        }
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
            MasterList = new(bakerMateContext.Set<RecipeIngredient>().Where(x => x.RecipieId == Recipe.Id).ToList());
        }

        public override void PopulateDetailList()
        {
        }

        public RecipeIngredientViewModel(Recipe recipe)
        {
            List<RecipeIngredient> recipeIngredient = bakerMateContext.Set<RecipeIngredient>().Where(x => x.RecipieId == recipe.Id).ToList();
            List<Ingredient> ingredients = bakerMateContext.Set<Ingredient>().ToList();
            List<UnitOfMeasure> unitOfMeasures = bakerMateContext.Set<UnitOfMeasure>().ToList();
            UnitOfMeasures = new(unitOfMeasures);
            Ingredients = new(ingredients);
            MasterList = new(recipeIngredient);
            Recipe = recipe;
            AddCommand = new RelayCommand
            (
            x =>
            {
                var Entity = new RecipeIngredient();
                Entity.RecipieId = recipe.Id;
                MasterList.Add(Entity);
                bakerMateContext.Add(Entity);
            }
            );
        }
    }
}
