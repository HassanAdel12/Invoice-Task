using Invoice.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }


        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

    }
}
