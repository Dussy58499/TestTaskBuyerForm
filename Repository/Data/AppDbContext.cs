using Microsoft.EntityFrameworkCore;
using Repository.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BuyerForm> BuyerForms { get; set; }
    }
}
