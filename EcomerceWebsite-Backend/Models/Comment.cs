using System;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebsite_Backend.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int Star { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int ProductID { get; set; }
        public string UserName { get; set; }
        public virtual Product Product { get; set; }
    }
}
