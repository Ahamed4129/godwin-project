using MediatR;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Application.MediatR.LoginMaster.LoginMasterQuery;
using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastucture.Handler.LoginMasterHandler
{
    public class LoginMasterGetAllHandler : IRequestHandler<LoginMasterGetAllQuery, List<LoginDetails>>
    {
        private readonly ILoginRepositary _loginRepositary;
        public LoginMasterGetAllHandler(ILoginRepositary loginRepositary)
        {
            _loginRepositary = loginRepositary;

        }

        public async Task<List<LoginDetails>> Handle(LoginMasterGetAllQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_loginRepositary.GetAllLoginDetails());
        }
    }
}
