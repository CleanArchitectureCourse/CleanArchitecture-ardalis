using CleanArchitecture.Core.Entities;
using CleanArchitecture.SharedKernel.Interfaces;
using CleanArchitecture.Web.ApiModels;
using CleanArchitecture.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.UseCases.TodoItem.Commands.CompleteToDoItem;
using CleanArchitecture.UseCases.TodoItem.Commands.CreateToDoItem;
using CleanArchitecture.UseCases.TodoItem.Queries.GetToDoItemById;
using CleanArchitecture.UseCases.TodoItem.Queries.GetTodoItemsList;
using MediatR;

namespace CleanArchitecture.Web.Api
{
    public class ToDoItemsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ToDoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = await _mediator.Send(new GetToDoItemsListQuery());
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _mediator.Send(new GetToDoItemByIdQuery {Id = id});
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItemDTO item)
        {
            var dto = await _mediator.Send(new CreateToDoItemCommand {Dto = item});
            return Ok(dto);
        }

        [HttpPatch("{id:int}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var dto = await _mediator.Send(new CompleteToDoItemCommand {Id = id});

            return Ok(dto);
        }
    }
}
