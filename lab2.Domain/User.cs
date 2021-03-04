namespace lab2.Domain
{
    public class User
    {
        public User(int id, string email, string password_hash)
        {
            this.id = id;
            this.email = email;
            this.password_hash = password_hash;
        }

        public override string ToString()
        {
            return $"User<id={id}, email='{email}'>";
        }

        public int id { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
    }
}
