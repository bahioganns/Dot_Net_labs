using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public override string ToString()
        {
            return $"User<id={Id}, email='{Email}'>";
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public List<Note> Notes { get; } = new List<Note>();
    }
}
