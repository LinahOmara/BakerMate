using BakerMate.DbContext.Presistance;
using BakerMate.WPF.Command;
using BakerMate.WPF.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BakerMate.WPF.ViewModel
{
    public abstract class MasterDetailDataGridViewModel : ObservableObject
    {
        private ObservableCollection<Object> masterList;
        private ObservableCollection<Object> detailList;
        private Object masterSelectedItem;
        private Object detailSelectedItem;
        public bool editVisability;
        public BakerMateContext bakerMateContext;

        public bool EditVisability
        {
            get { return editVisability; }
            set { editVisability = value; OnPropertyChanged(nameof(EditVisability)); }
        }
        public ObservableCollection<Object> MasterList
        {
            get => masterList;
            set
            {
                masterList = value;
                OnPropertyChanged(nameof(MasterList));
            }
        }
        public ObservableCollection<Object> DetailList
        {
            get => detailList;
            set
            {
                detailList = value;
                OnPropertyChanged(nameof(DetailList));
            }
        }
        public Object MasterSelectedItem
        {
            get => masterSelectedItem;
            set
            {
                masterSelectedItem = value;
                OnPropertyChanged(nameof(MasterSelectedItem));
                PopulateDetailList();
            }
        }
        public Object DetailSelectedItem
        {
            get => detailSelectedItem;
            set
            {
                detailSelectedItem = value;
                OnPropertyChanged(nameof(detailSelectedItem));
            }
        }

        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set;  }
        public ICommand CommitCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand RevertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        
        public abstract void PopulateDetailList();
        protected abstract void RevertAction();

        protected MasterDetailDataGridViewModel()
        {
            AppDbContextFactory contextfactory = new();
            bakerMateContext = contextfactory.CreateDbContext();
            EditCommand = new RelayCommand(x => { EditVisability = !EditVisability; });
            AddCommand = new RelayCommand
                (
                x =>
                {               
                    var Entity = Activator.CreateInstance(MasterList.ElementAt(0).GetType());
                    MasterList.Add(Entity);
                    bakerMateContext.Add(Entity);
                }
                );
            CommitCommand = new RelayCommand
            (
             x =>
                {
                    bakerMateContext.SaveChangesAsync();
                }
                , 
             x=> {return bakerMateContext.ChangeTracker.HasChanges(); }
            );
            RevertCommand = new RelayCommand
            (
             x =>
                {
                    RevertAction();
                }
                , 
             x=> {return bakerMateContext.ChangeTracker.HasChanges(); }
            );
            DeleteCommand = new RelayCommand
                (
                x =>
                {
                    bakerMateContext.Remove(MasterSelectedItem);
                    MasterList.Remove(MasterSelectedItem);
                }
                ,
                x => { return MasterSelectedItem is not null; }
                );
            CopyCommand = new RelayCommand
                (
                x =>
                {
                    var NewEntity = Activator.CreateInstance(MasterSelectedItem.GetType());
                    MasterList.Add(NewEntity);
                    bakerMateContext.Add(NewEntity);
                    bakerMateContext.Entry(NewEntity).CurrentValues.SetValues(bakerMateContext.Entry(MasterSelectedItem).CurrentValues);
                }
                ,
                x => { return MasterSelectedItem is not null; }
                );
        }
    }
}
