using AutoMapper;
using LuksonExpense.Application.DTOs.Modules;
using LuksonExpense.Application.DTOs.Requests;
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
