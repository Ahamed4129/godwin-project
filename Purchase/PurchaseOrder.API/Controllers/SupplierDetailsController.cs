using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Application.MediatR.SupplierMaster.SupplierMasterCommand;
using PurchaseOrder.Application.MediatR.SupplierMaster.SupplierMasterQuery;
using PurchaseOrder.Domain;


namespace PurchaseOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierDetailsController : ControllerBase
    {
        private readonly ISupplierRepository _SupplierRepositary;
        private readonly IMediator _mediator;
        public IMediator Mediator { get; }

        public SupplierDetailsController(ISupplierRepository SupplierRepositary, IMediator mediator)
        {
            _SupplierRepositary = SupplierRepositary;
            _mediator = mediator;
        }
        [HttpGet]
        public ActionResult<List<SupplierDetails>> GetAllSupplierDetails()
        {
            var Supplier = _mediator.Send(new SupplierMasterGetQuery());
            return Ok(Supplier);
        }
        [HttpPost]
        public ActionResult<SupplierDetails> PostSupplierDetails(SupplierDetails supplier)
        {
            var Supplier = _mediator.Send(new SupplierMasterAddCommand(supplier));
            return Ok(Supplier);
        }
        [HttpDelete("SupplierID")]
        public ActionResult DeletePOMaster(int SupplierID)
        {
            var Supplier = _mediator.Send(new SupplierMasterDeleteCommand(SupplierID));
            return Ok(Supplier);

        }
        [HttpGet("SupplierID")]
        public ActionResult<List<SupplierDetails>> GetSupplierDetailsSupplierID(int SupplierID)
        {
            var Supplier = _mediator.Send(new SupplierMasterGetByIDQuery(SupplierID));
            return Ok(Supplier);

        }
        [HttpPut]
        public ActionResult<SupplierDetails> UpdatePOMaster(SupplierDetails supplier)
        {
            var Supplier = _mediator.Send(new SupplierMasterUpdateCommand(supplier));
            return Ok(Supplier);
        }
    }
}
