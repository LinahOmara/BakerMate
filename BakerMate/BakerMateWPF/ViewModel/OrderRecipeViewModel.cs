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
    public class OrderRecipeViewModel : MasterDetailDataGridViewModel
    {
        private ObservableCollection<RecipeBaseCount> recipeBaseCounts;    

        public ObservableCollection<RecipeBaseCount> RecipeBaseCounts
        {
            get => recipeBaseCounts;
            set
            {
                recipeBaseCounts = value;
                OnPropertyChanged(nameof(RecipeBaseCounts));
            }
        }

        private Order order;

        public Order Order
        {
            get => order;
            set
            {
                order = value;
                OnPropertyChanged(nameof(Order));
            }
        }
        protected override void RevertAction()
        {
            foreach (var item in MasterList)
            {
                bakerMateContext.Entry(item).CurrentValues.SetValues(bakerMateContext.Entry(item).OriginalValues);
            }
            MasterList.Clear();
            MasterList = new(bakerMateContext.Set<OrderRecipe>().Where(x => x.OrderId == Order.OrderId).ToList());
        }

        public override void PopulateDetailList()
        {
        }

        public OrderRecipeViewModel(Order order)
        {
            List<OrderRecipe> orderRecipes = bakerMateContext.Set<OrderRecipe>().Where(x => x.OrderId == order.OrderId).ToList();
            List<RecipeBaseCount> recipeBaseCounts = bakerMateContext.Set<RecipeBaseCount>().ToList();
            MasterList = new(orderRecipes);
            Order = order;
            AddCommand = new RelayCommand
            (
            x =>
            {
                var Entity = new OrderRecipe();
                Entity.OrderId = Order.OrderId;
                MasterList.Add(Entity);
                bakerMateContext.Add(Entity);
            }
            );
        }
    }
}
