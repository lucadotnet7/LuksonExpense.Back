using AutoMapper;
using LuksonExpense.Application.DTOs.MappingDtos.Budgets;
using LuksonExpense.Application.DTOs.Requests.Budgets;
using LuksonExpense.Domain.Models;

namespace LuksonExpense.Application.DTOs.Profiles
{
    public sealed class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<AddBudgetRequest, Budget>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.BudgetName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.BudgetDescription))
                .ForMember(dest => dest.FromDate, opt => opt.MapFrom(x => x.BudgetFrom))
                .ForMember(dest => dest.ToDate, opt => opt.MapFrom(x => x.BudgetTo))
                .ForMember(dest => dest.CreatedAt, opt => GetActualDateTime());

            CreateMap<Budget, BudgetDTO>()
                .ForMember(dest => dest.BudgetId, opt => opt.MapFrom(x => x.Id.ToString()))
                .ForMember(dest => dest.BudgetName, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.BudgetDescription, opt => opt.MapFrom(x => x.Description))
                .ForMember(dest => dest.Period, opt => opt.MapFrom(x => GetBudgetPeriod(x)));
        }

        private DateTime GetActualDateTime()
        {
            TimeZoneInfo argentinaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            DateTime argentinaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, argentinaTimeZone);

            return argentinaTime;
        }

        private string GetBudgetPeriod(Budget budget)
        {
            string parsedDate = "dd-MM-yyyy";

            return $"{budget.FromDate.ToString(parsedDate)} - {budget.ToDate.ToString(parsedDate)}";
        }
    }
}
