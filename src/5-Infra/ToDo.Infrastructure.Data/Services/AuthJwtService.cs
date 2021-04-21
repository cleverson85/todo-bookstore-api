using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Settings;

namespace ToDo.Infrastructure.Services
{
    public class AuthJwtService : IAuthJwtService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly AppSettings _appSettings;

        public AuthJwtService(IUsuarioService usuarioService, AppSettings appSettings)
        {
            _usuarioService = usuarioService;
            _appSettings = appSettings;
        }

        private async Task<SigningCredentials> GetSigningCredentials(string securityKey)
        {
            var key = Encoding.UTF8.GetBytes(securityKey);
            return await Task.FromResult(new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
        }

        private async Task<JwtSecurityToken> GenerateTokenOptions(SigningCredentials signingCredentials)
        {
            return await Task.FromResult
                (
                    new JwtSecurityToken(
                            issuer: _appSettings.JWTSettings.ValidIssuer,
                            audience: _appSettings.JWTSettings.ValidAudience,
                            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_appSettings.JWTSettings.ExpiryInMinutes)),
                            signingCredentials: signingCredentials
                        )
                );
        }

        public async Task<string> GenerateToken(GoogleJsonWebSignature.Payload payload)
        {
            var signingCredentials = await GetSigningCredentials(_appSettings.JWTSettings.SecurityKey);
            var tokenDescriptor = await GenerateTokenOptions(signingCredentials);

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(tokenDescriptor));
        }

        private async Task<SecurityToken> GenerateTokenOptions(SigningCredentials signingCredentials, Usuario usuario)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Id", usuario.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_appSettings.JWTSettings.ExpiryInMinutes)),
                SigningCredentials = signingCredentials
            };

            return await Task.FromResult(new JwtSecurityTokenHandler().CreateToken(tokenDescriptor));
        }

        public async Task<string> GenerateToken(Usuario usuario)
        {
            var signingCredentials = await GetSigningCredentials(_appSettings.JWTSettings.SecurityKey);
            var tokenDescriptor = await GenerateTokenOptions(signingCredentials, usuario);
            var token = await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(tokenDescriptor));

            return token;
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuth externalAuth)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>() { _appSettings.ClientId }
            };

            return await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
        }
    }
}


