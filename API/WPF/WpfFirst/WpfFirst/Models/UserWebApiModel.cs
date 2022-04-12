
namespace WpfFirst.Models
{
    public class UserWebApiModel
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int isAdmin { get; set; }
        public int isBan { get; set; }
        public int isMute { get; set; }

        public string? Photo { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Id} {Login} {Email}";
        }
    }
}
