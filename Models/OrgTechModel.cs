using System;
namespace reverseJobsBoard.Models
{
		public class OrgTechRel
		{
			public Guid OrgTechID { get; set; } 
 
       		public Guid OrgID {get; set;}
 
        	public Guid TechID {get; set;}

			public Org Org {get; set;}
			public Tech Tech {get; set;}
			
		}

}