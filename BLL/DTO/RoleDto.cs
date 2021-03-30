using System.Collections.Generic;

namespace BLL.DTO
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserDto> Roles { get; set; }
    }
}