using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using lab2.DataLayer.Context;
using lab2.DataLayer.Contracts;
using lab2.DataLayer.Entities;
using lab2.Domain.Contracts;
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
        }

        public lab2.Domain.User Insert(lab2.Domain.User user)
        {
            var result = this.Context.Add(this.Mapper.Map<User>(user));

            this.Context.SaveChanges();

            return this.Mapper.Map<lab2.Domain.User>(result.Entity);
        }

        public lab2.Domain.User GetById(int userId)
        {
            var result = this.Context.User.Where(u => u.Id==userId).First();

            return this.Mapper.Map<lab2.Domain.User>(result);
        }

        public lab2.Domain.User Update(lab2.Domain.User user)
        {
            var existing = this.GetById(user.Id);

            var result = this.Mapper.Map(user, existing);

            this.Context.Update(result);

            this.Context.SaveChanges();

            return this.Mapper.Map<lab2.Domain.User>(result);
        }
    }
}
