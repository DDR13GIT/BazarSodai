//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BazarSodai.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int ReviewID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Comment { get; set; }
    }
}
