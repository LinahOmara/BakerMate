using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using BakerMate.WPF.Command;
using BakerMate.WPF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BakerMate.WPF.ViewModel
{
    public class RecipesViewModel : MasterDetailDataGridViewModel
    {

        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Category> categories;
        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }
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

        public override void PopulateDetailList()
        {
            if (MasterSelectedItem is not null)
            {
                Recipe recipe = (Recipe)MasterSelectedItem;
                if (recipe is not null)
                {
                    if (recipe.RecipeIngredients is not null)
                    {
                        RecipeIngredientViewModel recipeIngredientViewModel = new(recipe);
                        CurrentView = recipeIngredientViewModel;
                    }
                }
            }
        }
        public ICommand BaseIngredientSizeCommand { get; set; }

        protected override void RevertAction()
        {
            foreach (var item in MasterList)
            {
                bakerMateContext.Entry(item).CurrentValues.SetValues(bakerMateContext.Entry(item).OriginalValues);
            }
            MasterList.Clear();
            MasterList = new(bakerMateContext.Set<Recipe>().Include(x => x.Category).Include(x => x.BaseIngredient).Include(x => x.RecipeIngredients).ThenInclude(x => x.Ingredient).Include(x => x.RecipeBaseCounts).ToList());
            bakerMateContext.ChangeTracker.Clear();
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
