
using System;
using System.Collections.Generic;
namespace reverseJobsBoard.Models
{
		public class Role
		{
			public Guid RoleID { get; set; } 
       		public string Name {get; set;}

            public List<UserRole> UserRoles {get; set;}
		}

}