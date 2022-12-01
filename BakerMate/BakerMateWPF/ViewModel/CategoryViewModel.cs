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
          DetailList = new(category.Recipes);           
        }
        public CategoryViewModel()
        {
            List<Category> categories = bakerMateContext.Set<Category>().Include(x => x.Recipes).ThenInclude(x => x.BaseIngredient).ToList();
            MasterList = new(categories);
        }
    }
}
