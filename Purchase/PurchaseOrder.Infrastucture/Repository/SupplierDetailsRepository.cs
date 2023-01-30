using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture.Repository
{
    public class SupplierDetailsRepository : ISupplierRepository
    {
        private readonly PurchaseOrderDbContext _purchaseOrderDbContext;
        public SupplierDetailsRepository(PurchaseOrderDbContext purchaseOrderDbContext)
        {
            _purchaseOrderDbContext = purchaseOrderDbContext;
        }
        public SupplierDetails AddSupplierDetails(SupplierDetails supplier)
        {
            _purchaseOrderDbContext.SupplierDetails.Add(supplier);
            _purchaseOrderDbContext.SaveChanges();

            return supplier;
        }

        public SupplierDetails DeleteSupplierDetails(int SupplierID)
        {
            var Supplier = _purchaseOrderDbContext.SupplierDetails.FirstOrDefault(x => x.SupplierID == SupplierID);
            _purchaseOrderDbContext.Remove(Supplier);
            _purchaseOrderDbContext.SaveChanges();
            return Supplier;
        }

        public List<SupplierDetails> GetAllSupplierDetails()
        {
            var Supplier = _purchaseOrderDbContext.SupplierDetails.ToList();
            return Supplier;
        }

        public SupplierDetails GetSupplierDetailsBySupplierID(int SupplierID)
        {
            var Supplier = _purchaseOrderDbContext.SupplierDetails.FirstOrDefault(i => i.SupplierID == SupplierID);
            return Supplier;
        }

        public SupplierDetails UpdateSupplierDetails(SupplierDetails supplier)
        {
            _purchaseOrderDbContext.SupplierDetails.Update(supplier);
            _purchaseOrderDbContext.SaveChanges();
            return supplier;
        }
    }
}
