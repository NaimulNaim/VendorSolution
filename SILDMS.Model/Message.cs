using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model
{
    public class MessageRequestDTO
    {
        public string ProjectCode { get; set; }
        public string ProcessName { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public string MessageFrom { get; set; }
        public string MessageTo { get; set; }
        public string MessageCc { get; set; }
        public string MessageBcc { get; set; }
        public int TaskType { get; set; }

        public List<MessageAttachmentRequestDTO> AttachmentCollection { get; set; }
    }

    public class MessageAttachmentRequestDTO
    {
        public string AttachmentName { get; set; }
        public string AttachmentUrl { get; set; }
        public string AttachmentExtension { get; set; }
        public string AttachmentContent { get; set; }
    }

    public class MessageResponseDTO
    {
        public string ResponseToken { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
