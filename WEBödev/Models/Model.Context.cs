﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBödev.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TıbbiTakipSistemEntities : DbContext
    {
        public TıbbiTakipSistemEntities()
            : base("name=TıbbiTakipSistemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Hastalık> Hastalık { get; set; }
        public virtual DbSet<İlaç> İlaç { get; set; }
        public virtual DbSet<Kullanıcı> Kullanıcı { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tahlil> Tahlil { get; set; }
    }
}
