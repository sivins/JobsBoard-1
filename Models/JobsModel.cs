using System;
using System.Collections.Generic;
namespace reverseJobsBoard.Models
{
		public class Job
		{
			public Guid JobID { get; set; } 
			public string Name { get; set; }
			public string Department { get; set; }
			public Boolean isLive {get;set;}
			public DateTime CreatedOn { get; set; }
			public DateTime UpdatedAt { get; set; }
			public Org Org {get;set;}
			public User CreatedBy {get;set;}

			public List<User> Applicants {get;set;}
			public List<Tech> Technologies {get;set;}
		}

}
