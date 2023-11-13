using appcuoi.Bussiness.IServices;
using appcuoi.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace appcuoi.Bussiness.Services
{
    public class TokenService : ITokenservice
    {
        public string CreateToken(Users users)
        {
            
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("-UK-CoHp_Ow4VRjx41cQqzpNMDexj4vpBWiLjRUAScAWozenQMhLqGdFNLHtrMEidluJyf9u2dWEosztjMwNHJiBx4wMmQL9ovP9tILEvQTG435R4-tFVRvXZg6_FOvdyDSi35ibA2ARJpQ5-2S4_oZQBV69VGT-oYOHY9XpOBM"));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {

                new Claim("Id",users.UserId.ToString()),
                new Claim(ClaimTypes.Email, users.Email),
                new Claim(ClaimTypes.Name,users.Username),
                new Claim(ClaimTypes.Role,users.Roles.RoleName),
                new Claim(ClaimTypes.Role, users.ActiveStatus),
                new Claim(ClaimTypes.Role,users.Username)
                



            };
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken("http://localhost:5000",
                                                                     "http://localhost:5000",
                                                                     claims,
                                                                     DateTime.Now,
                                                                     DateTime.Now.AddMinutes(30),
                                                                     signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);


        }
    }
}
