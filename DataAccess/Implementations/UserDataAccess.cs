using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataLayer.Context;
using DataLayer.Contracts;
using DataLayer.Entities;
using Domain.Contracts;
using Domain.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Implementations
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

        public Domain.User Insert(UserUpdateModel user)
        {
            var result = this.Context.Add(this.Mapper.Map<DataLayer.Entities.User>(user));

            this.Context.SaveChanges();

            Domain.User res = new Domain.User { Id=result.Entity.Id };
            this.Mapper.Map(result.Entity, res);
            return res;
        }

        public Domain.User Get(UserIdentityModel id)
        {
            var result = this.Context.User.Where(u => u.Id == id.Id).First();

            return this.Mapper.Map<Domain.User>(result);
        }

        public Domain.User Update(UserIdentityModel id, UserUpdateModel user)
        {
            var existing = this.Context.User.Where(u => u.Id == id.Id).First();

            var result = this.Mapper.Map(user, existing);

            this.Context.Update(result);

            this.Context.SaveChanges();

            return this.Mapper.Map<Domain.User>(result);
        }
    }
}
