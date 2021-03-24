using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class UserTest : BaseEntity
    {
        [Required]
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        [ForeignKey("Test")]
        public long TestId { get; set; }

        [Required]
        public virtual Test Test { get; set; }

        [Required] 
        public bool IsCompleted { get; set; }
    }
}