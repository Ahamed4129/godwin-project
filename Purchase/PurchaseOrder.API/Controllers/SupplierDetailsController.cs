
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
      
        

        public SupplierDetailsController(ISupplierRepository SupplierRepositary )
        {
            _SupplierRepositary = SupplierRepositary;
          
        }
        [HttpGet]
        public ActionResult<List<SupplierDetails>> GetAllSupplierDetails()
        {
            var Supplier = _SupplierRepositary.GetAllSupplierDetails();
            return Ok(Supplier);
        }
        [HttpPost]
        public ActionResult<SupplierDetails> PostSupplierDetails(SupplierDetails supplier)
        {
            var Supplier = _SupplierRepositary.AddSupplierDetails(supplier);
            return Ok(Supplier);
        }
        [HttpDelete("SupplierID")]
        public ActionResult DeletePOMaster(int SupplierID)
        {
            var Supplier = _SupplierRepositary.DeleteSupplierDetails(SupplierID);
            return Ok(Supplier);

        }
        [HttpGet("SupplierID")]
        public ActionResult<List<SupplierDetails>> GetSupplierDetailsSupplierID(int SupplierID)
        {
            var Supplier = _SupplierRepositary.GetSupplierDetailsBySupplierID(SupplierID);
            return Ok(Supplier);

        }
        [HttpPut]
        public ActionResult<SupplierDetails> UpdatePOMaster(SupplierDetails supplier)
        {
            var Supplier = _SupplierRepositary.UpdateSupplierDetails(supplier);
            return Ok(Supplier);
        }
    }
}
