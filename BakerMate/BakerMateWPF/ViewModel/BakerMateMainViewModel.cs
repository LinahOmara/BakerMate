using BakerMate.WPF.Command;
using BakerMate.WPF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BakerMate.WPF.ViewModel
{
    public class BakerMateMainViewModel : ObservableObject
    {
        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }
        public CategoryViewModel CategoryViewModel { get; set; }
        public ICommand CategoryCommand { get; set; }
        public ICommand RecipeCommand { get; set; }
        public ICommand IngredientCommand { get; set; }
        public ICommand UnitOfMeasureCommand { get; set; }
        public ICommand OrderCommand { get; set; }

        public BakerMateMainViewModel()
        {
            CategoryViewModel = new();
            CategoryCommand = new RelayCommand(x => { CurrentView = CategoryViewModel; });
        }
    }
}
