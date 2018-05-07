using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNotebook.Models
{
    public class MessageModels
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}