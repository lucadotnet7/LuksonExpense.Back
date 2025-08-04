using LuksonExpense.Application.DTOs.MappingDtos;

namespace LuksonExpense.Application.DTOs.Responses.Modules
{
    public sealed class ModuleListResponse
    {
        public int TotalRegisters { get; set; }
        public IEnumerable<ModuleDTO> Modules { get; set; }
    }
}
