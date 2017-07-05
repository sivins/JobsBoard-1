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
			public List<UserTech> UserTech {get;set;}
			public List<EmpHistory> EmpHistory {get;set;}
		}

		public class EmpHistory{
			public Guid historyId {get;set;}
			public User userId {get;set;}
			public DateTime StartDate {get;set;}
			public DateTime EndDate {get;set;}
			public Boolean isCurrent {get;set;}
			public String Title {get;set;}
			public String Location {get;set;}
			public String Description {get;set;}
			public Boolean isPublic {get;set;}

		}


}
