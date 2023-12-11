using Microsoft.IdentityModel.Tokens;
using SistemaTarefaNovo.Aplication.DTOs;
using SistemaTarefaNovo.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemasTarefasNovo.API.Autenticates
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _chave;

        public TokenService(IConfiguration config)
        {
            _chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwt:secretKey"]!));
        }

        public string GerarToken(string username, string senha)
        {

            var claims = new List<Claim> {
            
                new Claim(JwtRegisteredClaimNames.NameId, username ) ,
                new Claim(JwtRegisteredClaimNames.Sub, senha ),
                new Claim(ClaimTypes.Role, "Administrador"),

            };

            var credenciais = new SigningCredentials(_chave, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = credenciais,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
