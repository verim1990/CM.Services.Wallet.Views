using CM.Services.Wallet.Views.Contract.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Views.API.Controllers
{
    [Authorize]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("all")]
        public async Task<IActionResult> GetUserList([FromBody] GetUserListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            return Ok(await _mediator.Send(new GetUserQuery()
            {
                Id = id
            }));
        }
    }
}