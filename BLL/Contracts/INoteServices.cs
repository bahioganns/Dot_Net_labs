using System.Collections.Generic;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface INoteCreateService
    {
        Note CreateNote(NoteUpdateModel note);
    }

    public interface INoteGetService
    {
        List<Note> GetUserNotes(UserIdentityModel userId);
        Note GetNote(NoteIdentityModel noteId);
    }

    public interface INoteUpdateService
    {
        Note UpdateNote(NoteIdentityModel noteId, NoteUpdateModel note);
    }

    public interface INoteDeleteService
    {
        void DeleteNote(NoteIdentityModel noteId);
    }
}
