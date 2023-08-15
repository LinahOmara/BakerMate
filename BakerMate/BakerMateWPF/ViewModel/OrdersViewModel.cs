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
    public class OrdersViewModel : MasterDetailDataGridViewModel
    {


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

        public OrdersViewModel()
        {
            List<Order> orders = bakerMateContext.Set<Order>().Include(x=>x.OrderRecipes).ToList();
            MasterList = new(orders);


        }
    }
}
