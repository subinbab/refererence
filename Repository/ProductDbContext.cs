﻿using DomainLayer;
using DomainLayer.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<UserRegistration> userRegistrations { get; set; }
    }
    
}
