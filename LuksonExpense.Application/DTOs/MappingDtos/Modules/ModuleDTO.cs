namespace LuksonExpense.Application.DTOs.MappingDtos.Modules
{
    public sealed record class ModuleDTO
    {
        public string Name { get; set; } = string.Empty;
        //Nombre de icono de Material UI -> https://mui.com/material-ui/material-icons
        public string IconName { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
    }
}
