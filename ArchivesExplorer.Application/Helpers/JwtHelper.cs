using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Domain.Constants;
using ArchivexExplorer.Domain.Enums;
using ArchivexExplorer.Domain.Models;
using ArchivexExplorer.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArchivesExplorer.Application.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        private readonly UserAuthTokenOptions _options;

        public JwtHelper(IOptions<UserAuthTokenOptions> options)
        {
            _options = options.Value;
        }

        public string? GenerateToken(ClaimsIdentity claimsIdentity, TokenAccessTypes accessType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = GetSecurityTokenDescriptor(claimsIdentity);

            switch (accessType)
            {
                case TokenAccessTypes.AccessToken:
                    {
                        tokenDescriptor.Expires = DateTime.UtcNow.Add(_options.AccessTokenDuration);
                        break;
                    }

                case TokenAccessTypes.RefreshToken:
                    {
                        tokenDescriptor.Expires = DateTime.UtcNow.Add(_options.RefreshTokenDuration);
                        break;
                    }
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsIdentity GenerateClaimsIdentity(UserModel user, TokenAccessTypes tokenType)
        {
            var claims = new List<Claim>();

            switch (tokenType)
            {
                case TokenAccessTypes.AccessToken:
                    claims.Add(new Claim(ClaimConstants.UserId, user.Id.ToString()));
                    claims.Add(new Claim(ClaimConstants.AccessType, tokenType.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role.RoleName));
                    break;

                case TokenAccessTypes.RefreshToken:
                    claims.Add(new Claim(ClaimConstants.UserId, user.Id.ToString()));
                    claims.Add(new Claim(ClaimConstants.AccessType, tokenType.ToString()));
                    break;
            }

            return new ClaimsIdentity(claims);
        }

        private SecurityTokenDescriptor GetSecurityTokenDescriptor(ClaimsIdentity claimsIdentity)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(GetKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }

        private SymmetricSecurityKey GetKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
        }
    }
}
