using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Domain
{
    public class User : IdentityUser
    {
        public virtual IEnumerable<UserTest> UserTests { get; set; }
        public virtual IEnumerable<Answer> Answers { get; set; }
        public virtual IEnumerable<Group> Groups { get; set; }
    }
}