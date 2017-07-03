using Microsoft.IdentityModel.Tokens; 
using System; 
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace reverseJobsBoard.Auth 
{ 
    public class TokenAuthOption 
    { 
        public static string Audience { get; } = "ExampleAudience"; 
        public static string Issuer { get; } = "ExampleIssuer"; 
        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey()); 
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature); 
 
        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(4000); 
        public static string TokenType { get; } = "Bearer";  
    } 
} 