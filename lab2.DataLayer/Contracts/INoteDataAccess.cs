using System.Collections.Generic;
using lab2.Domain;
using lab2.Domain.Models;

namespace lab2.DataLayer.Contracts
{
    public interface INoteDataAccess
    {
        lab2.Domain.Note Insert(NoteUpdateModel note);
        lab2.Domain.Note Get(NoteIdentityModel id);
        IEnumerable<lab2.Domain.Note> GetUserNotes(UserIdentityModel userId);
        lab2.Domain.Note Update(NoteIdentityModel id, NoteUpdateModel note);
    }
}
