using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Application.IRepository;

using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture.Repository
{
    public class POMasterRepository : IPOMasterRepository
    {
        private readonly PurchaseOrderDbContext _purchaseOrderDbContext;

        public POMasterRepository(PurchaseOrderDbContext purchaseOrderDbContext)
        {
            _purchaseOrderDbContext = purchaseOrderDbContext;
        }
        public POMaster AddPurchaseMaster(POMaster purchase)
        {
            _purchaseOrderDbContext.POMaster.Add(purchase);
            _purchaseOrderDbContext.SaveChanges();

            return purchase;
        }

        public POMaster DeletePurchaseMaster(int POID)
        {
            var purchase = _purchaseOrderDbContext.POMaster.FirstOrDefault(x => x.POID == POID);
            _purchaseOrderDbContext.Remove(purchase);
            _purchaseOrderDbContext.SaveChanges();
            return purchase;
        }

        public List<POMaster> GetAllPurchaseMaster()
        {
            var purchase = _purchaseOrderDbContext.POMaster.Include(x => x.ItemMaster).ToList();
            return purchase;
        }

        public POMaster GetPurchaseMasterByPOID(int POID)
        {
            var purchase = _purchaseOrderDbContext.POMaster.Include(x => x.ItemMaster).FirstOrDefault(i => i.POID == POID);
            return purchase;
        }

        public POMaster UpdatePurchaseMaster(POMaster purchase)
        {
            _purchaseOrderDbContext.POMaster.Update(purchase);
            _purchaseOrderDbContext.SaveChanges();
            return purchase;
        }
    }
}
