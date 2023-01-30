using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Application.IRepository
{
    public interface ISupplierRepository
    {
        List<SupplierDetails> GetAllSupplierDetails();

        SupplierDetails AddSupplierDetails(SupplierDetails supplier);

        SupplierDetails DeleteSupplierDetails(int SupplierID);
        SupplierDetails GetSupplierDetailsBySupplierID(int SupplierID);

        SupplierDetails UpdateSupplierDetails(SupplierDetails supplier);
       
    }
}
