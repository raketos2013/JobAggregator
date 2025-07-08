using JobAggregator.Core.Configurations;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobAggregator.Core.Services;

public class TokenService(IOptions<JwtConfiguration> jwtConfig,
                            IRoleService roleService) : ITokenService
{
    public async Task<(string token, DateTime expiration)> GenerateAccessToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = Encoding.UTF8.GetBytes(jwtConfig.Value.SecretKey);

        var userRole = await roleService.GetAsync(user.RoleId);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iss, jwtConfig.Value.Issuer),
            new("Name", user.Name),
            new("Lastname", user.LastName),
            new(ClaimTypes.Role, userRole.Name)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(jwtConfig.Value.ExpirationInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature),
            Audience = jwtConfig.Value.Audience,
            Issuer = jwtConfig.Value.Issuer,

        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return (tokenHandler.WriteToken(token), tokenDescriptor.Expires.Value);
    }
}
