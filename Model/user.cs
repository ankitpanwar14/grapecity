using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Model
{
    public class user
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        public String userName { get; set; }
        public String pwd { get; set; }
    }
}
