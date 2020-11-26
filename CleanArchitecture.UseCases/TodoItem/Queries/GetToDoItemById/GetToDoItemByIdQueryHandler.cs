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

namespace CleanArchitecture.UseCases.TodoItem.Queries.GetToDoItemById
{
    public class GetToDoItemByIdQueryHandler : IRequestHandler<GetToDoItemByIdQuery, ToDoItemDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetToDoItemByIdQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ToDoItemDTO> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync<ToDoItem>(request.Id);
            var dto = _mapper.Map<ToDoItemDTO>(entity);
            return dto;
        }
    }
}
