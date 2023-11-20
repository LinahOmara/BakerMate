using BakerMate.WPF.Command;
using BakerMate.WPF.Domain;
using BakerMate.WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BakerMate.WPF.ViewModel
{
    public class BakerMateMainViewModel : ObservableObject
    {
        private object currentView;

        public object CurrentView 
        { get { return currentView; } 
          set { currentView = value; OnPropertyChanged(nameof(CurrentView)); } 
        }

        public CategoryViewModel CategoryViewModel { get; set; }
        public IngredientViewModel IngredientViewModel { get; set; }
        public RecipesViewModel RecipeViewModel { get; set; }
        public UnitOfMeasureViewModel UnitOfMeasureViewModel { get; set; }
        public OrdersViewModel OrdersViewModel { get; set; }
        public ICommand CategoryCommand { get; set; }
        public ICommand RecipeCommand { get; set; }
        public ICommand IngredientCommand { get; set; }
        public ICommand UnitOfMeasureCommand { get; set; }
        public ICommand OrderCommand { get; set; }

        public BakerMateMainViewModel()
        {
            CategoryViewModel = new();
            CurrentView = CategoryViewModel;
            CategoryCommand = new RelayCommand(x => { CurrentView = CategoryViewModel; });
            IngredientViewModel = new();
            IngredientCommand = new RelayCommand(x => { CurrentView = IngredientViewModel; });
            RecipeViewModel = new();
            RecipeCommand = new RelayCommand(x => { CurrentView = RecipeViewModel; });
            UnitOfMeasureViewModel = new();
            UnitOfMeasureCommand = new RelayCommand(x => { CurrentView = UnitOfMeasureViewModel; });
            OrdersViewModel = new();
            OrderCommand = new RelayCommand(x => { CurrentView = OrdersViewModel; });
        }
    }
}
