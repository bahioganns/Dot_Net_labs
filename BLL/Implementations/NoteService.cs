using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using DataAccess.Contracts;
using Domain;
using Domain.Models;
using BLL.Contracts;

namespace BLL.Implementations
{
    public class NoteService : INoteCreateService, INoteGetService, INoteUpdateService, INoteDeleteService
    {
        private INoteDataAccess NoteDataAccess { get; }

        public NoteService(INoteDataAccess noteDataAccess)
        {
            this.NoteDataAccess = noteDataAccess;
        }

        public Note CreateNote(NoteUpdateModel note)
        {
            return this.NoteDataAccess.Insert(note);
        }

        public List<Note> GetUserNotes(UserIdentityModel userId)
        {
            return this.NoteDataAccess.GetUserNotes(userId);
        }

        public Note GetNote(NoteIdentityModel noteId)
        {
            return this.NoteDataAccess.Get(noteId);
        }

        public Note UpdateNote(NoteIdentityModel noteId, NoteUpdateModel note)
        {
            return this.NoteDataAccess.Update(noteId, note);
        }

        public void DeleteNote(NoteIdentityModel noteId)
        {
            this.NoteDataAccess.Delete(noteId);
        }
    }
}

