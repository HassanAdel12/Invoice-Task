using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Model
{
    public class Unit
    {
       

        [Key]
        public int unitNo {  get; set; }
        
        [MaxLength(100)]
        public string unitName { get; set; }

        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
