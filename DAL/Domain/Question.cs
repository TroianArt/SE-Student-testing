using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Enums;

namespace DAL.Domain
{
    public class Question : BaseEntity
    {
        [Required]
        public string QuestionText { get; set; }

        [Required]
        public virtual Test Test { get; set; }

        [Required]
        [ForeignKey("Test")]
        public long TestId { get; set; }

        public virtual IEnumerable<Answer> Answers { get; set; }

        [Required]
        public QuestionType QuestionType { get; set; }

    }
}