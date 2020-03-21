using Customer.Api.UseCases.Customers.V1.Create;
using Customer.Application.UseCases.Create;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Customer.Api.UseCases.Customers.V1
{
    public partial class CustomerController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerRequest request)
        {
            var response = await _mediator.Send((CreateCustomerCommand)request);

            return Ok(response);
        }
    }
}
