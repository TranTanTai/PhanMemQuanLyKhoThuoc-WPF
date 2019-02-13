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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TonKho> _TonKhoList;
        public ObservableCollection<TonKho> TonKhoList { get { return _TonKhoList; } set { _TonKhoList = value; OnPropertyChanged(); } }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand SortDisplaynameCommand { get; set; }
        public ICommand SortCountCommand { get; set; }
        public ICommand ExportExcelCommand { get; set; }
        public ICommand STTCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand timkiemCommand { get; set; }
        public bool IsSort { get; set; }
        private static string _name;
        public static string name { get { return _name; } set { _name = value; } }
        private static string _text;
        public static string text { get { return _text; } set { _text = value; } }
        public MainViewModel()
        {
            IsSort = false;
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                {
                    p.Show();
                    LoadTonKhoData();
                    name = loginVM.UserNames;
                }
                else
                {
                    p.Close();
                }
            }
              );
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UnitWindow wd = new UnitWindow(); UnitViewModel vm = new UnitViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SuplierWindow wd = new SuplierWindow(); SuplierViewModel vm = new SuplierViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindow wd = new CustomerWindow(); CustomerViewModel vm = new CustomerViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ObjectWindow wd = new ObjectWindow(); ObjectViewModel vm = new ObjectViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindow wd = new UserWindow(); UserViewModel vm = new UserViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { InputWindow wd = new InputWindow(); InputViewModel vm = new InputViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OutputWindow wd = new OutputWindow(); OutputViewModel vm = new OutputViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
            UpdateCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadTonKhoData(); });
            ExportExcelCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ExportExcel(); });
            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { CollectionViewSource.GetDefaultView(TonKhoList).Refresh(); });
            timkiemCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TonKhoList);
                view.Filter = UserFilter;
            });
            #region Sort
            SortDisplaynameCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //lấy ra danh sách tồn kho đang hiển thị
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TonKhoList);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                    view.SortDescriptions.Clear(); //xóa sắp xếp cũ để thực hiện lại việc sắp xếp
                    view.SortDescriptions.Add(new SortDescription("Object.DisplayName", ListSortDirection.Ascending)); // thực hiện việc sắp xếp tăng dần
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Object.DisplayName", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Object.DisplayName", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            SortCountCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TonKhoList);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Count", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Count", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Count", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Count", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            STTCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TonKhoList);
                if (IsSort)
                {
                    //view.SortDescriptions.Remove(new SortDescription("Count", ListSortDirection.Descending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("STT", ListSortDirection.Ascending));
                }
                else
                {
                    //view.SortDescriptions.Remove(new SortDescription("Count", ListSortDirection.Ascending));
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("STT", ListSortDirection.Descending));
                }
                IsSort = !IsSort;
            });
            #endregion
        }
        void LoadTonKhoData()
        {
            TonKhoList = new ObservableCollection<TonKho>();
            var objectList = DataProvider.Ins.DB.Objects;
            int i = 1;
            foreach (var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                var outputList = DataProvider.Ins.DB.OutputInfoes.Where(p => p.IdObject == item.Id);

                int sumInput = 0;
                int sumOutput = 0;

                if (inputList.Count() != 0)
                {
                    sumInput = (int)inputList.Sum(p => p.Count);
                }
                if (outputList.Count() != 0)
                {
                    sumOutput = (int)outputList.Sum(p => p.Count);
                }

                TonKho tonkho = new TonKho() { STT = i, Count = sumInput - sumOutput, Object = item };
                TonKhoList.Add(tonkho);
                i++;
            }
        }
        #region Excel
        void ExportExcel()
        {
            string filePath = "";
            //tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();
            //chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            //Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            //nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    //đặt tiêu đề cho file
                    p.Workbook.Properties.Title = "Báo cáo thống kê";

                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add("Sheet 1");

                    //lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];

                    //đặt tên cho sheet
                    ws.Name = "Thống kê";
                    //fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 13;
                    //font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";

                    //Tạo danh sách các column header
                    string[] arrColumnHeader = {    
                                                "ID",
                                                "Tên sản phẩm",
                                                "Số lượng tồn",
                };

                    //lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    //merge các column lại từ column 1 đến số column header
                    //gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = "Thống Kê Tồn Kho";
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    //in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    //căn giữa
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
                    //với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    foreach (var item in TonKhoList)
                    {
                        //bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        //rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        //gán giá trị cho từng cell                      
                        ws.Cells[rowIndex, colIndex++].Value = item.STT;
                        ws.Cells[rowIndex, colIndex++].Value = item.Object.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Count;
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
        #endregion
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(text))
                return true;
            else
                return ((item as TonKho).Object.DisplayName.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
