﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maternity.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MaternityEntities : DbContext
    {
        public MaternityEntities()
            : base("name=MaternityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Baby> Baby { get; set; }
        public virtual DbSet<Baby_Doctor> Baby_Doctor { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Mother> Mother { get; set; }
    }
}