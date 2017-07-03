using System;
namespace reverseJobsBoard.Models
{
		public class UserOrg
		{
			public Guid UserOrgID { get; set; } 
 
       		public Guid UserID {get; set;}
 
        	public Guid OrgID {get; set;}

			public User User {get; set;}
			public Org Org {get; set;}
			
		}

}