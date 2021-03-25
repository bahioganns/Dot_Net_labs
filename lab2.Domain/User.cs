using System.Collections.Generic;

namespace lab2.Domain
{
    public class User
    {
        public override string ToString()
        {
            return $"User<id={Id}, email='{Email}'>";
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<Note> Notes { get; } = new List<Note>();
    }
}
