using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferObjects
{
    public class MessageDto
    {

        public Guid Id { get; set; }

        public string Desctiption { get; set; }

        public string TimeStamp { get; set; }

        public string Service { get; set; }
    }
}
