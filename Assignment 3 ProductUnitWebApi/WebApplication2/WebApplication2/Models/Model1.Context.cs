//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProductDetails1Entities : DbContext
    {
        public ProductDetails1Entities()
            : base("name=ProductDetails1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CategoryTB> CategoryTBs { get; set; }
        public DbSet<ProductTB> ProductTBs { get; set; }
        public DbSet<UnitTB> UnitTBs { get; set; }
    }
}
