using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.TodoItem.Queries.GetTodoItemsList
{
    public class GetToDoItemsListQuery : IRequest<List<ToDoItemDTO>>
    {
    }
}
