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
    public class NoteDataAccess : INoteDataAccess
    {
        private NotesAppContext Context { get; }
        private IMapper Mapper { get; }

        public NoteDataAccess(NotesAppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;

            context.Database.EnsureCreated();
        }

        public Domain.Note Insert(NoteUpdateModel note)
        {
            var result = this.Context.Add(this.Mapper.Map<DataLayer.Entities.Note>(note));

            this.Context.SaveChanges();

            Domain.Note res = new Domain.Note { Id=result.Entity.Id };
            this.Mapper.Map(result.Entity, res);
            return res;
        }

        public Domain.Note Get(NoteIdentityModel id)
        {
            var result = this.Context.Note.Where(n => n.Id == id.Id).First();

            return this.Mapper.Map<Domain.Note>(result);
        }

        public List<Domain.Note> GetUserNotes(UserIdentityModel userId)
        {
            return (this.Context.Note
                                .Where(n => n.UserId == userId.Id)
                                .ToList()
                                .Select(x => this.Mapper.Map<Domain.Note>(x))
                                .ToList());
        }

        public Domain.Note Update(NoteIdentityModel id, NoteUpdateModel note)
        {
            var existing = this.Context.Note.Where(n => n.Id == id.Id).First();

            var result = this.Mapper.Map(note, existing);

            this.Context.Update(result);

            this.Context.SaveChanges();

            return this.Mapper.Map<Domain.Note>(result);
        }
    }
}
