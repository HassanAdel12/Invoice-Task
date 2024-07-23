using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Model
{
    public class InvoiceDetails
    {

		[Key]
		public int lineNo { get; set; }

		[MaxLength(100)]
		public string productName { get; set; }

        [ForeignKey("Unit")]
        public int UnitNo { get; set; }

        public virtual Unit Unit { get; set; }

        public decimal price { get; set; }

		public decimal quantity { get; set; }

		public decimal total {  get; set; }

		public DateTime expiryDate { get; set; }






    }
}
