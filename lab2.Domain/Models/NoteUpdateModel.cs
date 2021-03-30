using lab2.Domain.Contracts;

namespace lab2.Domain.Models
{
    public class NoteUpdateModel: IUserContainer
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int? UserId { get; set; }
    }
}
