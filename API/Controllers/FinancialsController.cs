using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Application.Financials;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FinancialsController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<ActionResult<List<Financial>>> List()
        {
            return await _mediator.Send(new FList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Financial>> FDetails(int id)
        {
            return await _mediator.Send(new FDetails.Query{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> FCreate(FCreate.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> FEdit(int id,FEdit.Command command)
        {
            command.Id=id;
            return await _mediator.Send(command);
        }
    }
}