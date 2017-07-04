using System;
using System.Net;
using System.Threading;
using System.ComponentModel;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using reverseJobsBoard.Configs;

namespace reverseJobsBoard.Services
{
    public class MailService
    {   
        
        public static void SendMessage(String FirstName, String LastName, String Email, String Message){
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Daniel Ashcraft", "daniel.ashcraft@ofashandfire.com"));
			message.To.Add(new MailboxAddress(FirstName+ " " + LastName, Email));
			message.Subject = "Contact Form Submission";

            message.Body = new TextPart("plain")
            {
                Text = FirstName + "\n" + LastName + "\n" + Email + "\n" + Message
			};

			using (var client = new SmtpClient())
			{
				// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                try{
                    TestConfigs config = new TestConfigs();
					client.Connect("smtpout.secureserver.net", 80, false);

					// Note: since we don't have an OAuth2 token, disable
					// the XOAUTH2 authentication mechanism.
					client.AuthenticationMechanisms.Remove("XOAUTH2");

					// Note: only needed if the SMTP server requires authentication
					client.Authenticate("daniel.ashcraft@ofashandfire.com", config.emailPass);

					client.Send(message);
					client.Disconnect(true);


                }
                catch(Exception e){

                    Console.WriteLine(e.ToString());

                }
				
			}

        }

    }
}
