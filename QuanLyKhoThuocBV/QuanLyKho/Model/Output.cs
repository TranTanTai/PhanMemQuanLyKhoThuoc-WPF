//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyKho.Model
{
    using QuanLyKho.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class Output:BaseViewModel
    {
        public Output()
        {
            this.OutputInfoes = new HashSet<OutputInfo>();
        }
    
        private string _Id;
        public string Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
        private Nullable<System.DateTime> _DateOutput;
        public Nullable<System.DateTime> DateOutput { get { return _DateOutput; } set { _DateOutput = value; OnPropertyChanged(); } }
    
        public virtual ICollection<OutputInfo> OutputInfoes { get; set; }
    }
    
}
