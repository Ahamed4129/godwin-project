using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Domain
{
    public class POMaster
    {
        [Key]
        public int POID { get; set; }
        public DateTime Date { get; set; }
        public int SupplierID { get; set; }

        [ForeignKey("POID")]
        public List<ItemMaster> ItemMaster { get; set; }

    }
}
