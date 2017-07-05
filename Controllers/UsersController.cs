using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reverseJobsBoard.Models;


namespace reverseJobsBoard.Controllers
{
    [Route("api/UserData")]
    public class UsersController : Controller
    {
       

        [HttpGet("[action]")]
        public IList<User> getAllUsers()
        {   
            using(var db = new TDBContext()){
                var users = db.Users.Select(u=> new User {
                    Username = u.Username,
                    first_name = u.first_name
                });

                return users.ToList();

                
            }

        }
        
    }
}