using MediatR;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Application.MediatR.PurchaseMaster.PurchaseMasterQuery;
using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture.Handler.POMasterHandler
{
    public class POMasterGetByIDHandler : IRequestHandler<POMasterGetByIDQuery, POMaster>
    {
        private readonly IPOMasterRepository _pOMasterRepository;

        public IMediator Mediator { get; }

        public POMasterGetByIDHandler(IPOMasterRepository pOMasterRepository, IMediator mediator)
        {
            _pOMasterRepository = pOMasterRepository;

        }
        public async Task<POMaster> Handle(POMasterGetByIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_pOMasterRepository.GetPurchaseMasterByPOID(request.POID));
        }
    }
}
