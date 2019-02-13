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
    class InputViewModel : BaseViewModel
    {
        private ObservableCollection<NhapKho> _NhapKhoList;
        public ObservableCollection<NhapKho> NhapKhoList { get { return _NhapKhoList; } set { _NhapKhoList = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.Input> _Input;
        public ObservableCollection<Model.Input> Input { get { return _Input; } set { _Input = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.Object> _Object;
        public ObservableCollection<Model.Object> Object { get { return _Object; } set { _Object = value; OnPropertyChanged(); } }

        private Model.NhapKho _SelectedItem;
        public Model.NhapKho SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Count = SelectedItem.Count;
                    InputPrice = SelectedItem.InputPrice;
                    Status = SelectedItem.Status;
                    SelectedInput = SelectedItem.Input;
                    SelectedObject = SelectedItem.Object;
                }
            }
        }
        private Model.Input _SelectedInput;
        public Model.Input SelectedInput
        {
            get { return _SelectedInput; }
            set
            {
                _SelectedInput = value;
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

        private Nullable<double> _InputPrice;
        public Nullable<double> InputPrice { get { return _InputPrice; } set { _InputPrice = value; OnPropertyChanged(); } }
        private Nullable<int> _Count;
        public Nullable<int> Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }
        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get { return _IdObject; } set { _IdObject = value; OnPropertyChanged(); } }
        private string _IdInput;
        public string IdInput { get { return _IdInput; } set { _IdInput = value; OnPropertyChanged(); } }
        private DateTime? _DateInput;
        public DateTime? DateInput { get { return _DateInput; } set { _DateInput = value; OnPropertyChanged(); } }
        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand TKCommand { get; set; }
        public bool IsSort { get; set; }
        public InputViewModel()
        {
            NhapKhoList = new ObservableCollection<NhapKho>();
            Input = new ObservableCollection<Model.Input>(DataProvider.Ins.DB.Inputs);
            Object = new ObservableCollection<Model.Object>(DataProvider.Ins.DB.Objects);
            _DateInput = DateTime.Now;
            _Count = 0;
            _InputPrice = 0;
            #region Add
            AddCommand = new RelayCommand<object>((p) =>
            {
                foreach (var i in NhapKhoList)
                {
                    if (i.Object.Id == SelectedObject.Id)
                    {
                        return false;
                    }
                }
                if (SelectedObject == null || DateInput == null || Count < 0 || InputPrice < 0)
                    return false;
                return true;
            }, (p) =>
            {
                var inputInfo = new Model.NhapKho() { Object = SelectedObject, Count = Count, InputPrice = InputPrice, Status = Status, Id = Guid.NewGuid().ToString() };
                NhapKhoList.Add(inputInfo);
                
            });
            #endregion
            #region Lưu
            SaveCommand = new RelayCommand<object>((p) =>
            {
                foreach(var i in NhapKhoList)
                {
                    if (i.Count <= 0 || i.InputPrice <= 0)
                    {
                        return false;
                    }
                }
                if (NhapKhoList.Count() == 0)
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
                    var Inputs = new Model.Input() { Id = Guid.NewGuid().ToString(), DateInput = DateInput };
                    DataProvider.Ins.DB.Inputs.Add(Inputs);
                    foreach (var item in NhapKhoList)
                    {
                        var InputInfo = new Model.InputInfo() { IdObject = item.Object.Id, Count = item.Count, IdInput = Inputs.Id, InputPrice = item.InputPrice, Status = item.Status, Id = item.Id };
                        DataProvider.Ins.DB.InputInfoes.Add(InputInfo);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    MessageBox.Show("Lưu thành công!");
                    NhapKhoList.Clear();
                    Reset();
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
                    NhapKhoList.Clear();
                    Reset();
                }
            });
            #endregion
            TKCommand = new RelayCommand<object>((p) => { return true; }, (p) => { TKInputWindow wd = new TKInputWindow(); TKInputViewModel vm = new TKInputViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
        }
        void Reset()
        {
            SelectedObject = null;
            DateInput = DateTime.Now;
            Count = 0;
            InputPrice = 0;
            Status = null;
        }
    }
}
