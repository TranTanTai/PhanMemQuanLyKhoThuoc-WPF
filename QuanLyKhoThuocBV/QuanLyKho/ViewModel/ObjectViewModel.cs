using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Object> _List;
        public ObservableCollection<Model.Object> List { get {return _List;} set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get { return _Unit; } set { _Unit = value; OnPropertyChanged(); } }

        private ObservableCollection<Suplier> _Suplier;
        public ObservableCollection<Suplier> Suplier { get { return _Suplier; } set { _Suplier = value; OnPropertyChanged(); } }

        private Model.Object _SelectedItem;
        public Model.Object SelectedItem
        {
            get {return _SelectedItem;}
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    QRCode = SelectedItem.QRCode;
                    BarCode = SelectedItem.BarCode;
                    SelectedUnit = SelectedItem.Unit;
                    SelectedSuplier = SelectedItem.Suplier;
                    Price = SelectedItem.Price;
                }
            }
        }

        private Unit _SelectedUnit;
        public Unit SelectedUnit
        {
            get {return _SelectedUnit;}
            set
            {
                _SelectedUnit = value;
                OnPropertyChanged(); 
            }
        }

        private Suplier _SelectedSuplier;
        public Suplier SelectedSuplier
        {
            get {return _SelectedSuplier;}
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
            }
        }

        private string _DisplayName;
        public string DisplayName { get {return _DisplayName;} set { _DisplayName = value; OnPropertyChanged(); } }

        private Nullable<double> _Price;
        public Nullable<double> Price { get { return _Price; } set { _Price = value; OnPropertyChanged(); } }

        private string _QRCode;
        public string QRCode { get {return _QRCode;} set { _QRCode = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get { return _BarCode; } set { _BarCode = value; OnPropertyChanged(); } }

        private int _IdUnit;
        public int IdUnit { get { return _IdUnit; } set { _IdUnit = value; OnPropertyChanged(); } }

        private int _IdSuplier;
        public int IdSuplier { get { return _IdSuplier; } set { _IdSuplier = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SortIdCommand { get; set; }
        public ICommand SortDisplayNameCommand { get; set; }
        public ICommand SortUnitDisplayNameCommand { get; set; }
        public ICommand SortSuplierDisplayNameCommand { get; set; }
        public ICommand SortPriceCommand { get; set; }
        public bool IsSort { get; set; }

        public ObjectViewModel()
        {
            
            List = new ObservableCollection<Model.Object>(DataProvider.Ins.DB.Objects);
            Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            Suplier = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            taikhoan tk = new taikhoan();
            var userinfo = DataProvider.Ins.DB.Users.Where(x => x.UserName == tk.UserName && x.IdRole == 1);
            #region Add
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSuplier == null || SelectedUnit == null || string.IsNullOrWhiteSpace(DisplayName) || Price == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Objects.Where(x => x.DisplayName == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                if (Price <= 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ vui lòng nhập lại!");
                }
                else
                {
                    var Object = new Model.Object() { DisplayName = DisplayName.Trim(), Price = Price, BarCode = BarCode, QRCode = QRCode, IdSuplier = SelectedSuplier.Id, IdUnit = SelectedUnit.Id, Id = Guid.NewGuid().ToString() };

                    DataProvider.Ins.DB.Objects.Add(Object);
                    DataProvider.Ins.DB.SaveChanges();
                    List.Add(Object);
                    Reset();
                }
            });
            #endregion
            #region Delete
            DeleteCommand = new RelayCommand<Window>((p) =>
            {
                if (SelectedItem == null || userinfo.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning) != MessageBoxResult.OK)
                {
                    return;
                }
                else
                {
                    //string idobject = SelectedItem.Id;
                    var inputinfos = DataProvider.Ins.DB.InputInfoes.Where(x => x.IdObject == SelectedItem.Id); //lấy danh sách đơn nhập có sản phẩm đó
                    var outputinfos = DataProvider.Ins.DB.OutputInfoes.Where(x => x.IdObject == SelectedItem.Id);
                    foreach (var i in inputinfos)
                    {
                        string idinput = i.IdInput;
                        var inputinfo = DataProvider.Ins.DB.InputInfoes.Where(x => x.IdInput == i.IdInput); //lấy ra danh sách phiếu nhập
                        if (inputinfo.Count() == 1)
                        {
                            var delinputinfo = DataProvider.Ins.DB.InputInfoes.Where(x => x.Id == i.Id).SingleOrDefault();
                            var delinput = DataProvider.Ins.DB.Inputs.Where(x => x.Id == idinput).SingleOrDefault();
                            DataProvider.Ins.DB.InputInfoes.Remove(delinputinfo);
                            DataProvider.Ins.DB.Inputs.Remove(delinput);
                        }
                        else
                        {
                            var delinputinfo = DataProvider.Ins.DB.InputInfoes.Where(x => x.Id == i.Id).SingleOrDefault();
                            DataProvider.Ins.DB.InputInfoes.Remove(delinputinfo);
                        }
                    }
                    foreach (var o in outputinfos)
                    {
                        string idoutput = o.IdOutput;
                        var outputinfo = DataProvider.Ins.DB.OutputInfoes.Where(x => x.IdOutput == o.IdOutput); //lấy ra danh sách phiếu nhập
                        if (outputinfo.Count() == 1)
                        {
                            var deloutputinfo = DataProvider.Ins.DB.OutputInfoes.Where(x => x.Id == o.Id).SingleOrDefault();
                            var deloutput = DataProvider.Ins.DB.Outputs.Where(x => x.Id == idoutput).SingleOrDefault();
                            DataProvider.Ins.DB.OutputInfoes.Remove(deloutputinfo);
                            DataProvider.Ins.DB.Outputs.Remove(deloutput);
                        }
                        else
                        {
                            var deloutputinfo = DataProvider.Ins.DB.OutputInfoes.Where(x => x.Id == o.Id).SingleOrDefault();
                            DataProvider.Ins.DB.OutputInfoes.Remove(deloutputinfo);
                        }
                    }
                    var delobject = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                    DataProvider.Ins.DB.Objects.Remove(delobject);
                    DataProvider.Ins.DB.SaveChanges();
                    List.Remove(delobject);
                    Reset();
                    MessageBox.Show("Bạn đã xóa thành công");
                }
            });
            #endregion
            #region Edit
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedSuplier == null || SelectedUnit == null || string.IsNullOrWhiteSpace(DisplayName) || Price == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id);
                if (displayList.Count() != 0)
                    return true;
                return false;

            }, (p) =>
            {
                if (Price <= 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ vui lòng nhập lại!");
                }
                else
                {
                    var Object = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                    Object.DisplayName = DisplayName.Trim();
                    Object.BarCode = BarCode;
                    Object.QRCode = QRCode;
                    Object.Price = Price;
                    Object.IdSuplier = SelectedSuplier.Id;
                    Object.IdUnit = SelectedUnit.Id;
                    DataProvider.Ins.DB.SaveChanges();
                    Reset();
                }
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
            SortUnitDisplayNameCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Unit.DisplayName", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Unit.DisplayName", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortSuplierDisplayNameCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Suplier.DisplayName", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Suplier.DisplayName", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortPriceCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            #endregion
        }
        void Reset()
        {
            DisplayName = null;
            BarCode = null;
            QRCode = null;
            Price = null;
            SelectedSuplier = null;
            SelectedUnit = null;
        }
    }
}
