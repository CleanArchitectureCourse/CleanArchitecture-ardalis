using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.SharedKernel.Interfaces;
using CleanArchitecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.TodoItem.Queries.GetTodoItemsList
{
    public class GetToDoItemsListQueryHandler : IRequestHandler<GetToDoItemsListQuery, List<ToDoItemDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetToDoItemsListQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ToDoItemDTO>> Handle(GetToDoItemsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.ListAsync<ToDoItem>();
            var dtos = _mapper.Map<List<ToDoItemDTO>>(entities);
            return dtos;
        }
    }
}
