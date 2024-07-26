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
    public class CustomerAddressController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponse<List<CustomerAddressResponse>>> Get()
        {
            var operation = new GetAllCustomerAddressesQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{addressId:long}")]
        public async Task<ApiResponse<CustomerAddressResponse>> Get([FromRoute] long addressId)
        {
            var operation = new GetCustomerAddressByIdQuery(addressId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<CustomerAddressResponse>> Post([FromBody] CustomerAddressRequest value)
        {
            var operation = new CreateCustomerAddressCommand(value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{addressId:long}")]
        public async Task<ApiResponse> Put(long addressId, [FromBody] CustomerAddressRequest value)
        {
            var operation = new UpdateCustomerAddressCommand(addressId, value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{addressId:long}")]
        public async Task<ApiResponse> Delete(long addressId)
        {
            var operation = new DeleteCustomerAddressCommand(addressId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}
