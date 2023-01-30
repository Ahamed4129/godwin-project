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
    public class POMasterAddHandler : IRequestHandler<POMasterAddCommand, POMaster>
    {
        private readonly IPOMasterRepository _pOMasterRepository;

        public IMediator Mediator { get; }

        public POMasterAddHandler(IPOMasterRepository pOMasterRepository, IMediator mediator)
        {
            _pOMasterRepository = pOMasterRepository;
            Mediator = mediator;
        }
        public async Task<POMaster> Handle(POMasterAddCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_pOMasterRepository.AddPurchaseMaster(request.POM));
        }
    }
}
