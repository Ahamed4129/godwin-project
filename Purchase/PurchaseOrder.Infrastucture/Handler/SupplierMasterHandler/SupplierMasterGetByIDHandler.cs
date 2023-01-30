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
    public class SupplierMasterGetByIDHandler : IRequestHandler<SupplierMasterGetByIDQuery, SupplierDetails>
    {

        private readonly ISupplierRepository _SupplierRepository;

        

        public SupplierMasterGetByIDHandler(ISupplierRepository supplierRepository)
        {
            _SupplierRepository = supplierRepository;
            
        }

        public async Task<SupplierDetails> Handle(SupplierMasterGetByIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_SupplierRepository.GetSupplierDetailsBySupplierID(request.SupplierID));
        }
    }
}
