using System.Security.Cryptography;
using reverseJobsBoard.Auth;


namespace reverseJobsBoard.Auth 
{ 
    public class RSAKeyHelper 
    { 
        public static RSAParameters GenerateKey() 
        { 
            
            using (RSA rsa = RSA.Create()) 
            { 
                
                return rsa.ExportParameters(true); 

            } 
        } 
    } 
} 
