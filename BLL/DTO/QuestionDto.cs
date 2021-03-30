using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public virtual TestDto Test { get; set; }
        public long TestId { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public QuestionTypeDto QuestionType { get; set; }
    }
}