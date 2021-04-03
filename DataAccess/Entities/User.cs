using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            this.Notes = new HashSet<Note>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
