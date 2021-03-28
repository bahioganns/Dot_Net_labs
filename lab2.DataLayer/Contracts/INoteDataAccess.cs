using System.Collections.Generic;
using lab2.Domain;

namespace lab2.DataLayer.Contracts
{
    public interface INoteDataAccess
    {
        Note Insert(Note note);
        IEnumerable<Note> GetUserNotes(User user);
        Note Update(Note note);
    }
}
