using Invoice.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.DTO
{
    public class InvoiceDetailsDTO
    {

        public int lineNo { get; set; }

        [MaxLength(100)]
        public string productName { get; set; }

        public int UnitNo { get; set; }

        public decimal price { get; set; }

        public decimal quantity { get; set; }

        public decimal total { get; set; }

        public DateTime expiryDate { get; set; }



    }
}
