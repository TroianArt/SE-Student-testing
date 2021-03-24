using System;
using System.Collections;
using System.Collections.Generic;

namespace DAL.Domain
{
    public class Group : BaseEntity
    {
        public long CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Test> Tests { get; set; }
    }
}