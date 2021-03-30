using Domain.Contracts;

namespace Domain.Models
{
    public class NoteIdentityModel : INoteIdentity
    {
        public int Id { get; }

        public NoteIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
