using FiledTest.Dtos;
using FiledTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FiledTest.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly ICheapPaymentGateway _cheapAccountRepository;
        private readonly IExpensivePaymentGateway _premiumAccountRepository;

        public AccountController(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway)
        {
            _cheapAccountRepository = cheapPaymentGateway;
            _premiumAccountRepository = expensivePaymentGateway;
        }
        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentDto paymentModel)
        {
            if (ModelState.IsValid)
            {
                // < #20
                if(paymentModel.Amount < 20)
                {
                    var result = await _cheapAccountRepository.ProcessCheapPaymentAsync(paymentModel);
                    if (!result) return StatusCode(StatusCodes.Status500InternalServerError);
                    return Ok();
                }
                // between #21 and #500
                else if(paymentModel.Amount > 20 && paymentModel.Amount < 501)
                {
                    var result = await _premiumAccountRepository.ProcessPremiumPaymentAsync(paymentModel);
                    if (!result)
                    {
                        if(!await _cheapAccountRepository.ProcessCheapPaymentAsync(paymentModel)) 
                            return StatusCode(StatusCodes.Status500InternalServerError);
                        return Ok();
                    }
                    return Ok();
                }
                // > #500
                else
                {
                    var result = await _premiumAccountRepository.ProcessPremiumPaymentAsync(paymentModel);
                    if (!result)
                    {
                        var i = 0;
                        while(result == false && i < 3)
                        {
                            if (!await _premiumAccountRepository.ProcessPremiumPaymentAsync(paymentModel))
                                return StatusCode(StatusCodes.Status500InternalServerError);
                            return Ok();
                        }
                    }
                    return Ok();
                }
                
            }
            return BadRequest();
        }
    }
}
