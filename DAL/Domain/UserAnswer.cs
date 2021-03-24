using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Domain
{
    public class UserAnswer
    {
        public User User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public Answer Answer { get; set; }

        [ForeignKey("Answer")]
        public long AnswerId { get; set; }
    }
}