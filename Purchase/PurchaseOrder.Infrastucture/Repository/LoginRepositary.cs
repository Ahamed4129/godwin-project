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
    public class LoginRepositary : ILoginRepositary
    {
        private readonly PurchaseOrderDbContext _purchaseOrderDbContext;

        public LoginRepositary(PurchaseOrderDbContext purchaseOrderDbContext)
        {
            _purchaseOrderDbContext = purchaseOrderDbContext;
        }
        public LoginDetails AddLoginDetails(LoginDetails Login)
        {
            _purchaseOrderDbContext.LoginDetails.Add(Login);
            _purchaseOrderDbContext.SaveChanges();

            return Login;
        }

        public LoginDetails DeleteLoginDetails(int LoginID)
        {
            var login = _purchaseOrderDbContext.LoginDetails.FirstOrDefault(x => x.LoginID == LoginID);
            _purchaseOrderDbContext.Remove(login);
            _purchaseOrderDbContext.SaveChanges();
            return login;
        }

        public List<LoginDetails> GetAllLoginDetails()
        {
            var login = _purchaseOrderDbContext.LoginDetails.ToList();
            return login;
        }
    }
}
