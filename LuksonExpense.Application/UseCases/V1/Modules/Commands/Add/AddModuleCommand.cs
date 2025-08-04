using System.Net;
using AutoMapper;
using LuksonExpense.Application.DTOs.MappingDtos;
using LuksonExpense.Application.DTOs.Requests.Modules;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Modules.Commands.Add
{
    public sealed class AddModuleCommand : IRequest<Response<ModuleDTO>>
    {
        public AddModuleRequest Request { get; set; }
    }

    public sealed class AddModuleCommanHandler(
        IModuleRepository moduleRepository, IMapper mapper) : IRequestHandler<AddModuleCommand, Response<ModuleDTO>>
    {
        public async Task<Response<ModuleDTO>> Handle(AddModuleCommand command, CancellationToken cancellationToken)
        {
            var response = new Response<ModuleDTO>();

            try
            {
                Module? existModule = await moduleRepository.GetByName(command.Request.Name);

                if (existModule != null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Error = new ErrorResponse
                    {
                        ErrorMessages = new List<string> { "Ya existe un módulo con el mismo nombre." }
                    };

                    return response;
                }

                Module addedModule = await moduleRepository.Add(mapper.Map<Module>(command.Request));

                response.StatusCode = HttpStatusCode.Created;
                response.Content = mapper.Map<ModuleDTO>(addedModule);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
