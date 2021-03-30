using System;
using AutoMapper;
using lab2.DataLayer.Entities;
using lab2.DataLayer.Context;
using lab2.DataLayer.Implementations;
using lab2.Domain.Models;

namespace lab2.DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<lab2.Domain.Models.UserUpdateModel, lab2.DataLayer.Entities.User>();
                cfg.CreateMap<lab2.Domain.Models.UserUpdateModel, lab2.Domain.User>();
                cfg.CreateMap<lab2.DataLayer.Entities.User, lab2.Domain.User>();
                cfg.CreateMap<lab2.Domain.User, lab2.DataLayer.Entities.User>();
            });
            Mapper mapper = new Mapper(config);

            var context = new NotesAppContext();

            UserDataAccess userDataAccess = new UserDataAccess(context, mapper);

            lab2.Domain.User user = userDataAccess.Insert(new UserUpdateModel{ Email="123@456.ru", PasswordHash="qwe" });

            Console.WriteLine("Created User:");
            Console.WriteLine(user);

            Console.WriteLine("\nGet from Database User:");
            Console.WriteLine(userDataAccess.Get(new UserIdentityModel(1)));

            lab2.Domain.User updatedUser = userDataAccess.Update(new UserIdentityModel(1), new UserUpdateModel{ Email="111@789.ru", PasswordHash="rty" });

            Console.WriteLine("\nUpdated User:");
            Console.Write(updatedUser);
        }
    }
}
