using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    class UserViewModel : BaseViewModel
    {
        private ObservableCollection<Model.User> _List;
        public ObservableCollection<Model.User> List { get { return _List; } set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.UserRole> _Role;
        public ObservableCollection<Model.UserRole> Role { get { return _Role; } set { _Role = value; OnPropertyChanged(); } }

        private Model.User _SelectedItem;
        public Model.User SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    UserName = SelectedItem.UserName;
                    DisplayName = SelectedItem.DisplayName;
                    SelectedRole = SelectedItem.UserRole;
                }
            }
        }
        private Model.UserRole _SelectedRole;
        public Model.UserRole SelectedRole
        {
            get { return _SelectedRole; }
            set
            {
                _SelectedRole = value;
                OnPropertyChanged();
            }
        }
        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }
        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }
        private int _IdRole;
        public int IdRole { get{ return _IdRole;} set{ _IdRole = value; OnPropertyChanged();} }

        public ICommand AddCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public UserViewModel()
        {
            taikhoan tk = new taikhoan();
            var userinfo = DataProvider.Ins.DB.Users.Where(x => x.UserName == tk.UserName && x.IdRole == 1);
            List = new ObservableCollection<Model.User>(DataProvider.Ins.DB.Users);
            Role = new ObservableCollection<Model.UserRole>(DataProvider.Ins.DB.UserRoles);
            #region Add
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedRole == null || string.IsNullOrWhiteSpace(UserName) || userinfo.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                var username = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName);
                if (username.Count() == 0)
                {
                    string pass = MD5Hash(Base64Encode("1"));
                    var User = new Model.User() { DisplayName = DisplayName, IdRole = SelectedRole.Id, UserName = UserName.Trim(), Password = pass };
                    DataProvider.Ins.DB.Users.Add(User);
                    DataProvider.Ins.DB.SaveChanges();
                    List.Add(User);
                    Reset();
                }
                else
                    MessageBox.Show("Trùng tên đăng nhập vui lòng nhập lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            });
            #endregion
            ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ChangeUserWindow wd = new ChangeUserWindow(); ChangeUserViewModel vm = new ChangeUserViewModel(); wd.DataContext = vm; wd.ShowDialog(); });
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
                    if (UserName == tk.UserName)
                    {
                        MessageBox.Show("Vui lòng không xóa chính bạn");
                    }
                    else
                    {
                        var userInfo = DataProvider.Ins.DB.Users.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                        DataProvider.Ins.DB.Users.Remove(userInfo);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(userInfo);
                        Reset();
                    }
                }
            });
            #endregion
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        void Reset()
        {
            DisplayName = null;
            UserName = null;
            SelectedRole = null;
        }
    }
}
