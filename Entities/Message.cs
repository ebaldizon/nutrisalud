using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message
    {
        public DateTime Send { get; set; }
        public string Text { get; set; }
        public int roomId { get; set; }
        public int UserId { get; set; } 
    }
}
