using AutoMapper;

using DataAccess.Entities;
using DTO;
using Domain;
using Domain.Models;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        // User
        CreateMap<Domain.User, DataAccess.Entities.User>().ReverseMap();
        CreateMap<UserUpdateModel, DataAccess.Entities.User>().ReverseMap();
        CreateMap<UserDTO, UserUpdateModel>().ReverseMap();
        CreateMap<Domain.User, UserDTO>().ReverseMap();
        // Note
        CreateMap<Domain.Note, DataAccess.Entities.Note>().ReverseMap();
        CreateMap<NoteUpdateModel, DataAccess.Entities.Note>().ReverseMap();
        CreateMap<NoteDTO, NoteUpdateModel>().ReverseMap();
        CreateMap<Domain.Note, NoteDTO>().ReverseMap();
    }
}
