using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using reverseJobsBoard.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using reverseJobsBoard.Services;

namespace reverseJobsBoard.Controllers
{
    [Route("api/register")]
    public class Register : Controller
    {
    
        [HttpGet("{username}")]
        public JsonResult CheckUsername(String username)
        {
            using(var db = new TDBContext()){
                var exists = db.Users.Single(x => x.Username == username);
                if(exists != null){
                    return Json(
                        new {
                        exists = false
                    });
                }
                else{
                    return Json(
                        new {
                        exists = true
                    });
                }
            }
        }


        [HttpPost]
        public JsonResult RegisterUser([FromBody] JObject data)
        {
            JToken userToken = data;
            using(var db = new TDBContext()){
                
            var exists = db.Users.Single(x=> x.Username == (string)userToken.SelectToken("username"));

            if(exists == null){
                    Guid user_id = Guid.NewGuid();
                    String username = (string)userToken.SelectToken("username");
                    String first_name = (string)userToken.SelectToken("first_name");
                    String last_name = (string)userToken.SelectToken("last_name");
                    String email = (string)userToken.SelectToken("email");
                    String password = (string)userToken.SelectToken("password");


                    
                    var user = new User();
                    user.UserID = user_id;
                    user.Username = username;
                    user.email = email;
                    user.first_name = first_name;
                    user.Password = password;
                    user.last_name = last_name;

                    try{
                        db.Users.Add(user);
                        db.SaveChanges();
                        MailService.SendMessage(first_name,last_name,email,"Thank you for Registering with us!");

                        return Json(
                            new {
                            success = true
                        });
                    }
                    catch(Exception e){
                        Console.WriteLine(e);
                        return Json(
                            new {
                            Message = "There was an issue, please try again later"
                        });
                    }
                }
                else{
                    return Json(
                            new {
                            Message = "User Exists"
                        });
                }
                
                    
                
                
            }
        }

    }
}
