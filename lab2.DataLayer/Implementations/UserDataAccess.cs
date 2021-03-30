using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using lab2.DataLayer.Context;
using lab2.DataLayer.Contracts;
using lab2.DataLayer.Entities;
using lab2.Domain.Contracts;
using lab2.Domain.Models;
using lab2.Domain;
using Microsoft.EntityFrameworkCore;

namespace lab2.DataLayer.Implementations
{
    public class UserDataAccess : IUserDataAccess
    {
        private NotesAppContext Context { get; }
        private IMapper Mapper { get; }

        public UserDataAccess(NotesAppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;

            context.Database.EnsureCreated();
        }

        public lab2.Domain.User Insert(UserUpdateModel user)
        {
            var result = this.Context.Add(this.Mapper.Map<lab2.DataLayer.Entities.User>(user));

            this.Context.SaveChanges();

            lab2.Domain.User res = new lab2.Domain.User { Id=result.Entity.Id };
            this.Mapper.Map(result.Entity, res);
            return res;
        }

        public lab2.Domain.User Get(UserIdentityModel id)
        {
            var result = this.Context.User.Where(u => u.Id == id.Id).First();

            return this.Mapper.Map<lab2.Domain.User>(result);
        }

        public lab2.Domain.User Update(UserIdentityModel id, UserUpdateModel user)
        {
            var existing = this.Context.User.Where(u => u.Id == id.Id).First();

            var result = this.Mapper.Map(user, existing);

            this.Context.Update(result);

            this.Context.SaveChanges();

            return this.Mapper.Map<lab2.Domain.User>(result);
        }
    }
}
