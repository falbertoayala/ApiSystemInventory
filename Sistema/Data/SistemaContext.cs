﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema.Models;

namespace Sistema.Models
{
    //public class SistemaContext : DbContext
    public class SistemaContext : IdentityDbContext<ApplicationUser>
    {
        public SistemaContext (DbContextOptions<SistemaContext> options)
            : base(options)
        {
        }

        //public DbSet<Sistema.Models.Medico> Medico { get; set; }

        public DbSet<Sistema.Models.Users> Users { get; set; }

        public DbSet<Sistema.Models.Providers> Providers { get; set; }

        public DbSet<Sistema.Models.TypeProduct> TypeProduct { get; set; }

        public DbSet<Sistema.Models.Storage> Storage { get; set; }

        public DbSet<Sistema.Models.ProductBrand> ProductBrand { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

        public DbSet<Sistema.Models.Product> Product { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

        public DbSet<Sistema.Models.Requisition> Requisition { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

        public DbSet<Sistema.Models.RequisitionDetail> RequisitionDetail { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

        public DbSet<Sistema.Models.Purchase> Purchase { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

        public DbSet<Sistema.Models.PurchaseDetail> PruchaseDetail { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

        public DbSet<Sistema.Models.RequisitionStatus> RequisitionStatus { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

        public DbSet<Sistema.Models.City> City { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

        //public DbSet<Sistema.Models.City> City { get; set; }

        //public DbSet<Sistema.Models.Product> Product { get; set; }

       // public DbSet<Sistema.Models.Ciudad> Ciudad { get; set; }

        //public DbSet<Sistema.Models.Users> UserInfo { get; internal set; }
    }
}
