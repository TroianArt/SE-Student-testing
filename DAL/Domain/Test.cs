using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateValid { get; set; }
        public TimeSpan Duration { get; set; }

        [ForeignKey("Group")]
        public long GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual IEnumerable<Question> Questions { get; set; }
    }
}