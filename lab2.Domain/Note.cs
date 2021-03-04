using System;

namespace lab2.Domain
{
    public class Note
    {
        public Note(int id, int user_id, string title, string content, DateTime created)
        {
            this.id = id;
            this.user_id = user_id;
            this.title = title;
            this.content = content;
            this.created = created;
        }

        public override string ToString()
        {
            return $"Note<id={id}, user_id='{user_id}', title='{title}'>";
        }

        public int id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime created { get; set; }
    }
}
