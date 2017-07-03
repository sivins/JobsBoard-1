
using System;
using System.Collections.Generic;
namespace reverseJobsBoard.Models
{
		public class Tech
		{
			public Guid TechID { get; set; } 
       		public string Name {get; set;}
			public string Language {get; set;}
			public Layer Layer {get;set;}
            public List<OrgTechRel> OrgTechRel {get; set;}
			public List<UserTech> UserTechRel {get; set;}
		}

		public enum Layer 
		{ 
			DevOps = -2, 
			Backend = -1, 
			BackFront = 0, 
			FrontEnd = 1 
		} 
}