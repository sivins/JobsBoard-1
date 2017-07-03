using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc; 
using reverseJobsBoard.Auth; 
using System.IdentityModel.Tokens.Jwt; 
using System.IdentityModel.Tokens;
using Newtonsoft.Json; 
using System.Security.Claims; 
using System.Security.Principal; 
using Microsoft.IdentityModel.Tokens; 
using reverseJobsBoard.Models; 
using Microsoft.AspNetCore.Authorization; 
 
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860 
 
namespace reverseJobsBoard.Controllers 
{ 
    [Route("api/auth")] 
    public class TokenAuthController : Controller 
    { 
        [HttpPost] 
        public string GetAuthToken([FromBody]User user) 
        { 
            var existUser = UserStorage.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password); 
 
            if (existUser != null) 
            { 
                var requestAt = DateTime.Now; 
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan; 
                var token = GenerateToken(existUser, expiresIn); 
                Console.WriteLine("So far so good initial request");
                return JsonConvert.SerializeObject(new RequestResult 
                { 
                    State = RequestState.Success, 
                    Data = new 
                    { 
                        requested = requestAt, 
                        expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds, 
                        tokeyType = TokenAuthOption.TokenType, 
                        accessToken = token 
                    } 
                }); 
            } 
            else 
            { 
                return JsonConvert.SerializeObject(new RequestResult 
                { 
                    State = RequestState.Failed, 
                    Msg = "Username or password is invalid" 
                }); 
            } 
        } 
 
        private string GenerateToken(User user, DateTime expires) 
        { 
            var handler = new JwtSecurityTokenHandler(); 
            Console.WriteLine("So far so good");
 
            ClaimsIdentity identity = new ClaimsIdentity( 
                new GenericIdentity(user.Username, "TokenAuth"), 
                new[] { 
                    new Claim("UserID", user.UserID.ToString()) 
                } 
            ); 
 
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor 
            { 
                Issuer = TokenAuthOption.Issuer, 
                Audience = TokenAuthOption.Audience, 
                SigningCredentials = TokenAuthOption.SigningCredentials, 
                Subject = identity, 
                Expires = expires 
            }); 

            Console.WriteLine("So far so good 2");
            return handler.WriteToken(securityToken); 
        } 
 
        [HttpGet] 
        [Authorize("Bearer")] 
        public string GetUserInfo() 
        { 
            try{
            var claimsIdentity = User.Identity as ClaimsIdentity; 
 
            return JsonConvert.SerializeObject(new RequestResult 
            { 
                State = RequestState.Success, 
                Data = new 
                { 
                    UserName = claimsIdentity.Name,
                    Email  = "somebody@example.com"
                } 
            }); 
            }
            catch(Exception e){
                Console.WriteLine("{0} Exception caught.", e);
                return JsonConvert.SerializeObject(new RequestResult
                {
                    State= RequestState.Failed
                });
            }
        } 
    } 
 
 
    public static class UserStorage 
    { 
        public static List<User> Users { get; set; } = new List<User> { 
            new User {UserID=Guid.NewGuid(),Username="user1",Password = "user1psd" }, 
            new User {UserID=Guid.NewGuid(),Username="user2",Password = "user2psd" }, 
            new User {UserID=Guid.NewGuid(),Username="user3",Password = "user3psd" } 
        }; 
    } 
} 