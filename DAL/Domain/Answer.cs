using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class Answer : BaseEntity
    {
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}