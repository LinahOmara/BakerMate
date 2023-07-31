using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using BakerMate.WPF.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.WPF.ViewModel
{
    public class CategoryViewModel : MasterDetailDataGridViewModel
    {
        public override void PopulateDetailList()
        {
          Category category = (Category)MasterSelectedItem;
            if (category is not null)
            {
                if (category.Recipes is not null)
                {
                    DetailList = new(category.Recipes);
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
            MasterList = new(bakerMateContext.Set<Category>().Include(x => x.Recipes).ThenInclude(x => x.BaseIngredient).ToList());
        }

        public CategoryViewModel()
        {
            List<Category> categories = bakerMateContext.Set<Category>().Include(x => x.Recipes).ThenInclude(x => x.BaseIngredient).ToList();
            MasterList = new(categories);
        }
    }
}
