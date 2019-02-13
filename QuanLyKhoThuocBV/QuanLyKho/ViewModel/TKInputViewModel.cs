using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    class TKInputViewModel : BaseViewModel
    {
        private ObservableCollection<Model.InputInfo> _List;
        public ObservableCollection<Model.InputInfo> List { get { return _List; } set { _List = value; OnPropertyChanged(); } }

        private Model.InputInfo _SelectedItem;
        public Model.InputInfo SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    Count = SelectedItem.Count;
                    InputPrice = SelectedItem.InputPrice;
                    Status = SelectedItem.Status;
                }
            }
        }
        private string _Id;
        public string Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
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

        private DateTime? _StartDate;
        public DateTime? StartDate { get { return _StartDate; } set { _StartDate = value; OnPropertyChanged(); } }
        private DateTime? _EndDate;
        public DateTime? EndDate { get { return _EndDate; } set { _EndDate = value; OnPropertyChanged(); } }
        DateTime today = DateTime.Now;
        DateTime startdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ExportExcelCommand { get; set; }

        public ICommand SortObjectDisplayNameCommand { get; set; }
        public ICommand SortIdCommand { get; set; }
        public ICommand SortDateInputCommand { get; set; }
        public ICommand SortInputPriceCommand { get; set; }
        public ICommand SortCountCommand { get; set; }
        public ICommand SortStatusCommand { get; set; }
        
        public bool IsSort { get; set; }
        public TKInputViewModel()
        {
            taikhoan tk = new taikhoan();
            var userinfo = DataProvider.Ins.DB.Users.Where(x => x.UserName == tk.UserName && x.IdRole == 1);
            List = new ObservableCollection<Model.InputInfo>(DataProvider.Ins.DB.InputInfoes);
            _EndDate = today;
            _StartDate = startdate;
            Grouping();
            #region Search
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                LoadInputInfo();
            });
            #endregion
            #region Delete
            DeleteCommand = new RelayCommand<object>((p) =>
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
                    string idinput = SelectedItem.IdInput;
                    var inputs = DataProvider.Ins.DB.InputInfoes.Where(x => x.IdInput == SelectedItem.IdInput);
                    if (inputs.Count() == 1)
                    {
                        var delete = DataProvider.Ins.DB.InputInfoes.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                        var input = DataProvider.Ins.DB.Inputs.Where(x => x.Id == idinput);
                        DataProvider.Ins.DB.InputInfoes.Remove(delete);
                        DataProvider.Ins.DB.Inputs.Remove(input.SingleOrDefault());
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(delete);
                        MessageBox.Show("Bạn đã xóa thành công");
                    }
                    else
                    {
                        var delete = DataProvider.Ins.DB.InputInfoes.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                        DataProvider.Ins.DB.InputInfoes.Remove(delete);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(delete);
                        MessageBox.Show("Bạn đã xóa thành công");
                    }
                }
            });
            #endregion
            #region Excel
            ExportExcelCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ExportExcel();
            });
            #endregion
            #region Sort
            SortObjectDisplayNameCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
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
            SortDateInputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Input.DateInput", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Input.DateInput", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortCountCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Count", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Count", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortInputPriceCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("InputPrice", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("InputPrice", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortStatusCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Status", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Status", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            #endregion
        }
        void LoadInputInfo()
        {
            List.Clear();
            var input = DataProvider.Ins.DB.Inputs.Where(x => x.DateInput >= StartDate && x.DateInput <= EndDate);
            foreach (var item in input)
            {
                var a = DataProvider.Ins.DB.InputInfoes.Where(x => x.IdInput == item.Id);
                if (a.Count() != 0)
                {
                    foreach(var i in a)
                    {
                        var b = DataProvider.Ins.DB.InputInfoes.Where(x => x.Id == i.Id);
                        if (a.Count() != 0)
                        {
                            List.Add(b.SingleOrDefault());
                        }
                    }
                }
            }
            if (List.Count() != 0)
            {
                Grouping();
            }
        }
        void ExportExcel()
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = "Báo cáo thống kê";

                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add("Sheet 1");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Thống kê";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 13;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {    
                                                "ID",
                                                "Sản phẩm",
                                                "Ngày nhập",
                                                "Số lượng",
                                                "Giá nhập",
                                                "Trạng thái xuất"
                };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = "Thống Kê Đơn Nhập Kho";
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 1, 1, countColHeader].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    //cở chữ
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 20;
                    
                    int colIndex = 1;
                    int rowIndex = 2;
                    
                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];

                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                        border.Top.Style =
                        border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        
                        //gán giá trị
                        cell.Value = item;
                        cell.AutoFitColumns();
                        colIndex++;
                    }
                    ws.Cells[2, 1, 2, countColHeader].AutoFilter = true;
                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    foreach (var item in List)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        //gán giá trị cho từng cell                      
                        ws.Cells[rowIndex, colIndex++].Value = item.Id;
                        ws.Cells[rowIndex, colIndex++].Value = item.Object.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Input.DateInput.Value.ToShortDateString();
                        ws.Cells[rowIndex, colIndex++].Value = item.Count;
                        ws.Cells[rowIndex, colIndex++].Value = item.InputPrice;
                        ws.Cells[rowIndex, colIndex++].Value = item.Status;
                    }
                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                MessageBox.Show("Xuất excel thành công!");
            }
            catch (Exception EE)
            {
                MessageBox.Show("Có lỗi khi lưu file!");
            }
        }
        void Grouping()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Input.Id");
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(groupDescription);
            view.SortDescriptions.Add(new SortDescription("Input.DateInput", ListSortDirection.Descending));
        }
    }
}
