using System;

namespace lab2.Domain
{
    public class Note
    {
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
