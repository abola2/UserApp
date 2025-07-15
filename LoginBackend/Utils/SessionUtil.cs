using System.Security.Cryptography;

namespace LoginBackend.Utils;

public class SessionUtil
{
    public static string GenerateToken(string userId)
    {
        var randomBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        var randomPart = Convert.ToBase64String(randomBytes);

        return $"{userId}:{randomPart}";
    }
}