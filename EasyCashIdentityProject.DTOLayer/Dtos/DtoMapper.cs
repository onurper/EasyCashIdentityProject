using AutoMapper;
using EasyCashIdentityProject.DTOLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;

namespace EasyCashIdentityProject.DTOLayer.Dtos
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<AppUserRegisterDto, AppUser>().ReverseMap();
        }
    }
}