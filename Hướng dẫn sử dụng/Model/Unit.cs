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

    public partial class Unit : BaseViewModel
    {
        public Unit()
        {
            this.Objects = new HashSet<Object>();
        }
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
