﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommunityPlantsWebAppASpMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PflanzEntities : DbContext
    {
        public PflanzEntities()
            : base("name=PflanzEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kauf> Kaufs { get; set; }
        public virtual DbSet<Pflanzen> Pflanzens { get; set; }
        public virtual DbSet<Schaedling> Schaedlings { get; set; }
        public virtual DbSet<Standort> Standorts { get; set; }
        public virtual DbSet<Steckbrief> Steckbriefs { get; set; }
        public virtual DbSet<Topf> Topfs { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}