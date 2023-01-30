using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Domain
{
    public class ItemMaster
    {
        [Key]
        public int ID { get; set; }
        public int POID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        
    }
}
