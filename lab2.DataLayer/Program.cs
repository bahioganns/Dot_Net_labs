using System;
using AutoMapper;
using lab2.DataLayer.Entities;
using lab2.DataLayer.Context;
using lab2.DataLayer.Implementations;

namespace lab2.DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<lab2.Domain.User, User>();
                cfg.CreateMap<User, lab2.Domain.User>();
            });
            Mapper mapper = new Mapper(config);

            var context = new NotesAppContext();

            UserDataAccess userDataAccess = new UserDataAccess(context, mapper);

            Console.Write(userDataAccess.GetById(1));
            /*

                User user = new User { Email = "qwerty@123.ru", PasswordHash="123" };
                db.Add(user);
                db.SaveChanges();
                Console.WriteLine(user.Id);

                Note note = new Note { User=user, Title="qwe", Content="Rty" };
                db.Add(note);
                db.SaveChanges();
            */
        }
    }
}
