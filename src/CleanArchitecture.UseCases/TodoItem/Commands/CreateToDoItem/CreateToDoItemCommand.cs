using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.TodoItem.Commands.CreateToDoItem
{
    public class CreateToDoItemCommand : IRequest<ToDoItemDTO>
    {
        public ToDoItemDTO Dto { get; set; }
    }
}
