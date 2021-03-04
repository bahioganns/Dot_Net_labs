namespace lab2.Domain
{
    public class User
    {
        public override string ToString()
        {
            return $"User<id={id}, email='{email}'>";
        }

        public int id { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
    }
}
