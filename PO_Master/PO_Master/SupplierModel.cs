using System.Collections.Generic;

namespace PO_Master
{
    public class SupplierModel
    {
        public int POID { get; set; }   
        public string Date { get; set; }
        public int SupplierID { get; set; }
        public List<ItemDetails> ItemDetails { get; set; }

    }

    public class ItemDetails
    {
        public int ID { get; set; }
        public int POID { get; set; }
        public string ItemID { get; set; }
        public string Quantity { get; set; }    
        public string UnitPrice { get; set; }
        public string Total { get; set; }


    }

}
