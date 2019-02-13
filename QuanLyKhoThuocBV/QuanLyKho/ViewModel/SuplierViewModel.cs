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
    public class SuplierViewModel : BaseViewModel
    {
        private ObservableCollection<Suplier> _List;
        public ObservableCollection<Suplier> List { get { return _List;} set { _List = value; OnPropertyChanged(); } }
        private Suplier _SelectedItem;
        public Suplier SelectedItem
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
                    Email = SelectedItem.Email;
                    Address = SelectedItem.Address;
                    MoreInfo = SelectedItem.MoreInfo;
                    ContractDate = SelectedItem.ContractDate;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName;} set { _DisplayName = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get { return _Phone;} set { _Phone = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get { return _Address;} set { _Address = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get { return _Email;} set { _Email = value; OnPropertyChanged(); } }
        private string _MoreInfo;
        public string MoreInfo { get { return _MoreInfo;} set { _MoreInfo = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate;
        public DateTime? ContractDate { get { return _ContractDate; } set { _ContractDate = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand SortIdCommand { get; set; }
        public ICommand SortDisplayNameCommand { get; set; }
        public ICommand SortAddressCommand { get; set; }
        public ICommand SortOutputPriceCommand { get; set; }
        public ICommand SortPhoneCommand { get; set; }
        public ICommand SortEmailCommand { get; set; }
        public ICommand SortMoreInfoCommand { get; set; }
        public ICommand SortContractDateCommand { get; set; }
        public bool IsSort { get; set; }
        public SuplierViewModel()
        {
            List = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            _ContractDate = DateTime.Now;
            #region Add
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrWhiteSpace(DisplayName) || ContractDate == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Supliers.Where(x => x.DisplayName == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var Suplier = new Suplier() { DisplayName = DisplayName.Trim(),Phone = Phone, Address = Address, Email = Email, ContractDate = ContractDate, MoreInfo = MoreInfo};
                DataProvider.Ins.DB.Supliers.Add(Suplier);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(Suplier);
                Reset();
            });
            #endregion
            #region Edit
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || string.IsNullOrWhiteSpace(DisplayName))
                    return false;
                return true;
            }, (p) =>
            {
                var Suplier = DataProvider.Ins.DB.Supliers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Suplier.Phone = Phone;
                Suplier.DisplayName = DisplayName.Trim();
                Suplier.Address = Address;
                Suplier.Email = Email;
                Suplier.ContractDate = ContractDate;
                Suplier.MoreInfo = MoreInfo;
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
            SortAddressCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Address", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Address", ListSortDirection.Descending));
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
            SortOutputPriceCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("OutputPrice", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("OutputPrice", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortEmailCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Email", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Email", ListSortDirection.Descending));
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
            SortContractDateCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("ContractDate", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("ContractDate", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            #endregion
        }
        void Reset()
        {
            DisplayName = null;
            Address = null;
            Phone = null;
            Email = null;
            MoreInfo = null;
            ContractDate = DateTime.Now;
        }
    }
}
