﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using CricketInsighter.Core.DomainModels;
using CricketInsighter.Data.Identity.Models;

namespace CricketInsighter.Data
{
    public class EfConfig
    {
        public static void ConfigureEf(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Image>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Image>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationIdentityUser>()
                 .Property(e => e.Id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ApplicationIdentityRole>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ApplicationIdentityUserClaim>()
                 .Property(e => e.Id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}