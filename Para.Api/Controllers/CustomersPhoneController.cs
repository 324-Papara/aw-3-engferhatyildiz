using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Schema;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPhonesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponse<List<CustomerPhoneResponse>>> Get()
        {
            var operation = new GetAllCustomerPhonesQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{phoneId:long}")]
        public async Task<ApiResponse<CustomerPhoneResponse>> Get([FromRoute] long phoneId)
        {
            var operation = new GetCustomerPhoneByIdQuery(phoneId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<CustomerPhoneResponse>> Post([FromBody] CustomerPhoneRequest value)
        {
            var operation = new CreateCustomerPhoneCommand(value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{phoneId:long}")]
        public async Task<ApiResponse> Put(long phoneId, [FromBody] CustomerPhoneRequest value)
        {
            var operation = new UpdateCustomerPhoneCommand(phoneId, value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{phoneId:long}")]
        public async Task<ApiResponse> Delete(long phoneId)
        {
            var operation = new DeleteCustomerPhoneCommand(phoneId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}
