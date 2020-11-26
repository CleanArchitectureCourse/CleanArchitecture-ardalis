using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.TodoItem.Commands.CompleteToDoItem
{
    public class CompleteToDoItemCommand : IRequest<ToDoItemDTO>
    {
        public int Id { get; set; }
    }
}
