//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolDb_Evidence
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tblstudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> ClassId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Gender Gender { get; set; }
    }
}