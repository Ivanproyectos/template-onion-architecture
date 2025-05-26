using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Dtos.Email
{
    public class EmailAttachmentDto
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }
}
