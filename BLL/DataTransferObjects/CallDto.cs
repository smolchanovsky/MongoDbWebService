using System;
using DomainObjects.Enums;
using Infrastructure.Common;

namespace BLL.DataTransferObjects
{
    /// <summary>
    /// Data transfer object for Call entity.
    /// </summary>
    public class CallDto : Entity
    {
        public TimeSpan Duration { get; set; }
        public CallStatusType Status { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime ConnectionOn { get; set; }
        public DateTime TerminateOn { get; set; }
    }
}
