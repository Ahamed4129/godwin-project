using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Application.IRepository
{
    public interface IPOMasterRepository
    {
        List<POMaster> GetAllPurchaseMaster();

        POMaster AddPurchaseMaster(POMaster purchase);

        POMaster DeletePurchaseMaster(int POID);
        POMaster GetPurchaseMasterByPOID( int POID);

        POMaster UpdatePurchaseMaster(POMaster purchase);

    }
}
