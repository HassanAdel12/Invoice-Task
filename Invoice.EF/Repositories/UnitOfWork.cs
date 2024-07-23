using Invoice.Core.Interfaces;
using Invoice.Core.Model;
using Invoice.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Invoice.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext Context;

        public UnitOfWork(AppDbContext _Context)
        {
            Context = _Context;

            InvoiceDetails = new GenericRepository<InvoiceDetails>(Context);

            Units = new GenericRepository<Unit>(Context);

            


        }

        public IGenericRepository<InvoiceDetails> InvoiceDetails { get; private set; }

        public IGenericRepository<Unit> Units { get; private set; }


        public int Complete()
        {
            return Context.SaveChanges();
        }

    }
}
