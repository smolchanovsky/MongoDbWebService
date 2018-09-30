using System;
using Infrastructure.Common;
using MongoDbWebService.Models.Enums;

namespace MongoDbWebService.ServiceLayer.Dto
{
	/// <summary>
	/// Data transfer object for Call entity.
	/// </summary>
	public class CallDto : IEntity
    {
	    public string Id { get; set; }
		public TimeSpan Duration { get; set; }
        public CallStatusType Status { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime ConnectionOn { get; set; }
        public DateTime TerminateOn { get; set; }
    }
}
