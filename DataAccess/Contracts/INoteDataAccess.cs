using System.Collections.Generic;
using Domain;
using Domain.Models;

namespace DataLayer.Contracts
{
    public interface INoteDataAccess
    {
        Domain.Note Insert(NoteUpdateModel note);
        Domain.Note Get(NoteIdentityModel id);
        List<Domain.Note> GetUserNotes(UserIdentityModel userId);
        Domain.Note Update(NoteIdentityModel id, NoteUpdateModel note);
        void Delete(NoteIdentityModel id);
    }
}
