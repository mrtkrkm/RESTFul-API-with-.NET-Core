using MG.Core.Dtos.Concrete;
using MG.Core.Entites.Concrete;
using MG.Core.Extensions;
using MG.Core.Utilities.Security.Common;
using MG.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MG.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<UserOperationClaimDto> claims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, claims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken { 
                Token = token, 
                Expiration = _accessTokenExpiration 
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<UserOperationClaimDto> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    expires: _accessTokenExpiration,
                    notBefore: DateTime.Now,
                    claims: SetClaims(user, operationClaims),
                    signingCredentials: signingCredentials
                );

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<UserOperationClaimDto> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.ClaimName).ToArray());

            return claims;
        }
    }
}
