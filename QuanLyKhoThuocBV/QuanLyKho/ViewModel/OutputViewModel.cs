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
    class OutputViewModel:BaseViewModel
    {
        private ObservableCollection<XuatKho> _XuatKhoList;
        public ObservableCollection<XuatKho> XuatKhoList { get { return _XuatKhoList; } set { _XuatKhoList = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.Output> _Output;
        public ObservableCollection<Model.Output> Output { get { return _Output; } set { _Output = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.Object> _Object;
        public ObservableCollection<Model.Object> Object { get { return _Object; } set { _Object = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.Customer> _Customer;
        public ObservableCollection<Model.Customer> Customer { get { return _Customer; } set { _Customer = value; OnPropertyChanged(); } }
        private Model.XuatKho _SelectedItem;
        public Model.XuatKho SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Count = SelectedItem.Count;
                    Status = SelectedItem.Status;
                    SelectedCustomer = SelectedItem.Customer;
                    SelectedOutput = SelectedItem.Output;
                    SelectedObject = SelectedItem.Object;
                }
            }
        }

        private Model.Output _SelectedOutput;
        public Model.Output SelectedOutput
        {
            get { return _SelectedOutput; }
            set
            {
                _SelectedOutput = value;
                OnPropertyChanged();
            }
        }
        private Model.Customer _SelectedCustomer;
        public Model.Customer SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set
            {
                _SelectedCustomer = value;
                OnPropertyChanged();
            }
        }
        private Model.Object _SelectedObject;
        public Model.Object SelectedObject
        {
            get { return _SelectedObject; }
            set
            {
                _SelectedObject = value;
                OnPropertyChanged();
            }
        }
        private Nullable<double> _OutputPrice;
        public Nullable<double> OutputPrice { get { return _OutputPrice; } set { _OutputPrice = value; OnPropertyChanged(); } }
        private Nullable<int> _Count;
        public Nullable<int> Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }
        private int _IdCustomer;
        public int IdCustomer { get { return _IdCustomer; } set { _IdCustomer = value; OnPropertyChanged(); } }
        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get { return _IdObject; } set { _IdObject = value; OnPropertyChanged(); } }
        private string _IdOutput;
        public string IdOutput { get { return _IdOutput; } set { _IdOutput = value; OnPropertyChanged(); } }
        private DateTime? _DateOutput;
        public DateTime? DateOutput { get { return _DateOutput; } set { _DateOutput = value; OnPropertyChanged(); } }
        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand TKCommand { get; set; }
        public bool IsSort { get; set; }
        public OutputViewModel()
        {
            XuatKhoList = new ObservableCollection<XuatKho>();
            Output = new ObservableCollection<Model.Output>(DataProvider.Ins.DB.Outputs);
            Object = new ObservableCollection<Model.Object>(DataProvider.Ins.DB.Objects);
            Customer = new ObservableCollection<Model.Customer>(DataProvider.Ins.DB.Customers);
            _DateOutput = DateTime.Now;
            _Count = 0;
            #region Add
            AddCommand = new RelayCommand<object>((p) =>
            {
                foreach (var i in XuatKhoList)
                {
                    if (i.Object.Id == SelectedObject.Id || i.Customer.Id != SelectedCustomer.Id)
                    {
                        return false;
                    }
                }
                if (SelectedObject == null || DateOutput == null || SelectedCustomer == null || Count < 0)
                    return false;
                return true;
            }, (p) =>
            {
                var InputInfo = new Model.XuatKho() { Object = SelectedObject, Count = Count, Customer = SelectedCustomer, OutputPrice = Count * SelectedObject.Price, Status = Status, Id = Guid.NewGuid().ToString() };
                XuatKhoList.Add(InputInfo);
            });
            #endregion
            #region Save
            SaveCommand = new RelayCommand<object>((p) =>
            {
                foreach (var i in XuatKhoList)
                {
                    if (i.Count <= 0)
                    {
                        return false;
                    }
                }
                if (XuatKhoList.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {

                if (MessageBox.Show("Bạn có thật sự muốn lưu?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.OK)
                {
                    return;
                }
                else
                {
                    int dem = 0;
                    var Outputs = new Model.Output() { Id = Guid.NewGuid().ToString(), DateOutput = DateOutput };
                    DataProvider.Ins.DB.Outputs.Add(Outputs);
                    foreach (var item in XuatKhoList)
                    {
                        int sumInput = 0;
                        int sumOutput = 0;
                        var s = DataProvider.Ins.DB.InputInfoes.Where(x => x.IdObject == item.Object.Id);
                        var t = DataProvider.Ins.DB.OutputInfoes.Where(x => x.IdObject == item.Object.Id);
                        if (s.Count() != 0)
                        {
                            sumInput = (int)s.Sum(e => e.Count);
                        }
                        if (t.Count() != 0)
                        {
                            sumOutput = (int)t.Sum(e => e.Count);
                        }
                        int tonkho = sumInput - sumOutput;
                        if (tonkho >= item.Count)
                        {
                            var OutputInfo = new Model.OutputInfo() { IdObject = item.Object.Id, Count = item.Count, IdCustomer = item.Customer.Id, IdOutput = Outputs.Id, OutputPrice = item.Count * item.Object.Price, Status = item.Status, Id = item.Id };
                            DataProvider.Ins.DB.OutputInfoes.Add(OutputInfo);
                            dem++;
                        }
                        else
                        {
                            MessageBox.Show("Số lượng xuất " + item.Object.DisplayName + " nhiều hơn số lượng còn trong kho!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    if (dem != 0)
                    {
                        DataProvider.Ins.DB.SaveChanges();
                        XuatKhoList.Clear();
                        Reset();
                        MessageBox.Show("Lưu thành công!");
                    }
                }
            });
            #endregion
            #region Delete
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (MessageBox.Show("Bạn có thật sự muốn tạo lại?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) != MessageBoxResult.OK)
                {
                    return;
                }
                else
                {
                    XuatKhoList.Clear();
                    Reset();
                }
            });
            #endregion
            TKCommand = new RelayCommand<object>((p) => { return true; }, (p) => { TKOutputWindow wd = new TKOutputWindow(); TKOutputViewModel vm = new TKOutputViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
        }
        void Reset()
        {
            DateOutput = DateTime.Now;
            Count = 0;
            SelectedObject = null;
            SelectedCustomer = null;
            Status = null;
        }
    }
}
