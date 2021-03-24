using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class Answer : BaseEntity
    {
        [Required]
        public string AnswerText { get; set; }
        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        [ForeignKey("Question")]
        public long QuestionId { get; set; }

        [Required]
        public virtual Question Question { get; set; }

        [Required]
        public virtual IEnumerable<User> Users { get; set; }
    }
}