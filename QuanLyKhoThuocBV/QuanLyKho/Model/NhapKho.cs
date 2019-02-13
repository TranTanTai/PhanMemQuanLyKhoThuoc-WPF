using QuanLyKho.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Model
{
    public class NhapKho: BaseViewModel
    {
        private string _Id;
        public string Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get { return _IdObject; } set { _IdObject = value; OnPropertyChanged(); } }
        private Nullable<int> _Count;
        public Nullable<int> Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }
        private Nullable<double> _InputPrice;
        public Nullable<double> InputPrice { get { return _InputPrice; } set { _InputPrice = value; OnPropertyChanged(); } }
        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged(); } }

        private Input _Input;
        public Input Input { get { return _Input; } set { _Input = value; OnPropertyChanged(); } }
        private Object _Object;
        public Object Object { get { return _Object; } set { _Object = value; OnPropertyChanged(); } }
    }
}
