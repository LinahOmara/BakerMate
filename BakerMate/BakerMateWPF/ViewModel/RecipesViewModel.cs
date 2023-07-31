using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using BakerMate.WPF.Command;
using BakerMate.WPF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BakerMate.WPF.ViewModel
{
    public class RecipesViewModel : MasterDetailDataGridViewModel
    {
        private RecipeBaseCount RecipeBaseCountSelectedItem;
        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Category> categories;
        private ObservableCollection<RecipeBaseCount> recipeBaseCounts;
        public RecipeBaseCount SelectedRecipeBaseCount { get; set; }
        public ObservableCollection<Ingredient> Ingredients
        {
            get => ingredients;
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public ObservableCollection<RecipeBaseCount> RecipeBaseCounts
        {
            get => recipeBaseCounts;
            set
            {
                recipeBaseCounts = value;
                OnPropertyChanged(nameof(RecipeBaseCounts));
            }
        }

        public override void PopulateDetailList()
        {
            if (MasterSelectedItem is not null)
            {
                Recipe recipe = (Recipe)MasterSelectedItem;
                DetailList = new(recipe.RecipeIngredients);
            }
        }

        public ICommand BaseIngredientSizeCommand { get; set; }

        protected override void RevertAction()
        {
            throw new NotImplementedException();
        }

        public RecipesViewModel()
        {
            List<Recipe> recipes = bakerMateContext.Set<Recipe>().Include(x=>x.Category).Include(x=>x.BaseIngredient).Include(x => x.RecipeIngredients).ThenInclude(x=>x.Ingredient).Include(x=>x.RecipeBaseCounts).ToList();
            List<Ingredient> ingredients = bakerMateContext.Set<Ingredient>().ToList();
            List<Category> categories = bakerMateContext.Set<Category>().ToList();
            BaseIngredientSizeCommand = new RelayCommand(x =>
            {
                Recipe recipe = (Recipe)MasterSelectedItem;
                BaseIngredientCountViewModel baseIngredientCountViewModel = new(recipe);
                WindowService windowService = new WindowService();
                windowService.ShowWindow(baseIngredientCountViewModel);
            },                
                x => { return MasterSelectedItem is not null;}
            );
            MasterList = new(recipes);
            Ingredients = new(ingredients);
            Categories = new(categories);

        }
    }
}
