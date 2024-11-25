using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidPay.API.Services.DTOs;
using RapidPay.API.Services.Services;
using System.Security.Claims;

namespace RapidPay.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentService paymentService) : ControllerBase
    {
        readonly IPaymentService _paymentService = paymentService;

        [HttpPost]
        public async Task<ActionResult<TransactionDTO>> AddPayment([FromBody] PaymentDTO payment)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _paymentService.AddPayment(payment,userId);

            return Ok(result);
        }
    }
}
