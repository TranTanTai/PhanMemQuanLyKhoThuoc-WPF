using QuanLyKho.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Model
{
    public class XuatKho : BaseViewModel
    {
        private string _Id;
        public string Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
        private Nullable<double> _OutputPrice;
        public Nullable<double> OutputPrice { get { return _OutputPrice; } set { _OutputPrice = value; OnPropertyChanged(); } }
        private int _IdCustomer;
        public int IdCustomer { get { return _IdCustomer; } set { _IdCustomer = value; OnPropertyChanged(); } }
        private Nullable<int> _Count;
        public Nullable<int> Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }
        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged(); } }
        private string _IdObject;
        public string IdObject { get { return _IdObject; } set { _IdObject = value; OnPropertyChanged(); } }

        private Customer _Customer;
        public Customer Customer { get { return _Customer; } set { _Customer = value; OnPropertyChanged(); } }
        private Output _Output;
        public Output Output { get { return _Output; } set { _Output = value; OnPropertyChanged(); } }
        private Object _Object;
        public Object Object { get { return _Object; } set { _Object = value; OnPropertyChanged(); } }
    }
}
