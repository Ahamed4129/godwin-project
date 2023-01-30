using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Domain
{
    public class SupplierDetails
    {
        [Key]
        public int SupplierID { get; set; }

        public string SupplierName { get; set; }

        public string MobileNumber { get; set;}

        public string Address { get; set; } 
    }
}
