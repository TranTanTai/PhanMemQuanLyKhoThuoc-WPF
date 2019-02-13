using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class UnitViewModel : BaseViewModel
    {
        private ObservableCollection<Unit> _List;
        public ObservableCollection<Unit> List { get { return _List; } set { _List = value; OnPropertyChanged(); } }

        private Unit _SelectedItem;
        public Unit SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; } 
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SortDisplayNameCommand { get; set; }
        public ICommand SortIdCommand { get; set; }
        public bool IsSort { get; set; }
        public UnitViewModel()
        {
            List = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            #region Add
            AddCommand = new RelayCommand<Unit>((p) =>
            {
                if (string.IsNullOrWhiteSpace(DisplayName))
                    return false;
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var unit = new Unit() { DisplayName = DisplayName.Trim() };
                DataProvider.Ins.DB.Units.Add(unit);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(unit);
                DisplayName = null;
            });
            #endregion
            #region Edit
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.Id == SelectedItem.Id);
                if (displayList == null || displayList.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                var unit = DataProvider.Ins.DB.Units.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                unit.DisplayName = DisplayName.Trim();
                DataProvider.Ins.DB.SaveChanges();
                DisplayName = null;
            });
            #endregion
            #region Sort
            SortDisplayNameCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("DisplayName", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("DisplayName", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortIdCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            #endregion
        }
    }
}
