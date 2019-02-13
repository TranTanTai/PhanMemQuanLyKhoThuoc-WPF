using QuanLyKho.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Model
{
    public class taikhoan : MainViewModel
    {
        private string _UserName = name;
        public string UserName { get { return _UserName; } set { _UserName = value; } }
    }
}
