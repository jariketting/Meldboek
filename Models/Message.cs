using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public String Content { get; set; }
        public DateTime DatetimeSend { get; set; }
        public DateTime DatetimeRead { get; set; }
    }
}