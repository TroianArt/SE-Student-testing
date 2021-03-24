using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class UserTest : BaseEntity
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Test")]
        public long TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}