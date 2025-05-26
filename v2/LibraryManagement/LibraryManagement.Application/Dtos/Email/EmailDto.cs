using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Dtos.Email
{
    public class EmailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Cc { get; set; } = new();
        public List<string> Bcc { get; set; } = new();
        public List<EmailAttachmentDto> Attachments { get; set; } = new();
    }
}
