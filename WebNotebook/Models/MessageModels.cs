using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNotebook.Models
{
    public class MessageViewModel
    {
        public string Text { get; set; }
        public string User { get; set; }
    }
    public class MessageModels
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ApplicationUser User { get; set; }
    }
}