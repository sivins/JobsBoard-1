using System;
namespace reverseJobsBoard.Models
{
		public class UserTech
		{
			public Guid UserTechRelID { get; set; } 
 
       		public Guid UserID {get; set;}
 
        	public Guid TechID {get; set;}

            public int YOE {get;set;}
            public int MOE {get;set;}

			public User User {get; set;}
			public Tech Tech {get; set;}
			
		}

}