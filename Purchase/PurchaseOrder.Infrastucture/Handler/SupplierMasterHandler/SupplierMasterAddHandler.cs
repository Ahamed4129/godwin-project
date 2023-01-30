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
    public class SupplierMasterAddHandler : IRequestHandler<SupplierMasterAddCommand, SupplierDetails>
    {
        private readonly ISupplierRepository _SupplierRepository;

        public IMediator Mediator { get; }

        public SupplierMasterAddHandler(ISupplierRepository supplierRepository, IMediator mediator)
        {
            _SupplierRepository = supplierRepository;
            Mediator = mediator;
        }
        public async Task<SupplierDetails> Handle(SupplierMasterAddCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_SupplierRepository.AddSupplierDetails(request.SUP));
        }
    }
}
