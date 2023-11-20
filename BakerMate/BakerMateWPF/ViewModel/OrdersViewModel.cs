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

        public override void PopulateDetailList()
        {
            if (MasterSelectedItem is not null)
            {
                Order order = (Order)MasterSelectedItem;
                if (order is not null)
                {
                    if (order.OrderRecipes is not null)
                    {
                        OrderRecipeViewModel orderRecipeViewModel = new(order);
                        CurrentView = orderRecipeViewModel;
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
            MasterList = new(bakerMateContext.Set<Order>().Include(x => x.OrderRecipes).ToList());
            bakerMateContext.ChangeTracker.Clear();
        }

        public OrdersViewModel()
        {
            List<Order> orders = bakerMateContext.Set<Order>().Include(x=>x.OrderRecipes).ToList();
            MasterList = new(orders);
            AddCommand = new RelayCommand
                (
                x =>
                {
                    Order Entity = new();
                    Entity.OrderingDate = DateTime.Now;
                    Entity.DeliveryDate = DateTime.Now;
                    MasterList.Add(Entity);
                    bakerMateContext.Add(Entity);
                }
                );
        }
    }
}
