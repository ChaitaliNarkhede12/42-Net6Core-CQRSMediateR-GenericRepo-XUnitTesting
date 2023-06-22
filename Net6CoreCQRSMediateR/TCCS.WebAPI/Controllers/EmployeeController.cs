using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Commands;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Queries;
using TCCS.DataAccess;
using TCCS.DataAccess.Models;

namespace TCCS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(res);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            return Ok(res);
        }

        [HttpGet("GetByExpression")]
        public async Task<IActionResult> GetByExpression(int id)
        {
            var res = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            return Ok(res);
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(EmployeeModel employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            EmployeeModel result = await _mediator.Send(new CreateEmployeeCommand(
                employee.Name,
                employee.EmailId));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EmployeeModel employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            EmployeeModel result = await _mediator.Send(new UpdateEmployeeCommand(
                employee.Id,
                employee.Name,
                employee.EmailId));
            return Ok(result);
        }

        [HttpDelete("RemoveAsync/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            int result = await _mediator.Send(new DeleteEmployeeCommand(){ Id=id});
            return Ok(result);
        }
    }
}
