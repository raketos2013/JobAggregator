using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface ITokenService
{
    Task<(string token, DateTime expiration)> GenerateAccessToken(User user);
}
