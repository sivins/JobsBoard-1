using System;
namespace reverseJobsBoard.Models
{
		public class UserRole
		{
			public Guid UserRoleID { get; set; } 
 
       		public Guid UserID {get; set;}
 
        	public Guid RoleID {get; set;}

			public User User {get; set;}
			public Role Role {get; set;}
			
		}

}