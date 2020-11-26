using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.ApiModels;

namespace CleanArchitecture.UseCases.TodoItem.Utils
{
    public class ToDoItemMappingProfile : Profile
    {
        public ToDoItemMappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemDTO>().ReverseMap();
        }
    }
}
