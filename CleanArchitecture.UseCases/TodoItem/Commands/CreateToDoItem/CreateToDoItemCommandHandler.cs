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

namespace CleanArchitecture.UseCases.TodoItem.Commands.CreateToDoItem
{
    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, ToDoItemDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateToDoItemCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ToDoItemDTO> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = _mapper.Map<ToDoItem>(request.Dto);
            await _repository.AddAsync(todoItem);
            var dto = _mapper.Map<ToDoItemDTO>(todoItem);
            return dto;
        }
    }
}
