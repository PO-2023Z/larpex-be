using external_payments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace external_payments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        [HttpPost]
        [Route("registerTransaction")]
        public IActionResult Post([FromBody] TransactionDetails transactionDetails)
        {
            if (transactionDetails == null)
            {
                return BadRequest();
            }

            if (transactionDetails.Amount <= 0)
            {
                return BadRequest();
            }


            string json = JsonSerializer.Serialize(new TransactionId()
            {
                Id = new Guid(),
                Amount = transactionDetails.Amount,
                UrlReturn = transactionDetails.UrlReturn,
                UrlRedirect = transactionDetails.UrlRedirect
            }) ;

            // encode result to base64
            byte[] encodedBytes = System.Text.Encoding.UTF8.GetBytes(json);
            string result = System.Convert.ToBase64String(encodedBytes);


            return Ok(result);
        }
    }
}
