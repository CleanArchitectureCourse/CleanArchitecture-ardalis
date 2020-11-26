using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.TodoItem.Queries.GetToDoItemById
{
    public class GetToDoItemByIdQuery : IRequest<ToDoItemDTO>
    {
        public int Id { get; set; }
    }
}
