using lab2.Domain.Contracts;

namespace lab2.Domain.Models
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
