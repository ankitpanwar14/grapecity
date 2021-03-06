using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Model
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int postId { get; set; }
        public String postTitle { get; set; }
        public String postSubTitle { get; set; }
        public String postContent { get; set; }
        public DateTime postCreatedDate { get; set; }
        public String postCreatedBy { get; set; }
    }
}
