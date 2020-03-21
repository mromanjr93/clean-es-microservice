using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Commands;

namespace Customer.Api.UseCases.Customers.V1
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("v{version:apiVersion}/customers")]
    [ApiController]
    public partial class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("health")]
        public IActionResult Health()
        {
            return Ok("Running");
        }
    }
}