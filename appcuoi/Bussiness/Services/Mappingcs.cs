using appcuoi.Bussiness.DTOs;
using appcuoi.Bussiness.DTOs.Request;
using appcuoi.Bussiness.DTOs.Respond;
using appcuoi.Data.Models;
using AutoMapper;

namespace appcuoi.Bussiness.Services
{
    public class Mappingcs:Profile
    {
        public Mappingcs() 
        {
            CreateMap<Users,UserDTOs>().ForMember(des => des.RoleName,otp=>otp.MapFrom(src=>src.Roles.RoleName)).ReverseMap();
            CreateMap<Users,UserRegisterDTOs>().ReverseMap();
            CreateMap<Houses,HouseDTOs>().ReverseMap();
            CreateMap<Houses, ListHouseDTOs>().ForMember(des => des.Landlord, otp => otp.MapFrom(src => src.User.Username)).ForMember(des => des.Street, otp => otp.MapFrom(src => src.Street.StreetName)).ForMember(des => des.Ward, otp => otp.MapFrom(src => src.Street.Ward.WardName)).ForMember(des => des.District, otp => otp.MapFrom(src => src.Street.Ward.District.DistrictName)).ReverseMap();
            CreateMap<updateHouseDTO, Houses>().ForAllMembers(otp => otp.Condition((src, des, srcMember) => srcMember != null));

        }

    }
}
