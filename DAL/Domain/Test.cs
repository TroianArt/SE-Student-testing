using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class Test : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateValid { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [ForeignKey("Group")]
        public long GroupId { get; set; }

        [Required]
        public virtual Group Group { get; set; }
        public virtual IEnumerable<Question> Questions { get; set; }
    }
}