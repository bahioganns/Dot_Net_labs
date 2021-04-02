using System;

namespace DTO
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public UserDTO User { get; set; }
    }
}
