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
    public class UnitOfMeasureViewModel : MasterDetailDataGridViewModel
    {
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
        public UnitOfMeasureViewModel()
        {
            List<UnitOfMeasure> unitOfMeasures = bakerMateContext.Set<UnitOfMeasure>().ToList();
            MasterList = new(unitOfMeasures);
        }

    }
}
