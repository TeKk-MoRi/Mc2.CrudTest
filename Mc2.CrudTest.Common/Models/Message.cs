using Mc2.CrudTest.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Common.Models
{
    public class Message
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public MessageType Type { get; set; }
    }
}
