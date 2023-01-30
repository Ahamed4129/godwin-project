using MediatR;
using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Application.MediatR.PurchaseMaster.PurchaseMasterQuery
{
    public record POMasterGetByIDQuery(int POID) : IRequest<POMaster>;
   
}
