


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }
        public Test Test { get; set; }

        [ForeignKey("Test")]
        public long TestId { get; set; }

        public virtual IEnumerable<Answer> Answers { get; set; }

    }
}