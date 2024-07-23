using Invoice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Invoice.Core.Interfaces
{
    public interface IUnitOfWork
    {

        
        IGenericRepository<InvoiceDetails> InvoiceDetails { get; }

        IGenericRepository<Unit> Units { get; }

        int Complete();
    }
}
