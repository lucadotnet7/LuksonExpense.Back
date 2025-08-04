using AutoMapper;
using LuksonExpense.Application.DTOs.MappingDtos;
using LuksonExpense.Application.DTOs.Requests.Modules;
using LuksonExpense.Domain.Models;

namespace LuksonExpense.Application.DTOs.Profiles
{
    public sealed class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<Module, ModuleDTO>();
            CreateMap<AddModuleRequest, Module>();
        }
    }
}
