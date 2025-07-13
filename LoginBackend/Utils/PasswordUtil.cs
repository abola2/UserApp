using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace LoginBackend.Utils;

public class PasswordUtil
{
    public static byte[] HashPassword(string password, byte[] salt)
    {
        using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(password)))
        {
            hasher.Salt = salt;
            hasher.DegreeOfParallelism = 8; // Number of threads
            hasher.MemorySize = 65536; // 64 MB of memory
            hasher.Iterations = 4; // Number of iterations
            return hasher.GetBytes(32); // Get 32-byte hash
        }
    }
    
    public static byte[] GenerateSalt(int length)
    {
        byte[] salt = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }
    
    public static bool VerifyPassword(string password, byte[] salt, byte[] storedHash)
    {
        using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(password)))
        {
            hasher.Salt = salt;
            hasher.DegreeOfParallelism = 8;
            hasher.MemorySize = 65536;
            hasher.Iterations = 4;
            byte[] newHash = hasher.GetBytes(32);
            return newHash.SequenceEqual(storedHash); 
        }
    }
}