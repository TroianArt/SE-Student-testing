using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<TestDto> Tests { get; set; }
    }
}