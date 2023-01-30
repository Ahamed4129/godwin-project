using MediatR;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Application.MediatR.PurchaseMaster.PurchaseMasterCommand;
using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture.Handler.POMasterHandler
{
    public class POMasterDeleteHandler : IRequestHandler<POMasterDeleteCommand, POMaster>
    {
        private readonly IPOMasterRepository _pOMasterRepository;

        public IMediator Mediator { get; }

        public POMasterDeleteHandler(IPOMasterRepository pOMasterRepository, IMediator mediator)
        {
            _pOMasterRepository = pOMasterRepository;
           
        }
        public async Task<POMaster> Handle(POMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_pOMasterRepository.DeletePurchaseMaster(request.POID));
        }
    }
}
