using System.Collections.Generic;

namespace BLL.DTO
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public long QuestionId { get; set; }
        public QuestionDto Question { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
    }
}