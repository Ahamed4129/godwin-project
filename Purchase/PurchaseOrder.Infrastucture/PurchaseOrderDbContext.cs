using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture
{
    public class PurchaseOrderDbContext : DbContext
    {
        public PurchaseOrderDbContext(DbContextOptions<PurchaseOrderDbContext> options) : base(options)
        {

        }

        public DbSet<POMaster> POMaster { get; set; }

        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<SupplierDetails> SupplierDetails { get; set; }

        public DbSet<LoginDetails> LoginDetails { get; set; }

    }
}
