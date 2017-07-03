using System;
using System.Collections.Generic;
namespace reverseJobsBoard.Models
{
		public class User
		{
			public Guid UserID { get; set; } 
			public string first_name { get; set; }
            public string last_name { get; set;}
            public string email { get; set;}
 
       		public string Username { get; set; } 
 
        	public string Password { get; set; }

			public List<UserRole> UserRoles {get; set;}
			public List<UserOrg> UserOrgs {get;set;}
			
		}

}
