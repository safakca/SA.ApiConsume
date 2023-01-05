using System.Text;

namespace Backend.Infrastructure.Tools
{
    public class JwtDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string Key = "safaksafak4.";
        public const int Expire = 5;  //TODO: token yaşam süresi (saat,gün ayarı yapılacak !)
    }
}
