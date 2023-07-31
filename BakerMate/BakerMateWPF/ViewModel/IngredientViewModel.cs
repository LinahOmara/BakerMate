using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.WPF.ViewModel
{
    public class IngredientViewModel : MasterDetailDataGridViewModel
    {
        private ObservableCollection<UnitOfMeasure> unitOfMeasures;
        public ObservableCollection<UnitOfMeasure> UnitOfMeasures { get => unitOfMeasures;
            set
            {
                unitOfMeasures = value;
                OnPropertyChanged(nameof(UnitOfMeasures));
            } 
        }
        public override void PopulateDetailList()
        {
        }

        protected override void RevertAction()
        {
            foreach (var item in MasterList)
            {
                bakerMateContext.Entry(item).CurrentValues.SetValues(bakerMateContext.Entry(item).OriginalValues);
            }
            MasterList.Clear();
            MasterList = new(bakerMateContext.Set<Ingredient>().Include(x => x.UnitOfMeasure).ToList());
        }
        public IngredientViewModel()
        {
            List<Ingredient> ingredients = bakerMateContext.Set<Ingredient>().Include(x => x.UnitOfMeasure).ToList();
            List<UnitOfMeasure> unitOfMeasures = bakerMateContext.Set<UnitOfMeasure>().ToList();
            UnitOfMeasures = new(unitOfMeasures);
            MasterList = new(ingredients);
        }

    }
}
