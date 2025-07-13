using System.Security.Cryptography;

namespace LoginBackend.Utils;

public class SessionUtil
{
    public static string GenerateToken(string userId)
    {
        // Generate 32 bytes of random data
        byte[] randomBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        // Convert random bytes to Base64
        string randomPart = Convert.ToBase64String(randomBytes);

        // Combine userId with the random part
        return $"{userId}:{randomPart}";
    }
}