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

namespace CleanArchitecture.UseCases.TodoItem.Commands.CompleteToDoItem
{
    public class CompleteToDoItemCommandHandler : IRequestHandler<CompleteToDoItemCommand, ToDoItemDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CompleteToDoItemCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ToDoItemDTO> Handle(CompleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await _repository.GetByIdAsync<ToDoItem>(request.Id);
            toDoItem.MarkComplete();
            await _repository.UpdateAsync(toDoItem);
            var dto = _mapper.Map<ToDoItemDTO>(toDoItem);
            return dto;
        }
    }
}
