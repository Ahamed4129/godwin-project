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
    public class LoginMasterDeleteHandler : IRequestHandler<LoginMasterDeleteCommand, LoginDetails>
    {
        private readonly ILoginRepositary _loginRepositary;
        public LoginMasterDeleteHandler(ILoginRepositary loginRepositary)
        {
            _loginRepositary = loginRepositary;
            
        }

        

        public async Task<LoginDetails> Handle(LoginMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_loginRepositary.DeleteLoginDetails(request.LoginID));
        }
    }
}
