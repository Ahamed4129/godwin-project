using MediatR;
using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Application.MediatR.LoginMaster.LoginMasterCommand
{
    public record LoginMasterDeleteCommand(int LoginID) : IRequest<LoginDetails>;
    
}
