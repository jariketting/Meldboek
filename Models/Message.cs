using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Message
    {
        public string MessageId { get; set; } // Id of message 
        public string Personname { get; set; } // Personname of Person send message
        public String Content { get; set; } // content in text format
        public DateTime DatetimeSend { get; set; } // datetime message was send
        public DateTime? DatetimeRead { get; set; } // datetime message was read (only used in person to person comminucation)
    }
}