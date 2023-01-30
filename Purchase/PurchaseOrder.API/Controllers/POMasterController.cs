using Microsoft.AspNetCore.Mvc;
using PurchaseOrder.Application.IRepository;
using PurchaseOrder.Domain;


namespace PurchaseOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POMasterController : ControllerBase
    {
        
        private readonly IPOMasterRepository _POMasterRepository;
       

        public POMasterController(IPOMasterRepository POMasterRepository)
        {
            _POMasterRepository = POMasterRepository;
           
        }
        [HttpGet]
        public ActionResult<List<POMaster>> GetAllPOMaster()
        {
            var purchase = _POMasterRepository.GetAllPurchaseMaster();
            return Ok(purchase);
        }
        [HttpPost]
        public ActionResult<POMaster> PostPOMaster(POMaster pOMaster)
        {
            //var POMaster = _pOMasterService.AddPOMaster(pOMaster);
            var purchase = _POMasterRepository.AddPurchaseMaster(pOMaster);
            return Ok(purchase);
        }

        [HttpDelete("{POID}")]
        public ActionResult DeletePOMaster(int POID)
        {
            //var POMaster = _pOMasterService.DeletePOMAster( POID);
            var login = _POMasterRepository.DeletePurchaseMaster(POID);
            return Ok(login);

        }

        [HttpGet("{POID}")]
        public ActionResult<List<POMaster>> GetPOMasterByPOID(int POID)
        {
            //var pomaster = _pOMasterService.GetPOMasterByPOID((int)POID);
          var purchase = _POMasterRepository.GetPurchaseMasterByPOID((int) POID);
            return Ok(purchase);

        }
        [HttpPut]
        public ActionResult<POMaster> UpdatePOMaster(POMaster pOMaster)
        {
            //var POMaster = _pOMasterService.UpdatePOMaster( pOMaster );
            var puchase = _POMasterRepository.UpdatePurchaseMaster(pOMaster);
            return Ok(pOMaster);
        }
    }
}
