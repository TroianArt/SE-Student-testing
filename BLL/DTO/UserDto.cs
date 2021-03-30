using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public virtual IEnumerable<UserTestDto> UserTests { get; set; }
        public virtual IEnumerable<AnswerDto> Answers { get; set; }
        public virtual IEnumerable<GroupDTO> Groups { get; set; }
    }
}