using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    class CustomerViewModel:BaseViewModel
    {
        private ObservableCollection<Customer> _List;
        public ObservableCollection<Customer> List { get { return _List; } set { _List = value; OnPropertyChanged(); } }

        private Customer _SelectedItem;
        public Customer SelectedItem
        {
            get { return _SelectedItem;}
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Phone = SelectedItem.Phone;
                    MoreInfo = SelectedItem.MoreInfo;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName;} set { _DisplayName = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get { return _Phone;} set { _Phone = value; OnPropertyChanged(); } }

        private string _MoreInfo;
        public string MoreInfo { get { return _MoreInfo;} set { _MoreInfo = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get { return _ContractDate; } set { _ContractDate = value; OnPropertyChanged(); } }

        private string _name;
        public string name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SortIdCommand { get; set; }
        public ICommand SortDisplaynameCommand { get; set; }
        public ICommand SortPhoneCommand { get; set; }
        public ICommand SortMoreInfoCommand { get; set; }
        public bool IsSort { get; set; }
        public CustomerViewModel()
        {
            List = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            #region Add
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrWhiteSpace(DisplayName))
                    return false;
                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.DisplayName == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var Customer = new Customer() { DisplayName = DisplayName.Trim(), Phone = Phone, MoreInfo = MoreInfo };
                DataProvider.Ins.DB.Customers.Add(Customer);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(Customer);
                Reset();
            });
            #endregion
            
            #region Edit
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || string.IsNullOrWhiteSpace(DisplayName))
                    return false;

                var CustomerList = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id);
                if (CustomerList != null && CustomerList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                
                var Customer = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Customer.DisplayName = DisplayName.Trim();
                Customer.Phone = Phone;
                Customer.MoreInfo = MoreInfo;
                DataProvider.Ins.DB.SaveChanges();
                Reset();
            });
            #endregion
            
            #region Sort
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
            SortDisplaynameCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Displayname", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Displayname", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortPhoneCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Phone", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Phone", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortMoreInfoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("MoreInfo", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("MoreInfo", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            #endregion
        }
        void Reset()
        {
            DisplayName = null;
            Phone = null;
            MoreInfo = null;
        }
    }
}
