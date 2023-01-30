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
    public class SupplierMasterUpdateHandler : IRequestHandler<SupplierMasterUpdateCommand, SupplierDetails>
    {
        private readonly ISupplierRepository _SupplierRepository;

        

        public SupplierMasterUpdateHandler(ISupplierRepository supplierRepository)
        {
            _SupplierRepository = supplierRepository;
           
        }
        public async Task<SupplierDetails> Handle(SupplierMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_SupplierRepository.UpdateSupplierDetails(request.SUP));
        }
    }
}
