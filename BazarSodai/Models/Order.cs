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
    public class OrderModel
    {
        public List<Order> os { get; set; }
    }
    public partial class Order
    {
        public int OrderID { get; set; }
        public string UserEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public string OrderDate { get; set; }
    }
}
