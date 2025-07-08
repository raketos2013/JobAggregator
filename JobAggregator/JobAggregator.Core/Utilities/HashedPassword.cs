using System.Security.Cryptography;

namespace JobAggregator.Core.Utilities;

public class HashedPassword
{
    private const int SaltSize = 32;

    public static byte[] GenerateSalt()
    {
        var randomNumber = new byte[SaltSize];
        RandomNumberGenerator.Fill(randomNumber);
        return randomNumber;
    }

    public static byte[] ComputeHMAC_SHA256(byte[] data, byte[] salt)
    {
        using var hmac = new HMACSHA256(salt);
        return hmac.ComputeHash(data);
    }
}
