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
        public IEnumerable<User> getAllUsers()
        {
           User[] Users = new User[]
            {
            new User {first_name = "Daniel",last_name=
            "Ashcraft", email = "something@example.com"},
            new User {first_name = "Michael",last_name=
            "Matthews", email = "something@example.com"},
            new User {first_name = "Jonah",last_name=
            "Johnson", email = "something@example.com"},
            new User {first_name = "Mary",last_name=
            "Wallard", email = "something@example.com"},
            };

            return Users;
        }
        
    }
}