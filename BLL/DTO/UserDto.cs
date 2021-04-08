using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserTestDto> UserTests { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}