using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PaymentGateway.Controllers
{
    [Route("payments")]
    public class PaymentsController : Controller
    {
        [HttpPost, Authorize]
        public async Task<IActionResult> MakePayment()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            return Accepted();
        }
    }
}
