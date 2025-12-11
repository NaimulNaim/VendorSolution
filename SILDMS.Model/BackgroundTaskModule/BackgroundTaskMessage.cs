using System;
using System.Collections.Generic;

namespace SILDMS.Model.BackgroundTaskModule
{
    public class BackgroundTaskMessage
    {
        public BackgroundTaskMessage()
        {
            BackgroundTaskMessageAttachmentCollection = new HashSet<BackgroundTaskMessageAttachment>();
        }

        public long MessageId { get; set; }

        public string MessageSubject { get; set; }

        public string MessageContent { get; set; }

        public string MessageFrom { get; set; }

        public string MessageTo { get; set; }

        public string MessageCc { get; set; }

        public string MessageBcc { get; set; }

        public string ProjectCode { get; set; }

        public string ProcessName { get; set; }

        public int MessageType { get; set; }

        public int TaskType { get; set; }

        public string TransactionToken { get; set; }

        public int IsAttachmentAvailable { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int Counter { get; set; }

        public int Status { get; set; }

        public ICollection<BackgroundTaskMessageAttachment> BackgroundTaskMessageAttachmentCollection { get; set; }
    }

}
