using MediatR;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Application.MediatR.SupplierMaster.SupplierMasterQuery;
using PurchaseOrder.Domain;
using PurchaseOrder.Infrastucture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture.Handler.SupplierMasterHandler
{
    public class SupplierMasterGetAllHandler : IRequestHandler<SupplierMasterGetQuery, List<SupplierDetails>>
    {
        private readonly ISupplierRepository _SupplierRepository;

       

        public SupplierMasterGetAllHandler(ISupplierRepository supplierRepository)
        {
            _SupplierRepository = supplierRepository;
            
        }
        public async Task<List<SupplierDetails>> Handle(SupplierMasterGetQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_SupplierRepository.GetAllSupplierDetails());
        }
    }
}
