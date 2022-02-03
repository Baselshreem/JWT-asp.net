using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication11.Helper;
using WebApplication11.Iserv;
using WebApplication11.Model;
namespace WebApplication11.serves
{
    public class userinfoserv: iuserserv
    {

        private List<userinfo> user = new List<userinfo>
        {

            new userinfo{id=Guid.NewGuid(),fullname="Basil",username="bb",password="test"}
            //new userinfo{id=Guid.NewGuid(),fullname="Basil",username="Basil",password="test"},
        };
        private readonly Appseting app;

        public  userinfoserv(IOptions<Appseting> appsetings)
        {
            app = appsetings.Value;
        }

        public userinfo Authenticate(string username,string password)
        {
            var users= user.SingleOrDefault(x=>x.username==username && x.password==password);
            if (users == null) return null;
            var token = new JwtSecurityTokenHandler();//inlization
            var key = Encoding.ASCII.GetBytes(app.Secret);//set secret arrye of bit 
            var tokendes = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] { 
                new Claim(ClaimTypes.Name,users.id.ToString())
                }),
            Expires=DateTime.UtcNow.AddDays(7),
            SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var toke = token.CreateToken(tokendes);
            users.token = token.WriteToken(toke);
            return users;
          
        
        }
        
        
        public IEnumerable<userinfo> GetAll()
        {
            return user;
        }

    }
}
