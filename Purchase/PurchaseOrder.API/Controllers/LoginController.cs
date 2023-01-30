using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrder.Application.IRepository;

using PurchaseOrder.Domain;

namespace PurchaseOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepositary _iLoginRepositary;

        public LoginController(ILoginRepositary loginRepositary)
        {
            _iLoginRepositary = loginRepositary;
        }
        [HttpGet]
        public ActionResult<List<LoginDetails>> GetAllLoginDetails()
        {
            var login = _iLoginRepositary.GetAllLoginDetails();
            return Ok(login);
        }
        [HttpPost]
        public ActionResult<LoginDetails> PostLoginDetails(LoginDetails Login)
        {
            var login = _iLoginRepositary.AddLoginDetails(Login);
            return Ok(login);
        }
        [HttpDelete(" LoginID ")]
        public ActionResult DeleteLoginDetails(int LoginID)
        {
            var login = _iLoginRepositary.DeleteLoginDetails(LoginID);
            return Ok(login);

        }
    }

}
