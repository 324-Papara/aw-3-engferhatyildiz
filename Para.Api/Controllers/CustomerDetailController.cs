﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Schema;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponse<List<CustomerDetailResponse>>> Get()
        {
            var operation = new GetAllCustomerDetailsQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{detailId:long}")]
        public async Task<ApiResponse<CustomerDetailResponse>> Get([FromRoute] long detailId)
        {
            var operation = new GetCustomerDetailByIdQuery(detailId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<CustomerDetailResponse>> Post([FromBody] CustomerDetailRequest value)
        {
            var operation = new CreateCustomerDetailCommand(value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{detailId:long}")]
        public async Task<ApiResponse> Put(long detailId, [FromBody] CustomerDetailRequest value)
        {
            var operation = new UpdateCustomerDetailCommand(detailId, value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{detailId:long}")]
        public async Task<ApiResponse> Delete(long detailId)
        {
            var operation = new DeleteCustomerDetailCommand(detailId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}
