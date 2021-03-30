using System;
using AutoMapper;
using DataLayer.Entities;
using DataLayer.Context;
using DataLayer.Implementations;
using Domain.Models;

namespace DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Domain.Models.UserUpdateModel, DataLayer.Entities.User>();
                cfg.CreateMap<Domain.Models.UserUpdateModel, Domain.User>();
                cfg.CreateMap<DataLayer.Entities.User, Domain.User>();
                cfg.CreateMap<Domain.User, DataLayer.Entities.User>();
            });
            Mapper mapper = new Mapper(config);

            var context = new NotesAppContext();

            UserDataAccess userDataAccess = new UserDataAccess(context, mapper);

            Domain.User user = userDataAccess.Insert(new UserUpdateModel{ Email="123@456.ru", PasswordHash="qwe" });

            Console.WriteLine("Created User:");
            Console.WriteLine(user);

            Console.WriteLine("\nGet from Database User:");
            Console.WriteLine(userDataAccess.Get(new UserIdentityModel(1)));

            Domain.User updatedUser = userDataAccess.Update(new UserIdentityModel(1), new UserUpdateModel{ Email="111@789.ru", PasswordHash="rty" });

            Console.WriteLine("\nUpdated User:");
            Console.Write(updatedUser);
        }
    }
}
