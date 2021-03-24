using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Enums;

namespace DAL.Domain
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }
        public virtual Test Test { get; set; }

        [ForeignKey("Test")]
        public long TestId { get; set; }

        public virtual IEnumerable<Answer> Answers { get; set; }

        public QuestionType QuestionType { get; set; }

    }
}