using System.Net;
using AutoMapper;
using LuksonExpense.Application.DTOs.MappingDtos;
using LuksonExpense.Application.DTOs.Responses.Modules;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Modules.Queries.List
{
    public sealed class GetModuleListQuery : IRequest<Response<ModuleListResponse>>
    {
    }

    public class GetModuleListQueryHandler(
        IModuleRepository moduleRepository, 
        IMapper mapper) : IRequestHandler<GetModuleListQuery, Response<ModuleListResponse>>
    {
        public async Task<Response<ModuleListResponse>> Handle(GetModuleListQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<ModuleListResponse>();

            try
            {
                IEnumerable<Module> modules = await moduleRepository.List();

                response.StatusCode = HttpStatusCode.OK;
                response.Content = new ModuleListResponse
                {
                    TotalRegisters = modules.Count(),
                    Modules = mapper.Map<IEnumerable<ModuleDTO>>(modules)
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
