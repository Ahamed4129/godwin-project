using MediatR;
using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Application.MediatR.SupplierMaster.SupplierMasterQuery
{
    public record SupplierMasterGetQuery() : IRequest<List<SupplierDetails>>;
}
