using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateValid { get; set; }
        public TimeSpan Duration { get; set; }
        public long GroupId { get; set; }
        public GroupDTO Group { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }
    }
}