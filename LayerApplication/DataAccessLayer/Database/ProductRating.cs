//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerEmail { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}