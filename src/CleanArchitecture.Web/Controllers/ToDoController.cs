using System.Collections.Generic;
using CleanArchitecture.Core;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.SharedKernel.Interfaces;
using CleanArchitecture.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Web.Endpoints.ToDoItems;

namespace CleanArchitecture.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ToDoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var entities = await _repository.ListAsync<ToDoItem>();
            var items = _mapper.Map<List<ToDoItemDTO>>(entities);

            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}
