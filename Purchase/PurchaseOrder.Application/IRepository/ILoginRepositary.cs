using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Application.IRepository
{
    public interface ILoginRepositary
    {
        List<LoginDetails> GetAllLoginDetails();

        LoginDetails AddLoginDetails(LoginDetails Login);

        LoginDetails DeleteLoginDetails(int LoginID);

    }
}
