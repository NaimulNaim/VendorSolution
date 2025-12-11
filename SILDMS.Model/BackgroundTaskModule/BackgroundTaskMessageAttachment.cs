using System;
using System.Collections.Generic;

namespace SILDMS.Model.BackgroundTaskModule
{
    public class BackgroundTaskMessageAttachment
    {
        public long AttachmentId { get; set; }

        public string AttachmentName { get; set; }

        public string AttachmentUrl { get; set; }

        public string AttachmentExtension { get; set; }

        public byte[] AttachmentContent { get; set; }

        public long MessageId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int Status { get; set; }

        public virtual BackgroundTaskMessage BackgroundTaskMessage { get; set; }
    }
}
