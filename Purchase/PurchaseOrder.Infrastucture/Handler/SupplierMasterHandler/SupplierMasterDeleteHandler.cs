using MediatR;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Application.MediatR.SupplierMaster.SupplierMasterCommand;
using PurchaseOrder.Domain;
using PurchaseOrder.Infrastucture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture.Handler.SupplierMasterHandler
{
    public class SupplierMasterDeleteHandler : IRequestHandler<SupplierMasterDeleteCommand, SupplierDetails>
    {
        private readonly ISupplierRepository _SupplierRepository;

        

        public SupplierMasterDeleteHandler(ISupplierRepository supplierRepository)
        {
            _SupplierRepository = supplierRepository;
            
        }
        public async Task<SupplierDetails> Handle(SupplierMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_SupplierRepository.DeleteSupplierDetails(request.SupplierID));
        }
    }
}
