using MediatR;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Application.MediatR.LoginMaster.LoginMasterCommand;
using PurchaseOrder.Domain;
using PurchaseOrder.Infrastucture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture.Handler.LoginMasterHandler
{
    public class LoginMasterAddHandler : IRequestHandler<LoginMasterAddCommand, LoginDetails>
    {
        private readonly ILoginRepositary _loginRepositary;
        public LoginMasterAddHandler(ILoginRepositary loginRepositary, IMediator mediator)
        {
            _loginRepositary = loginRepositary;
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

       
            public async Task<LoginDetails> Handle(LoginMasterAddCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_loginRepositary.AddLoginDetails(request.LOG));
        }
    }
}
