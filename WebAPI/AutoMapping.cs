using AutoMapper;

using DataAccess.Entities;
using DTO;
using Domain;
using Domain.Models;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Domain.User, DataAccess.Entities.User>().ReverseMap();
        CreateMap<UserUpdateModel, DataAccess.Entities.User>().ReverseMap();
        CreateMap<UserDTO, UserUpdateModel>().ReverseMap();
        CreateMap<Domain.User, UserDTO>().ReverseMap();
    }
}
