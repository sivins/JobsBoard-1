using System;
using System.Collections.Generic;
namespace reverseJobsBoard.Models
{
		public class Org
		{
			public Guid OrgID { get; set; } 
			public string Name { get; set; }
 
			public List<UserOrg> UserOrgs {get;set;}
			
		}

}
