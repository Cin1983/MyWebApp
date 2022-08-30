namespace BulkyBookWeb.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }

        public string PassWord { get; set; }
    }
}
