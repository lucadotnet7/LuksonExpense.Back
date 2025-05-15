namespace LuksonExpense.Application.DTOs.Requests.Modules
{
    public sealed class AddModuleRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string IconName { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
    }
}
