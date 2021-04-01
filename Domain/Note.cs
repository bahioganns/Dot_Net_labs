using System;
using Domain.Contracts;

namespace Domain
{
    public class Note: IUserContainer
    {
        public override string ToString()
        {
            return $"Note<id={Id}, user_id='{User.Id}', title='{Title}'>";
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        int? IUserContainer.UserId => this.User.Id;
    }
}
