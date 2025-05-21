using AutoMapper;
using LuksonExpense.Application.DTOs.Requests.Users;
using LuksonExpense.Domain.Models;

namespace LuksonExpense.Application.DTOs.Profiles
{
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));
        }
    }
}
