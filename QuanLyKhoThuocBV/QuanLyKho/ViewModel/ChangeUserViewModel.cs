using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    class ChangeUserViewModel: BaseViewModel
    {
        private string _Displayname;
        public string Displayname { get { return _Displayname; } set { _Displayname = value; OnPropertyChanged(); } }
        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get { return _Password; } set { _Password = value; OnPropertyChanged(); } }
        private string _PasswordNew;
        public string PasswordNew { get { return _PasswordNew; } set { _PasswordNew = value; OnPropertyChanged(); } }
        private string _PasswordNew2;
        public string PasswordNew2 { get { return _PasswordNew2; } set { _PasswordNew2 = value; OnPropertyChanged(); } }
        public ICommand SaveCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand PasswordChangedNewCommand { get; set; }
        public ICommand PasswordChangedNew2Command { get; set; }
        public ChangeUserViewModel()
        {
            taikhoan tk = new taikhoan();
            var userinfo = DataProvider.Ins.DB.Users.Where(x => x.UserName == tk.UserName).SingleOrDefault();
            UserName = tk.UserName;
            Displayname = userinfo.DisplayName;
            Password = "";
            PasswordNew = "";
            PasswordNew2 = "";
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            PasswordChangedNewCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { PasswordNew = p.Password; });
            PasswordChangedNew2Command = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { PasswordNew2 = p.Password; });
            #region Save
            SaveCommand = new RelayCommand<object>((p) => 
            {
                return true; 
            }, (p) => 
            {
                string passwordEncode = MD5Hash(Base64Encode(Password));
                string passwordnewEncode = MD5Hash(Base64Encode(PasswordNew));
                if (userinfo.Password != passwordEncode)
                {
                    MessageBox.Show("Sai mật khẩu!!!");
                }
                else
                {
                    if (PasswordNew != PasswordNew2)
                        MessageBox.Show("Mật khẩu không khớp!!!");
                    else
                    {
                        userinfo.Password = passwordnewEncode;
                        MessageBox.Show("Cập nhật thành công!");
                    }
                }
                userinfo.DisplayName = Displayname;
                DataProvider.Ins.DB.SaveChanges();
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
    }
}
