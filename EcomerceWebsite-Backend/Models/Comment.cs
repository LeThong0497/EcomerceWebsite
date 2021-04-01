using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceWebsite_Backend.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
