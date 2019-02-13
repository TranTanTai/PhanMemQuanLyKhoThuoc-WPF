using QuanLyKho.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Model
{
    public class TonKho : BaseViewModel
    {
        private Object _Object;
        public Object Object { get { return _Object; } set { _Object = value; OnPropertyChanged(); } }
        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }
    }
}
