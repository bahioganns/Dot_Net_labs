using System;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Context;
using DataAccess.Implementations;
using Domain.Models;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Domain.Models.UserUpdateModel, DataAccess.Entities.User>();
                cfg.CreateMap<Domain.Models.UserUpdateModel, Domain.User>();
                cfg.CreateMap<DataAccess.Entities.User, Domain.User>();
                cfg.CreateMap<Domain.User, DataAccess.Entities.User>();
                cfg.CreateMap<Domain.Models.NoteUpdateModel, DataAccess.Entities.Note>();
                cfg.CreateMap<Domain.Models.NoteUpdateModel, Domain.Note>();
                cfg.CreateMap<DataAccess.Entities.Note, Domain.Note>();
                cfg.CreateMap<Domain.Note, DataAccess.Entities.Note>();
            });
            Mapper mapper = new Mapper(mapperConfig);

            var context = new NotesAppContext();

            UserDataAccess userDataAccess = new UserDataAccess(context, mapper);

            Domain.User user = userDataAccess.Insert(new UserUpdateModel{ Email="123@456.ru", PasswordHash="qwe" });

            Console.WriteLine("Created User:");
            Console.WriteLine(user);

            Console.WriteLine("\nGet User From Database:");
            Console.WriteLine(userDataAccess.Get(new UserIdentityModel(1)));

            Domain.User updatedUser = userDataAccess.Update(
                new UserIdentityModel(1),
                new UserUpdateModel{ Email="111@789.ru", PasswordHash="rty" }
            );

            Console.WriteLine("\nUpdated User:");
            Console.WriteLine(updatedUser);

            NoteDataAccess noteDataAccess = new NoteDataAccess(context, mapper);

            Domain.Note note = noteDataAccess.Insert(new NoteUpdateModel{ Title="123", Content="qwe", UserId=user.Id });

            Console.WriteLine("\nCreated Note:");
            Console.WriteLine(note);

            Console.WriteLine("\nGet Note From Database:");
            Console.WriteLine(noteDataAccess.Get(new NoteIdentityModel(1)));

            Domain.Note updatedNote = noteDataAccess.Update(
                new NoteIdentityModel(1),
                new NoteUpdateModel{ Title="Test", Content="Hello", UserId=1 }
            );

            Console.WriteLine("\nUpdated Note:");
            Console.WriteLine(noteDataAccess.Get(new NoteIdentityModel(1)));

            Console.WriteLine("\nGet User Notes:");
            noteDataAccess.GetUserNotes(new UserIdentityModel(1)).ForEach(Console.WriteLine);

            Console.WriteLine("\nGet User Notes From User Class:");
            userDataAccess.Get(new UserIdentityModel(1)).Notes.ForEach(Console.WriteLine);

            noteDataAccess.Delete(new NoteIdentityModel(1));
            userDataAccess.Delete(new UserIdentityModel(1));
        }
    }
}
