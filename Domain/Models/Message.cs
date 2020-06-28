using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Desctiption { get; set; }

        public string TimeStamp { get; set; }

        public string Service { get; set; }
    }
}
