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
    public class CartModel
    {
        public List<Cart> Carts { get; set; }
    }

    public partial class Cart
    {
        public int CartID { get; set; }
        public string UsersEmail { get; set; }
        public Nullable<int> ProductsID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ProductsPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductsImage { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
