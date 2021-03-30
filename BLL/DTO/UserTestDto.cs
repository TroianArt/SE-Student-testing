using System;

namespace BLL.DTO
{
    public class UserTestDto
    {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string UserId { get; set; }
        public virtual UserDto User { get; set; }
        public long TestId { get; set; }
        public virtual TestDto Test { get; set; }
        public bool IsCompleted { get; set; }
    }
}